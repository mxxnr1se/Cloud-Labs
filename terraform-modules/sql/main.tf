resource "random_password" "master_password" {
  length           = 32
  min_lower        = 1
  min_numeric      = 3
  min_special      = 3
  min_upper        = 3
  special          = true
  numeric          = true
  upper            = true
  override_special = "!#$%&*()-_=+[]{}<>:?"
}

resource "random_password" "user_password" {
  length           = 32
  min_lower        = 1
  min_numeric      = 3
  min_special      = 3
  min_upper        = 3
  special          = true
  numeric          = true
  upper            = true
  override_special = "!#$%&*()-_=+[]{}<>:?"
}

resource "google_sql_database_instance" "instance" {
  provider = google-beta

  name                = "mysql-db-instance"
  region              = var.region
  project             = var.project
  database_version    = "MYSQL_8_0"
  root_password       = random_password.master_password.result
  deletion_protection = false

  settings {
    tier            = var.machine_type
    edition         = "ENTERPRISE"
    disk_autoresize = false
    disk_size       = var.disk_size
    disk_type       = var.disk_type

    backup_configuration {
      enabled = false
    }

    ip_configuration {
      ipv4_enabled = true

      authorized_networks {
        name  = "my-host"
        value = var.host_address
      }

      private_network                               = var.network
      enable_private_path_for_google_cloud_services = true
    }
  }
}

resource "google_sql_database" "database" {
  name     = var.db_name
  instance = google_sql_database_instance.instance.name
}

resource "google_sql_user" "users" {
  name     = var.username
  password = random_password.user_password.result
  instance = google_sql_database_instance.instance.name
  project  = var.project
}

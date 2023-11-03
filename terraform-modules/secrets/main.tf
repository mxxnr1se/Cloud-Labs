resource "random_password" "key" {
  length           = 27
  special          = true
  override_special = "!#%&@*"
}

locals {
  secrets = [
    {
      secret_id   = "${var.deployment_prefix}-ConnectionString"
      secret_data = "server=${var.db_address};port=${var.db_port};database=${var.db_name};uid=${var.db_username};pwd=${var.db_password}"
    },
    {
      secret_id   = "${var.deployment_prefix}-db-endpoint"
      secret_data = var.db_address
    },
    {
      secret_id   = "${var.deployment_prefix}-db-user"
      secret_data = var.db_username
    },
    {
      secret_id   = "${var.deployment_prefix}-db-password"
      secret_data = var.db_password
    },
    {
      secret_id   = "${var.deployment_prefix}-db-root-password"
      secret_data = var.db_root_password
    },
    {
      secret_id   = "${var.deployment_prefix}-services-key"
      secret_data = random_password.key.result
    },
    {
      secret_id   = "${var.deployment_prefix}-cloudflare-api-token"
      secret_data = base64decode(var.cloudflare_api_token)
    }
  ]
}

resource "google_secret_manager_secret" "secrets" {
  count = length(local.secrets)

  secret_id = local.secrets[count.index].secret_id
  labels    = var.labels

  replication {
    auto {}
  }
}

resource "google_secret_manager_secret_version" "secret-versions" {
  count = length(local.secrets)

  secret      = google_secret_manager_secret.secrets[count.index].id
  secret_data = local.secrets[count.index].secret_data
}

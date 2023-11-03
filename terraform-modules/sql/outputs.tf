output "db_address" {
  description = "The address of the RDS instance."
  value       = google_sql_database_instance.instance.private_ip_address
}

output "db_port" {
  description = "The port of the mysql instance."
  value       = 3306
}

output "db_name" {
  description = "The name of the database."
  value       = google_sql_database.database.name
}

output "db_username" {
  description = "The username for the database."
  value       = google_sql_user.users.name
}

output "db_password" {
  description = "The password for the database."
  value       = random_password.user_password.result
  sensitive   = true
}

output "db_root_password" {
  description = "The password for the database."
  value       = random_password.master_password.result
  sensitive   = true
}

variable "project" {
  description = "The id of the project."
}

variable "region" {
  description = "The region of the project."
}

variable "zone" {
  description = "The zone of the project."
}

# Module variables

variable "deployment_prefix" {
  type        = string
  description = "Prefix of the deployment."
}

variable "labels" {
  type        = map(string)
  description = "Labels to apply to the secret."
}

variable "db_address" {
  type        = string
  description = "Address of the database."
}

variable "db_port" {
  type        = string
  description = "Port for the database."
}

variable "db_name" {
  type        = string
  description = "Name of the database."
}

variable "db_username" {
  type        = string
  description = "Username for the database."
}

variable "db_password" {
  type        = string
  description = "Password for the database."
}

variable "db_root_password" {
  type        = string
  description = "Root password for the database."
}

variable "cloudflare_api_token" {
  type        = string
  description = "Cloudflare API token."
  sensitive   = true
}

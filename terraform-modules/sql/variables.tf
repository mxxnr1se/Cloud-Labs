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

variable "machine_type" {
  description = "Machine type of instance."
  type        = string
  default     = "db-g1-small"
}

variable "disk_size" {
  description = "Disk size of database instance."
  type        = number
  default     = 10
}

variable "disk_type" {
  description = "Disk type of database instance."
  type        = string
  default     = "PD_HDD"
}

variable "network" {
  description = "The VPC network to host the cluster in."
}

variable "db_name" {
  type        = string
  description = "Database name."
}

variable "username" {
  description = "The username for the database."
  type        = string
}

variable "host_address" {
  description = "The IP address of the host machine."
  type        = string
}

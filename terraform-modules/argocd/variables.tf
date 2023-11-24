variable "project" {
  description = "The id of the project."
}

variable "region" {
  description = "The region of the project."
}

variable "zone" {
  description = "The zone of the project."
}

variable "cluster_name" {
  description = "The name of the cluster."
  default     = "primary"
}

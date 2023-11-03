variable "project" {
  description = "The id of the project."
}

variable "region" {
  description = "The region of the project."
}

variable "zone" {
  description = "The zone of the project."
}

# Cluster variables

variable "network" {
  description = "The VPC network to host the cluster in."
}

variable "subnetwork" {
  description = "The subnetwork to host the cluster in."
}

variable "pods_ip_range_name" {
  description = "The name of the ip pods range."
  default     = "k8s-pod-range"
}

variable "services_ip_range_name" {
  description = "The name of the ip services range."
  default     = "k8s-service-range"
}

# Node pool variables

variable "deployment_prefix" {
  type        = string
  description = "Prefix of the deployment."
}

variable "min_nodes" {
  description = "Min number of nodes per zone in node pool"
  type        = number
  default     = 1
}

variable "max_nodes" {
  description = "Max number of nodes per zone in node pool"
  type        = number
  default     = 3
}

variable "location_policy" {
  description = "Algorithm used when scaling up node pool.  Accepted values are BALANCED and ANY"
  type        = string
  default     = "BALANCED"
}

variable "machine_type" {
  description = "Machine type of nodes in node pool."
  type        = string
  default     = "e2-medium"
}

variable "disk_size_gb" {
  description = "The default disk size the nodes are given.  100G is probably too much for a test cluster, so you can change it if you'd like.  Don't set it too low though as disk I/O is also tied to disk size."
  type        = number
  default     = 15
}

variable "disk_type" {
  description = "The type of disk to use on the nodes."
  type        = string
  default     = "pd-standard"
}

variable "image_type" {
  description = "Node/OS image used for each node."
  type        = string
  default     = "COS_CONTAINERD"
}

variable "labels" {
  description = "The map of labels (key/value pairs) to be applied to the resource."
  type        = map(string)
}

variable "oauth_scopes" {
  description = "OAuth scopes of the node. Full list can be found at https://developers.google.com/identity/protocols/oauth2/scopes"
  type        = list(string)
  default = [
    "https://www.googleapis.com/auth/cloud-platform",
    "https://www.googleapis.com/auth/logging.write",
    "https://www.googleapis.com/auth/monitoring",
    "https://www.googleapis.com/auth/devstorage.read_only",
    "https://www.googleapis.com/auth/servicecontrol",
    "https://www.googleapis.com/auth/service.management.readonly",
    "https://www.googleapis.com/auth/trace.append",
  ]
}

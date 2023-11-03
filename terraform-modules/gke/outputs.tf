output "cluster_name" {
  description = "The name of the cluster."
  value       = google_container_cluster.primary.name
}

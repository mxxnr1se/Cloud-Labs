output "network_id" {
  description = "The ID of the network."
  value       = google_compute_network.main.id
}

output "network_self_link" {
  description = "The URI of the network."
  value       = google_compute_network.main.self_link
}

output "subnetwork_self_link" {
  description = "The URI of the subnetwork."
  value       = google_compute_subnetwork.private.self_link
}

output "pods_ip_range_name" {
  description = "The name of the ip pods range."
  value       = google_compute_subnetwork.private.secondary_ip_range.0.range_name
}

output "services_ip_range_name" {
  description = "The name of the ip services range."
  value       = google_compute_subnetwork.private.secondary_ip_range.1.range_name
}

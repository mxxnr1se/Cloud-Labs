resource "google_compute_firewall" "validate_nginx" {
  project = var.project
  name    = "validate-nginx"
  network = var.network
  allow {
    protocol = "tcp"
    ports    = ["8443"]
  }
  direction     = "INGRESS"
  source_ranges = [google_container_cluster.primary.private_cluster_config[0].master_ipv4_cidr_block]
}

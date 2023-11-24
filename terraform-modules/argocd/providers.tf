module "gke_auth" {
  source = "terraform-google-modules/kubernetes-engine/google//modules/auth"

  project_id           = var.project
  cluster_name         = var.cluster_name
  location             = var.region
  use_private_endpoint = false
}

provider "helm" {
  kubernetes {
    host                   = module.gke_auth.host
    token                  = module.gke_auth.token
    cluster_ca_certificate = module.gke_auth.cluster_ca_certificate
  }
}

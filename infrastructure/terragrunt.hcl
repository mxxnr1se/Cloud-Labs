locals {
  source_url     = "git::https://github.com/mxxnr1se/Cloud-Labs.git"
  source_version = "Lab4"

  project = "cloud-labs-december"
  region  = "europe-north1"
  zone    = "europe-north1-a"

  my_ip = "35.176.54.181"

  default_tags = {
    "deployed_by" = "terraform",
    "environment" = "demo"
  }
}

# Configure Terragrunt to automatically store tfstate files in an gcs bucket
remote_state {
  backend = "gcs"
  generate = {
    path      = "backend.tf"
    if_exists = "overwrite_terragrunt"
  }
  config = {
    bucket            = "${local.project}-terragrunt-state-backend"
    prefix            = "${path_relative_to_include()}/terraform.tfstate"
    project           = local.project
    gcs_bucket_labels = local.default_tags
    location          = "eu"
  }
}

retryable_errors = [
  "(?s).*Error.*Required plugins are not installed.*"
]

inputs = {
  region  = local.region
  project = local.project
  zone    = local.zone
}

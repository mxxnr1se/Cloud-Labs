terraform {
  source = "${include.root.locals.source_url}//terraform-modules/argocd?ref=${include.root.locals.source_version}"
}

include "root" {
  path   = find_in_parent_folders()
  expose = true
}

dependency "gke" {
  config_path                             = "../gke/"
  mock_outputs_allowed_terraform_commands = ["init", "validate", "plan", "providers", "terragrunt-info", "show", "destroy"]
  mock_outputs_merge_strategy_with_state  = "shallow"
  mock_outputs = {
    cluster_name = "mock-cluster-name"
  }
}

dependency "secrets" {
  config_path  = "../secrets/"
  skip_outputs = true
}

inputs = {
  cluster_name = dependency.gke.outputs.cluster_name
}

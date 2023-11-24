terraform {
  source = "${include.root.locals.source_url}//terraform-modules/gke?ref=${include.root.locals.source_version}"
}

include "root" {
  path   = find_in_parent_folders()
  expose = true
}

dependency "network" {
  config_path                             = "../networking/"
  mock_outputs_allowed_terraform_commands = ["init", "validate", "plan", "providers", "terragrunt-info", "show", "destroy"]
  mock_outputs_merge_strategy_with_state  = "shallow"
  mock_outputs = {
    network_self_link      = "mock-network_self_link"
    subnetwork_self_link   = "mock-subnetwork_self_link"
    pods_ip_range_name     = "mock-pods_ip_range_name"
    services_ip_range_name = "mock-services_ip_range_name"
  }
}

inputs = {
  network                = dependency.network.outputs.network_self_link
  subnetwork             = dependency.network.outputs.subnetwork_self_link
  pods_ip_range_name     = dependency.network.outputs.pods_ip_range_name
  services_ip_range_name = dependency.network.outputs.services_ip_range_name

  deployment_prefix = title(include.root.locals.default_tags.environment)
  min_nodes         = 1
  max_nodes         = 2
  machine_type      = "e2-custom-4-4096"
  disk_size_gb      = 12
  disk_type         = "pd-balanced"
  labels            = include.root.locals.default_tags
}

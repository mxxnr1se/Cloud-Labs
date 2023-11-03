locals {
  username = "tts_user"
  db_name  = "TaskTrackingSystem"
}

terraform {
  source = "${include.root.locals.source_url}//terraform-modules/sql?ref=${include.root.locals.source_version}"
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
    network_id = "projects/project/global/networks/mock-network"
  }
}

inputs = {
  machine_type = "db-custom-1-3840"
  disk_size    = 10
  disk_type    = "PD_SSD"
  network      = dependency.network.outputs.network_id
  db_name      = local.db_name
  username     = local.username
  host_address = include.root.locals.my_ip
}

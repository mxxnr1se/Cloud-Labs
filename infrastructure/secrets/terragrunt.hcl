terraform {
  source = "${include.root.locals.source_url}//terraform-modules/secrets?ref=${include.root.locals.source_version}"
}

include "root" {
  path   = find_in_parent_folders()
  expose = true
}

dependency "sql" {
  config_path                             = "../sql/"
  mock_outputs_allowed_terraform_commands = ["init", "validate", "plan", "providers", "terragrunt-info", "show", "destroy"]
  mock_outputs_merge_strategy_with_state  = "shallow"
  mock_outputs = {
    db_address       = "mock-db-address"
    db_port          = "mock-db-port"
    db_name          = "mock-db-name"
    db_username      = "mock-db-username"
    db_password      = "mock-db-password"
    db_root_password = "mock-db-root-password"
  }
}

inputs = {
  deployment_prefix = title(include.root.locals.default_tags.environment)
  labels            = include.root.locals.default_tags
  db_address        = dependency.sql.outputs.db_address
  db_port           = dependency.sql.outputs.db_port
  db_name           = dependency.sql.outputs.db_name
  db_username       = dependency.sql.outputs.db_username
  db_password       = dependency.sql.outputs.db_password
  db_root_password  = dependency.sql.outputs.db_root_password

  cloudflare_api_token = get_env("CLOUDFLARE_API_TOKEN")
}

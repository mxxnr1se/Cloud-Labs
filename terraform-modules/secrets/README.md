# secret-manager

<!-- BEGINNING OF PRE-COMMIT-TERRAFORM DOCS HOOK -->
## Requirements

| Name | Version |
|------|---------|
| <a name="requirement_terraform"></a> [terraform](#requirement\_terraform) | >= 1.5.0 |
| <a name="requirement_google"></a> [google](#requirement\_google) | 5.2.0 |
| <a name="requirement_random"></a> [random](#requirement\_random) | 3.5.1 |

## Providers

| Name | Version |
|------|---------|
| <a name="provider_google"></a> [google](#provider\_google) | 5.2.0 |
| <a name="provider_random"></a> [random](#provider\_random) | 3.5.1 |

## Modules

No modules.

## Resources

| Name | Type |
|------|------|
| [google_secret_manager_secret.secrets](https://registry.terraform.io/providers/hashicorp/google/5.2.0/docs/resources/secret_manager_secret) | resource |
| [google_secret_manager_secret_version.secret-versions](https://registry.terraform.io/providers/hashicorp/google/5.2.0/docs/resources/secret_manager_secret_version) | resource |
| [random_password.key](https://registry.terraform.io/providers/hashicorp/random/3.5.1/docs/resources/password) | resource |

## Inputs

| Name | Description | Type | Default | Required |
|------|-------------|------|---------|:--------:|
| <a name="input_cloudflare_api_token"></a> [cloudflare\_api\_token](#input\_cloudflare\_api\_token) | Cloudflare API token. | `string` | n/a | yes |
| <a name="input_db_address"></a> [db\_address](#input\_db\_address) | Address of the database. | `string` | n/a | yes |
| <a name="input_db_name"></a> [db\_name](#input\_db\_name) | Name of the database. | `string` | n/a | yes |
| <a name="input_db_password"></a> [db\_password](#input\_db\_password) | Password for the database. | `string` | n/a | yes |
| <a name="input_db_port"></a> [db\_port](#input\_db\_port) | Port for the database. | `string` | n/a | yes |
| <a name="input_db_root_password"></a> [db\_root\_password](#input\_db\_root\_password) | Root password for the database. | `string` | n/a | yes |
| <a name="input_db_username"></a> [db\_username](#input\_db\_username) | Username for the database. | `string` | n/a | yes |
| <a name="input_deployment_prefix"></a> [deployment\_prefix](#input\_deployment\_prefix) | Prefix of the deployment. | `string` | n/a | yes |
| <a name="input_labels"></a> [labels](#input\_labels) | Labels to apply to the secret. | `map(string)` | n/a | yes |
| <a name="input_project"></a> [project](#input\_project) | The id of the project. | `any` | n/a | yes |
| <a name="input_region"></a> [region](#input\_region) | The region of the project. | `any` | n/a | yes |
| <a name="input_zone"></a> [zone](#input\_zone) | The zone of the project. | `any` | n/a | yes |

## Outputs

No outputs.
<!-- END OF PRE-COMMIT-TERRAFORM DOCS HOOK -->

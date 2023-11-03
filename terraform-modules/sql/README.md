# mysql

<!-- BEGINNING OF PRE-COMMIT-TERRAFORM DOCS HOOK -->
## Requirements

| Name | Version |
|------|---------|
| <a name="requirement_terraform"></a> [terraform](#requirement\_terraform) | >= 1.5.0 |
| <a name="requirement_google"></a> [google](#requirement\_google) | 5.2.0 |
| <a name="requirement_google-beta"></a> [google-beta](#requirement\_google-beta) | 5.2.0 |

## Providers

| Name | Version |
|------|---------|
| <a name="provider_google"></a> [google](#provider\_google) | 5.2.0 |
| <a name="provider_google-beta"></a> [google-beta](#provider\_google-beta) | 5.2.0 |
| <a name="provider_random"></a> [random](#provider\_random) | n/a |

## Modules

No modules.

## Resources

| Name | Type |
|------|------|
| [google-beta_google_sql_database_instance.instance](https://registry.terraform.io/providers/hashicorp/google-beta/5.2.0/docs/resources/google_sql_database_instance) | resource |
| [google_sql_database.database](https://registry.terraform.io/providers/hashicorp/google/5.2.0/docs/resources/sql_database) | resource |
| [google_sql_user.users](https://registry.terraform.io/providers/hashicorp/google/5.2.0/docs/resources/sql_user) | resource |
| [random_password.master_password](https://registry.terraform.io/providers/hashicorp/random/latest/docs/resources/password) | resource |
| [random_password.user_password](https://registry.terraform.io/providers/hashicorp/random/latest/docs/resources/password) | resource |

## Inputs

| Name | Description | Type | Default | Required |
|------|-------------|------|---------|:--------:|
| <a name="input_db_name"></a> [db\_name](#input\_db\_name) | Database name. | `string` | n/a | yes |
| <a name="input_disk_size"></a> [disk\_size](#input\_disk\_size) | Disk size of database instance. | `number` | `10` | no |
| <a name="input_disk_type"></a> [disk\_type](#input\_disk\_type) | Disk type of database instance. | `string` | `"PD_HDD"` | no |
| <a name="input_host_address"></a> [host\_address](#input\_host\_address) | The IP address of the host machine. | `string` | n/a | yes |
| <a name="input_machine_type"></a> [machine\_type](#input\_machine\_type) | Machine type of instance. | `string` | `"db-g1-small"` | no |
| <a name="input_network"></a> [network](#input\_network) | The VPC network to host the cluster in. | `any` | n/a | yes |
| <a name="input_project"></a> [project](#input\_project) | The id of the project. | `any` | n/a | yes |
| <a name="input_region"></a> [region](#input\_region) | The region of the project. | `any` | n/a | yes |
| <a name="input_username"></a> [username](#input\_username) | The username for the database. | `string` | n/a | yes |
| <a name="input_zone"></a> [zone](#input\_zone) | The zone of the project. | `any` | n/a | yes |

## Outputs

| Name | Description |
|------|-------------|
| <a name="output_db_address"></a> [db\_address](#output\_db\_address) | The address of the RDS instance. |
| <a name="output_db_name"></a> [db\_name](#output\_db\_name) | The name of the database. |
| <a name="output_db_password"></a> [db\_password](#output\_db\_password) | The password for the database. |
| <a name="output_db_port"></a> [db\_port](#output\_db\_port) | The port of the mysql instance. |
| <a name="output_db_root_password"></a> [db\_root\_password](#output\_db\_root\_password) | The password for the database. |
| <a name="output_db_username"></a> [db\_username](#output\_db\_username) | The username for the database. |
<!-- END OF PRE-COMMIT-TERRAFORM DOCS HOOK -->

# networking

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

## Modules

No modules.

## Resources

| Name | Type |
|------|------|
| [google-beta_google_compute_global_address.private_ip_address](https://registry.terraform.io/providers/hashicorp/google-beta/5.2.0/docs/resources/google_compute_global_address) | resource |
| [google-beta_google_compute_network.main](https://registry.terraform.io/providers/hashicorp/google-beta/5.2.0/docs/resources/google_compute_network) | resource |
| [google-beta_google_compute_subnetwork.private](https://registry.terraform.io/providers/hashicorp/google-beta/5.2.0/docs/resources/google_compute_subnetwork) | resource |
| [google-beta_google_service_networking_connection.private_vpc_connection](https://registry.terraform.io/providers/hashicorp/google-beta/5.2.0/docs/resources/google_service_networking_connection) | resource |
| [google_compute_address.nat](https://registry.terraform.io/providers/hashicorp/google/5.2.0/docs/resources/compute_address) | resource |
| [google_compute_firewall.allow-iap](https://registry.terraform.io/providers/hashicorp/google/5.2.0/docs/resources/compute_firewall) | resource |
| [google_compute_firewall.allow-mysql](https://registry.terraform.io/providers/hashicorp/google/5.2.0/docs/resources/compute_firewall) | resource |
| [google_compute_firewall.allow-ssh](https://registry.terraform.io/providers/hashicorp/google/5.2.0/docs/resources/compute_firewall) | resource |
| [google_compute_router.router](https://registry.terraform.io/providers/hashicorp/google/5.2.0/docs/resources/compute_router) | resource |
| [google_compute_router_nat.nat](https://registry.terraform.io/providers/hashicorp/google/5.2.0/docs/resources/compute_router_nat) | resource |

## Inputs

| Name | Description | Type | Default | Required |
|------|-------------|------|---------|:--------:|
| <a name="input_project"></a> [project](#input\_project) | The id of the project. | `any` | n/a | yes |
| <a name="input_region"></a> [region](#input\_region) | The region of the project. | `any` | n/a | yes |
| <a name="input_zone"></a> [zone](#input\_zone) | The zone of the project. | `any` | n/a | yes |

## Outputs

| Name | Description |
|------|-------------|
| <a name="output_network_id"></a> [network\_id](#output\_network\_id) | The ID of the network. |
| <a name="output_network_self_link"></a> [network\_self\_link](#output\_network\_self\_link) | The URI of the network. |
| <a name="output_pods_ip_range_name"></a> [pods\_ip\_range\_name](#output\_pods\_ip\_range\_name) | The name of the ip pods range. |
| <a name="output_services_ip_range_name"></a> [services\_ip\_range\_name](#output\_services\_ip\_range\_name) | The name of the ip services range. |
| <a name="output_subnetwork_self_link"></a> [subnetwork\_self\_link](#output\_subnetwork\_self\_link) | The URI of the subnetwork. |
<!-- END OF PRE-COMMIT-TERRAFORM DOCS HOOK -->

# gke

<!-- BEGINNING OF PRE-COMMIT-TERRAFORM DOCS HOOK -->
## Requirements

| Name | Version |
|------|---------|
| <a name="requirement_terraform"></a> [terraform](#requirement\_terraform) | >= 1.5.0 |
| <a name="requirement_google"></a> [google](#requirement\_google) | 5.2.0 |

## Providers

| Name | Version |
|------|---------|
| <a name="provider_google"></a> [google](#provider\_google) | 5.2.0 |

## Modules

No modules.

## Resources

| Name | Type |
|------|------|
| [google_container_cluster.primary](https://registry.terraform.io/providers/hashicorp/google/5.2.0/docs/resources/container_cluster) | resource |
| [google_container_node_pool.general](https://registry.terraform.io/providers/hashicorp/google/5.2.0/docs/resources/container_node_pool) | resource |
| [google_service_account.kubernetes](https://registry.terraform.io/providers/hashicorp/google/5.2.0/docs/resources/service_account) | resource |

## Inputs

| Name | Description | Type | Default | Required |
|------|-------------|------|---------|:--------:|
| <a name="input_deployment_prefix"></a> [deployment\_prefix](#input\_deployment\_prefix) | Prefix of the deployment. | `string` | n/a | yes |
| <a name="input_disk_size_gb"></a> [disk\_size\_gb](#input\_disk\_size\_gb) | The default disk size the nodes are given.  100G is probably too much for a test cluster, so you can change it if you'd like.  Don't set it too low though as disk I/O is also tied to disk size. | `number` | `15` | no |
| <a name="input_disk_type"></a> [disk\_type](#input\_disk\_type) | The type of disk to use on the nodes. | `string` | `"pd-standard"` | no |
| <a name="input_image_type"></a> [image\_type](#input\_image\_type) | Node/OS image used for each node. | `string` | `"COS_CONTAINERD"` | no |
| <a name="input_labels"></a> [labels](#input\_labels) | The map of labels (key/value pairs) to be applied to the resource. | `map(string)` | n/a | yes |
| <a name="input_location_policy"></a> [location\_policy](#input\_location\_policy) | Algorithm used when scaling up node pool.  Accepted values are BALANCED and ANY | `string` | `"BALANCED"` | no |
| <a name="input_machine_type"></a> [machine\_type](#input\_machine\_type) | Machine type of nodes in node pool. | `string` | `"e2-medium"` | no |
| <a name="input_max_nodes"></a> [max\_nodes](#input\_max\_nodes) | Max number of nodes per zone in node pool | `number` | `3` | no |
| <a name="input_min_nodes"></a> [min\_nodes](#input\_min\_nodes) | Min number of nodes per zone in node pool | `number` | `1` | no |
| <a name="input_network"></a> [network](#input\_network) | The VPC network to host the cluster in. | `any` | n/a | yes |
| <a name="input_oauth_scopes"></a> [oauth\_scopes](#input\_oauth\_scopes) | OAuth scopes of the node. Full list can be found at https://developers.google.com/identity/protocols/oauth2/scopes | `list(string)` | <pre>[<br>  "https://www.googleapis.com/auth/cloud-platform",<br>  "https://www.googleapis.com/auth/logging.write",<br>  "https://www.googleapis.com/auth/monitoring",<br>  "https://www.googleapis.com/auth/devstorage.read_only",<br>  "https://www.googleapis.com/auth/servicecontrol",<br>  "https://www.googleapis.com/auth/service.management.readonly",<br>  "https://www.googleapis.com/auth/trace.append"<br>]</pre> | no |
| <a name="input_pods_ip_range_name"></a> [pods\_ip\_range\_name](#input\_pods\_ip\_range\_name) | The name of the ip pods range. | `string` | `"k8s-pod-range"` | no |
| <a name="input_project"></a> [project](#input\_project) | The id of the project. | `any` | n/a | yes |
| <a name="input_region"></a> [region](#input\_region) | The region of the project. | `any` | n/a | yes |
| <a name="input_services_ip_range_name"></a> [services\_ip\_range\_name](#input\_services\_ip\_range\_name) | The name of the ip services range. | `string` | `"k8s-service-range"` | no |
| <a name="input_subnetwork"></a> [subnetwork](#input\_subnetwork) | The subnetwork to host the cluster in. | `any` | n/a | yes |
| <a name="input_zone"></a> [zone](#input\_zone) | The zone of the project. | `any` | n/a | yes |

## Outputs

| Name | Description |
|------|-------------|
| <a name="output_cluster_name"></a> [cluster\_name](#output\_cluster\_name) | The name of the cluster. |
<!-- END OF PRE-COMMIT-TERRAFORM DOCS HOOK -->

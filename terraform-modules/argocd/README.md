# argocd

<!-- BEGINNING OF PRE-COMMIT-TERRAFORM DOCS HOOK -->
## Requirements

| Name | Version |
|------|---------|
| <a name="requirement_terraform"></a> [terraform](#requirement\_terraform) | >= 1.5.0 |
| <a name="requirement_helm"></a> [helm](#requirement\_helm) | 2.11.0 |

## Providers

| Name | Version |
|------|---------|
| <a name="provider_helm"></a> [helm](#provider\_helm) | 2.11.0 |

## Modules

| Name | Source | Version |
|------|--------|---------|
| <a name="module_gke_auth"></a> [gke\_auth](#module\_gke\_auth) | terraform-google-modules/kubernetes-engine/google//modules/auth | n/a |

## Resources

| Name | Type |
|------|------|
| [helm_release.argocd](https://registry.terraform.io/providers/hashicorp/helm/2.11.0/docs/resources/release) | resource |

## Inputs

| Name | Description | Type | Default | Required |
|------|-------------|------|---------|:--------:|
| <a name="input_cluster_name"></a> [cluster\_name](#input\_cluster\_name) | The name of the cluster. | `string` | `"primary"` | no |
| <a name="input_project"></a> [project](#input\_project) | The id of the project. | `any` | n/a | yes |
| <a name="input_region"></a> [region](#input\_region) | The region of the project. | `any` | n/a | yes |
| <a name="input_zone"></a> [zone](#input\_zone) | The zone of the project. | `any` | n/a | yes |

## Outputs

No outputs.
<!-- END OF PRE-COMMIT-TERRAFORM DOCS HOOK -->

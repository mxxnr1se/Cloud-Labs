locals {
  argocd = {
    version   = "5.50.0",
    namespace = "argocd"
  }
}

resource "helm_release" "argocd" {
  name             = "argocd"
  repository       = "https://argoproj.github.io/argo-helm"
  chart            = "argo-cd"
  version          = local.argocd.version
  namespace        = local.argocd.namespace
  create_namespace = true

  values = [
    "${file("${path.module}/argocd-values.yaml")}"
  ]
}

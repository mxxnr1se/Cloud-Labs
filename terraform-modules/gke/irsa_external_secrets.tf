# https://registry.terraform.io/providers/hashicorp/google/latest/docs/resources/google_service_account
resource "google_service_account" "external-secrets" {
  account_id   = "external-secrets"
  display_name = "External Secrets service account"
  description  = "Service account for External Secrets"
}

# https://registry.terraform.io/providers/hashicorp/google/latest/docs/resources/google_project_iam
resource "google_project_iam_member" "external-secrets-secretAccessor" {
  project = var.project
  role    = "roles/secretmanager.secretAccessor"
  member  = "serviceAccount:${google_service_account.external-secrets.email}"
}

resource "google_project_iam_member" "external-secrets-tokenCreator" {
  project = var.project
  role    = "roles/iam.serviceAccountTokenCreator"
  member  = "serviceAccount:${google_service_account.external-secrets.email}"
}

# https://registry.terraform.io/providers/hashicorp/google/latest/docs/resources/google_service_account_iam
resource "google_service_account_iam_member" "external-secrets" {
  service_account_id = google_service_account.external-secrets.id
  role               = "roles/iam.workloadIdentityUser"
  member             = "serviceAccount:${var.project}.svc.id.goog[external-secrets/external-secrets]"

  depends_on = [
    google_container_cluster.primary
  ]
}

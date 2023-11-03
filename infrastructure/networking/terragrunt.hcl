terraform {
  source = "${include.root.locals.source_url}//terraform-modules/networking?ref=${include.root.locals.source_version}"
}

include "root" {
  path   = find_in_parent_folders()
  expose = true
}

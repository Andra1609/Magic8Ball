# terraform import azurerm_resource_group.rg /subscriptions/3eba6e29-3983-495b-a539-c3c4b43fb90c/resourceGroups/andravasilcoiu-project

terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 2.46.0"
    }
  }
}

provider "azurerm" {
  features {}
}

locals {
  project_name = "magic-8-ball"
  location     = "uksouth"
}

resource "azurerm_resource_group" "rg" {
  name     = "${var.user}-project"
  location = var.location
  tags = {
    project = "true"
  }
}

resource "azurerm_app_service_plan" "sp" {
  name                = "${var.user}-project-app-sp"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  kind                = "Linux"
  reserved            = true

  sku {
    tier = "Basic"
    size = "B1"
  }

  tags = {
    project = "true"
  }
}

resource "azurerm_app_service" "webapps" {
  count               = 2
  name                = "${var.user}-webapp-${count.index}"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  app_service_plan_id = azurerm_app_service_plan.sp.id

  # the type of source control enabled for the app service
  site_config {
    linux_fx_version         = "DOTNETCORE|5.0"
    dotnet_framework_version = "v5.0"
    scm_type                 = "None"
  }

  tags = {
    project = "true"
  }
}

resource "azurerm_app_service" "merge-webapp" {
  name                = "${var.user}-webapp-2"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  app_service_plan_id = azurerm_app_service_plan.sp.id

  # the type of source control enabled for the app service
  site_config {
    linux_fx_version         = "DOTNETCORE|5.0"
    dotnet_framework_version = "v5.0"
    scm_type                 = "None"
  }

  app_settings = {
    "personServiceURL" = "https://${var.user}-webapp-0.azurewebsites.net"
    "answerServiceURL" = "https://${var.user}-webapp-1.azurewebsites.net"
  }

  tags = {
    project = "true"
  }
}

resource "azurerm_app_service" "frontend-webapp" {
  name                = "${var.user}-webapp-3"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  app_service_plan_id = azurerm_app_service_plan.sp.id

  # the type of source control enabled for the app service
  site_config {
    linux_fx_version         = "DOTNETCORE|5.0"
    dotnet_framework_version = "v5.0"
    scm_type                 = "None"
  }

  app_settings = {
    "mergeServiceURL" = "https://${var.user}-webapp-2.azurewebsites.net"
  }

  connection_string {
    name  = "DefaultConnection"
    type  = "Custom"
    value = "Server=andraserver.mysql.database.azure.com; Port=3306; Database=magicdb; Uid=${var.user}u@andraserver; Pwd=Pa55w.rd1234; SslMode=Preferred;"
  }

  tags = {
    project = "true"
  }
}

resource "azurerm_mysql_server" "server" {
  name                = "andraserver"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name

  administrator_login          = var.user
  administrator_login_password = "Pa55w.rd1234"

  sku_name   = "B_Gen5_2"
  storage_mb = 5120
  version    = "5.7"

  auto_grow_enabled                = false
  backup_retention_days            = 7
  public_network_access_enabled    = true
  ssl_enforcement_enabled          = true
  ssl_minimal_tls_version_enforced = "TLS1_2"

  tags = {
    project = "true"
  }
}

resource "azurerm_mysql_firewall_rule" "client" {
  name                = "client_ip_dd"
  resource_group_name = azurerm_resource_group.rg.name
  server_name         = azurerm_mysql_server.server.name
  start_ip_address    = "89.36.67.23"
  end_ip_address      = "89.36.67.23"
}

resource "azurerm_mysql_firewall_rule" "azure" {
  name                = "azure_services_allowed"
  resource_group_name = azurerm_resource_group.rg.name
  server_name         = azurerm_mysql_server.server.name
  start_ip_address    = "0.0.0.0"
  end_ip_address      = "0.0.0.0"
}

resource "azurerm_mysql_database" "db" {
  name                = "magicdb"
  server_name         = azurerm_mysql_server.server.name
  resource_group_name = azurerm_resource_group.rg.name

  charset   = "utf8"
  collation = "utf8_unicode_ci"
}

﻿# Configure the Azure provider
terraform {
  required_providers {
    azurerm = {
      source = "hashicorp/azurerm"
      version = ">= 2.26"
    }
  }

backend "azurerm" {
    resource_group_name   = "tfstate"
    storage_account_name  = "tfstate28596"
    container_name        = "tfstate"
    key                   = "tf.tfstate"
  }
}

provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "rg" {
  name     = "warOfHeroesHeroes"
  location = "UK South"
}


resource "azurerm_app_service_plan" "app_service_plan" {
    name                = "warOfHeroes-appservice"
    location            = azurerm_resource_group.rg.location
    resource_group_name = azurerm_resource_group.rg.name

    sku {
        tier = "Shared"
        size = "D1"
    }
}

resource "azurerm_app_service" "heroes_app_service" {
    name                = "warOfHeroesHeroes"
    location            = azurerm_resource_group.rg.location
    resource_group_name = azurerm_resource_group.rg.name
    app_service_plan_id = azurerm_app_service_plan.app_service_plan.id
    https_only = true
    site_config {
        windows_fx_version = "DOTNETCORE|3.1"
    }
    connection_string {
      name = "HeroDb"
      value = azurerm_sql_server.heroes_db.connection_string
    }
}

resource "azurerm_sql_server" "heroes_db" {
  name                         = "heroesdb"
  resource_group_name          = azurerm_resource_group.rg.name
  location                     = azurerm_resource_group.rg.location
  version                      = "12.0"
  administrator_login          = var.DB_USERNAME
  administrator_login_password = var.DB_PASSWORD

  tags = {
    environment = "production"
  }
}
#! /bin/bash
echo "Please enter the following values:"

read -p "Resource Group: " resourceGroup
read -p "Server Name: " serverName
read -p "Location: " location

login="sqladmin"
password="Pa55w.rd"

echo "Creating resource group..."

az group create --name $resourceGroup --location $location

echo "Creating SQL Database server..."

az sql server create --name $serverName --resource-group $resourceGroup --location $location --admin-user $login --admin-password $password
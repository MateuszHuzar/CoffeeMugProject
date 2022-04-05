# CoffeeMugProject

This repository contains project for recruitment process in CoffeeMug company. It's a WebAPI project built with .NET 6, SQL and EntityFramework.


## What you need to run this app

- Microsoft SQL Express
- Microsoft Visual Studio


## Quick start

- clone the repository
- start and build a project
- run ```dotnet ef database update``` command in Package manager console to create a database
- run the solution

A browser will appear with the default Swagger page.

Repository contains controller which allows to perform GET, POST, PUT and DELETE methods. 

# EXAMPLE
## GET all products
![GET method](https://user-images.githubusercontent.com/45356049/161822023-23f876bd-dc60-4e40-af0c-cbc61a905e95.png)

## GET single product
![get_one](https://user-images.githubusercontent.com/45356049/161822148-49055c06-845b-4c3d-a27f-f21903694ed1.png)

## POST new product
```
{
  "name": "HDD",
  "number": 3,
  "quantity": 1,
  "description": "4TB",
  "price": 300
}
```
![post](https://user-images.githubusercontent.com/45356049/161826531-8a5a201e-3c13-429d-bcd4-258d4c673b90.png)

## PUT product
```
{
  "id": "123002f3-8b99-4215-a633-08da172b5537",
  "name": "Laptop",
  "number": 1,
  "quantity": 5,
  "description": "computers for work",
  "price": 2000
}
```
![put](https://user-images.githubusercontent.com/45356049/161822187-7973c0cc-82ea-4e11-a717-8d553839c5b0.png)

 ## DELETE product
![delete](https://user-images.githubusercontent.com/45356049/161822194-5e542653-8fc7-418b-9e2e-ae58daba8d07.png)

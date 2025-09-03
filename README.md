# ProjetFinalTrans2

# ProjetFinalTrans2 — ASP.NET Core MVC (Panier + Paiement)

> Application web **ASP.NET Core 8 MVC** réalisée dans le cadre du cours *Applications transactionnelles sur le Web 2*.  
> Objectif : démontrer une architecture propre (**Controllers / Services / IServices / Models / Views**), un **panier d’achat**, un **paiement en ligne**, et une **zone Admin**.

---

## 🎯 Fonctionnalités principales
- Authentification & autorisation (ASP.NET Core Identity)
- Catalogue de produits (CRUD)
- Panier d’achat (session + persistance DB)
- Passage de commande avec paiement **PayPal sandbox**
- Tableau de bord **Admin** (gestion produits, catégories, commandes, utilisateurs)
- Validation côté serveur + client 
- UI responsive (Bootstrap 5)

---

## 🧱 Architecture

```
ProjetFinalTrans2/
├─ Controllers/
├─ Services/
├─ IServices/
├─ Models/
├─ Views/
├─ Data/
├─ wwwroot/
├─ docs/
│   └─ screenshots/
│        ├─ About.png
│        ├─ Accueil.png
│        ├─ Admin1.png … Admin4.png
│        ├─ Catalogue.png
│        ├─ Inscription1.png, Inscription2.png
│        ├─ Login1.png, Login2.png
│        └─ Panier.png
└─ README.md
```

---

## ⚙️ Stack technique
- **.NET 8 / ASP.NET Core MVC**
- **Entity Framework Core** + SQL Server
- **ASP.NET Core Identity**
- **Bootstrap 5**
- **PayPal Sandbox** pour le paiement

---

## 🚀 Démarrage rapide

### Prérequis
- .NET 8 SDK
- SQL Server (localdb ou instance)
- Compte PayPal sandbox (test paiement)

### Installation
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```


## 📸 Captures d’écran

### 🏠 Accueil
![Accueil](docs/screenshots/Accueil.png)

### 🔑 Connexion
![Login1](docs/screenshots/Login1.png)
![Login2](docs/screenshots/Login2.png)

### 📝 Inscription
![Inscription1](docs/screenshots/Inscription1.png)
![Inscription2](docs/screenshots/Inscription2.png)

### 🛍️ Catalogue Produits
![Catalogue](docs/screenshots/Catalogue.png)

### 🛒 Panier d’achat
![Panier](docs/screenshots/Panier.png)

### ⚙️ Zone Admin
![Admin1](docs/screenshots/Admin1.png)
![Admin2](docs/screenshots/Admin2.png)
![Admin3](docs/screenshots/Admin3.png)
![Admin4](docs/screenshots/Admin4.png)

### ℹ️ Page About
![About](docs/screenshots/About.png)
---

## 📘 Ce que j’ai appris
- Organiser un projet ASP.NET Core avec séparation des responsabilités (**Services / IServices / Controllers / Models / Views**).  
- Utiliser **Entity Framework Core** pour gérer les migrations et la persistance des données.  
- Implémenter un **panier d’achat** avec sessions et persistance en base.  
- Intégrer un système de paiement externe (**PayPal Sandbox**).  
- Gérer l’authentification et l’autorisation avec **ASP.NET Core Identity**.  
- Créer une interface responsive et ergonomique avec **Bootstrap 5**.  

---

## 📄 Licence
MIT © 2025 — Omar Filali

---

## 🇬🇧 Short English summary
**ASP.NET Core 8 MVC e-commerce demo** with clean separation (Controllers / Services / IServices / Models / Views), shopping cart, online payment (PayPal), and an Admin area. Uses EF Core + SQL Server and Bootstrap 5.  

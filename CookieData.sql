CREATE DATABASE COOKINGUEST;
CREATE TABLE Client (
    idClient INT PRIMARY KEY auto_increment,
    Nom NVARCHAR(50),
    Prenom NVARCHAR(50),
    Age INT,
    Telephone NVARCHAR(20),
    Domicile NVARCHAR(100),
    Mail NVARCHAR(100),
    PtsBonus INT
);

-- Création de la table Recette
CREATE TABLE Recette (
    idRecette INT PRIMARY KEY auto_increment,
    NomRec NVARCHAR(100),
    CategorieRec NVARCHAR(50),
    descriptifRec NVARCHAR(1000),
    Prix DECIMAL(10, 2),
    PtsBonus INT
);

-- Création de la table CreateurRecette
CREATE TABLE CreateurRecette (
    idClient INT REFERENCES Client(idClient),
    idRecette INT REFERENCES Recette(idRecette),
    soldePoint INT,
    SoldeCash DECIMAL(10, 2),
    PRIMARY KEY (idClient, idRecette)
);

-- Création de la table Commande
CREATE TABLE Commande (
    idCommande INT PRIMARY KEY auto_increment,
    date DATETIME,
    adresse NVARCHAR(100),
    idClient INT REFERENCES Client(idClient)
);

-- Création de la table DetCommande
CREATE TABLE DetCommande (
    idRecette INT REFERENCES Recette(idRecette),
    idCommande INT REFERENCES Commande(idCommande),
    QCommande INT,
    PRIMARY KEY (idRecette, idCommande)
);

-- Création de la table Produit
CREATE TABLE Produit (
    idProduit INT PRIMARY KEY auto_increment,
    Nom NVARCHAR(100),
    CategorieProd NVARCHAR(50),
    Unit NVARCHAR(50),
    StockAnn INT,
    StockMin INT,
    stockMax INT
);

-- Création de la table QuantiteProduit
CREATE TABLE QuantiteProduit (
    idProduit INT REFERENCES Produit(idProduit),
    idrecette INT REFERENCES Recette(idRecette),
    QNeeded INT,
    PRIMARY KEY (idProduit, idrecette)
);

-- Création de la table Fournisseur
CREATE TABLE Fournisseur (
    idFournisseur INT PRIMARY KEY auto_increment,
    NomFour NVARCHAR(100),
    NumSiret NVARCHAR(14),
    Adresse NVARCHAR(100)
);

-- Création de la table FournisseurProd
CREATE TABLE FournisseurProd (
    idFournisseur INT REFERENCES Fournisseur(idFournisseur),
    idProduit INT REFERENCES Produit(idProduit),
    QFournit INT,
    PRIMARY KEY (idFournisseur, idProduit)
);

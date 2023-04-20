-- Création de la base de données Cookinguest
CREATE DATABASE COOKINGUEST;

-- Création de la table Client pour stocker les informations sur les clients
CREATE TABLE Client (
    idClient INT PRIMARY KEY auto_increment,
    Nom NVARCHAR(50),        -- Nom du client
    Prenom NVARCHAR(50),     -- Prénom du client
    Age INT,                 -- Âge du client
    Telephone NVARCHAR(20),  -- Numéro de téléphone du client
    Domicile NVARCHAR(100),  -- Adresse du domicile du client
    Mail NVARCHAR(100),      -- Adresse e-mail du client
    PtsBonus INT             -- Points bonus accumulés par le client
);

-- Insérer des données aléatoires dans la table Client
INSERT INTO Client (Nom, Prenom, Age, Telephone, Domicile, Mail, PtsBonus) VALUES
('Doe', 'John', 30, '0102030405', '10 Rue de la Paix, 75000 Paris', 'john.doe@example.com', 500),
('Dupont', 'Marie', 28, '0607080910', '20 Rue du Temple, 75000 Paris', 'marie.dupont@example.com', 300),
('Martin', 'Paul', 45, '0708091011', '30 Rue de Rivoli, 75000 Paris', 'paul.martin@example.com', 200);

-- Création de la table Recette pour stocker les informations sur les recettes
CREATE TABLE Recette (
    idRecette INT PRIMARY KEY auto_increment,
    NomRec NVARCHAR(100),     -- Nom de la recette
    CategorieRec NVARCHAR(50), -- Catégorie de la recette
    descriptifRec NVARCHAR(1000), -- Description de la recette
    Prix DECIMAL(10, 2),         -- Prix de la recette
    PtsBonus INT                 -- Points bonus pour la recette
);

-- Insérer des données aléatoires dans la table Recette
INSERT INTO Recette (NomRec, CategorieRec, descriptifRec, Prix, PtsBonus) VALUES
('Salade César', 'Entrée', 'Salade César avec poulet grillé, croûtons, parmesan et sauce César maison', 8.50, 10),
('Spaghetti Carbonara', 'Plat', 'Spaghetti avec sauce Carbonara, lardons, œuf et parmesan', 12.00, 15),
('Tiramisu', 'Dessert', 'Tiramisu avec mascarpone, café, biscuits cuillère et cacao', 6.50, 8);

-- Création de la table CreateurRecette pour stocker les informations sur les créateurs de recettes
CREATE TABLE CreateurRecette (
    idClient INT REFERENCES Client(idClient),  -- Clé étrangère référençant la table Client
    idRecette INT REFERENCES Recette(idRecette), -- Clé étrangère référençant la table Recette
    soldePoint INT, -- Solde de points du créateur de la recette
    SoldeCash DECIMAL(10, 2),   -- Solde en espèces du créateur de la recette
    PRIMARY KEY (idClient, idRecette)
);

-- Insérer des données aléatoires dans la table CreateurRecette
INSERT INTO CreateurRecette (idClient, idRecette, soldePoint, SoldeCash) VALUES
(1, 1, 150, 100.00),
(1, 2, 250, 200.00),
(2, 3, 100, 50.00);

-- Création de la table Commande pour stocker les informations sur les commandes
CREATE TABLE Commande (
    idCommande INT PRIMARY KEY auto_increment,
    date DATETIME,              -- Date et heure de la commande
    adresse NVARCHAR(100),      -- Adresse de livraison de la commande
    idClient INT REFERENCES Client(idClient) -- Clé étrangère référençant la table Client
);

-- Insérer des données aléatoires dans la table Commande
INSERT INTO Commande (date, adresse, idClient) VALUES
('2023-04-20 12:00:00', '10 Rue de la Paix, 75000 Paris', 1),
('2023-04-20 12:15:00', '20 Rue du Temple, 75000 Paris', 2),
('2023-04-20 12:30:00', '30 Rue de Rivoli, 75000 Paris', 3);

-- Création de la table DetCommande pour stocker les détails des commandes
CREATE TABLE DetCommande (
    idRecette INT REFERENCES Recette(idRecette), -- Clé étrangère référençant la table Recette
    idCommande INT REFERENCES Commande(idCommande), -- Clé étrangère référençant la table Commande
    QCommande INT, -- Quantité commandée
    PRIMARY KEY (idRecette, idCommande)
);

-- Insérer des données aléatoires dans la table DetCommande
INSERT INTO DetCommande (idRecette, idCommande, QCommande) VALUES
(1, 1, 2),
(2, 2, 1),
(3, 3, 3);

-- Création de la table Produit pour stocker les informations sur les produits
CREATE TABLE Produit (
    idProduit INT PRIMARY KEY auto_increment,
    Nom NVARCHAR(100),       -- Nom du produit
    CategorieProd NVARCHAR(50), -- Catégorie du produit
    Unit NVARCHAR(50),       -- Unité de mesure du produit
    StockAnn INT,            -- Stock annuel du produit
    StockMin INT,            -- Stock minimum du produit
    stockMax INT             -- Stock maximum du produit
);

-- Insérer des données aléatoires dans la table Produit
INSERT INTO Produit (Nom, CategorieProd, Unit, StockAnn, StockMin, stockMax) VALUES
('Tomates', 'Légumes', 'kg', 500, 50, 1000),
('Oeufs', 'Produits laitiers', 'unité', 1000, 100, 2000),
('Farine', 'Épicerie', 'kg', 200, 20, 400);

-- Création de la table QuantiteProduit pour stocker la quantité de produits nécessaires pour chaque recette
CREATE TABLE QuantiteProduit (
    idProduit INT REFERENCES Produit(idProduit), -- Clé étrangère référençant la table Produit
    idrecette INT REFERENCES Recette(idRecette), -- Clé étrangère référençant la table Recette
    QNeeded INT, -- Quantité nécessaire de produit pour la recette
    PRIMARY KEY (idProduit, idrecette)
);

-- Insérer des données aléatoires dans la table QuantiteProduit
INSERT INTO QuantiteProduit (idProduit, idrecette, QNeeded) VALUES
(1, 1, 2),
(2, 2, 4),
(3, 3, 1);

-- Création de la table Fournisseur pour stocker les informations sur les fournisseurs
CREATE TABLE Fournisseur (
    idFournisseur INT PRIMARY KEY auto_increment,
    NomFour NVARCHAR(100),   -- Nom du fournisseur
    NumSiret NVARCHAR(14),   -- Numéro SIRET du fournisseur
    Adresse NVARCHAR(100)    -- Adresse du fournisseur
);

-- Insérer des données aléatoires dans la table Fournisseur
INSERT INTO Fournisseur (NomFour, NumSiret, Adresse) VALUES
('Legumes Express', '12345678912345', '1 Rue des Legumes, 75000 Paris'),
('OeufLand', '23456789123456', '2 Rue des Oeufs, 75000 Paris'),
('Epicerie Gourmet', '34567891234567', '3 Rue de l''Epicerie, 75000 Paris');

-- Création de la table FournisseurProd pour associer les fournisseurs aux produits qu'ils fournissent
CREATE TABLE FournisseurProd (
    idFournisseur INT REFERENCES Fournisseur(idFournisseur), -- Clé étrangère référençant la table Fournisseur
    idProduit INT REFERENCES Produit(idProduit), -- Clé étrangère référençant la table Produit
    QFournit INT, -- Quantité fournie
    PRIMARY KEY (idFournisseur, idProduit)
);

-- Insérer des données aléatoires dans la table FournisseurProd
INSERT INTO FournisseurProd (idFournisseur, idProduit, QFournit) VALUES
(1, 1, 100),
(2, 2, 50),
(3, 3, 200);


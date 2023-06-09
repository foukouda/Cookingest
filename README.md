﻿# Cookingest
Sujet projet BDD : CookinGest
La startup CookinGest vient de se créer et a besoin pour son bon fonctionnement et
pour se lancer et assurer les fonctions promises (via son site web et son application
mobile) d’une interface (IHM) ludique.
La partie « classique » du concept :
La startup propose via cette interface des plats cuisinés. Les clients commandent ces
plats et sont ensuite livrés par un service de livraison à vélo.
La partie « novatrice » du concept :
Les clients qui commandent les plats sont aussi, s’ils le souhaitent, les créateurs de
recettes. Ils peuvent dans ce cas proposer des recettes qui seront intégrées dans la
liste des plats proposés par CookinGest. Cette création de recettes est récompensée
(explication plus tard).
Fonctionnement du concept :
Clients :
- Commandent des plats
- Payent les plats commandés
Les créateurs de recettes :
- Sont des clients
- Fournissent des recettes
- Obtiennent des récompenses à chaque fois que leur recette est commandée
Personnel de CookinGest :
- Réalisent les recettes commandées par les clients
- Gèrent l’approvisionnement des produits nécessaires
- Organisent les livraisons des plats cuisinés
- Encaissent les règlements des clients
Le besoin exprimé dans ce projet :
Dans ce projet on s’intéressera à la gestion automatique des flux d’informations
autour des plats cuisinés (les recettes et les matières premières) et des commandes
clients ainsi que la récompense.
On n’aura pas à se soucier :
- De la gestion logistique : livraison, même si renseigner une adresse de
livraison pour chaque commande reste nécessaire
- De la gestion financière : les règlements des clients seront réduits à un solde
fictif, on ne gère pas le paiement de la matière première ni la rémunération
du personnel.
Les informations à sauvegarder :
La startup souhaite avoir dans sa base de données ces informations. Vous rajouterez
toute information supplémentaire nécessaire à la réalisation des fonctionnalités
STI2D A2 2022-2023 BDD-SQL
demandées dans le cahier de charge. Le choix des identifiants et de l’organisation de
ces informations revient à vous.
Un client a un nom, prénom, numéro de téléphone, mail et un solde rechargeable
Un créateur de recette a un solde en points qu’il peut transférer sur son solde
monétaire
Une recette est constituée d’un nom, catégorie, descriptif, liste d’ingrédients avec
quantité pour chaque ingrédient, prix de vente (fixé par le créateur de recette),
montant de récompense (choisi par vous, fixe ou en fonction du prix de vente)
Un produit a un nom, catégorie, unité, stock actuel, stock minimal, stock maximal, et
un ou plusieurs fournisseurs
Un fournisseur a un nom, numéro de Siret, adresse et téléphone
Les fonctionnalités nécessaires :
Les fonctionnalités minimales permettant de valider le concept sont :
Le client : peut créer un compte, s’identifier, s’inscrire dans le programme créateur
de recette, parcourir la liste des recettes proposées (seulement celles avec un stock
de produit suffisant), choisir plusieurs plats et/ou plusieurs fois le même plat,
convertir ses points, payer la commande.
Le paiement de la commande doit permettre une mise à jour du stock des produits,
du solde client, de son solde point
Le créateur de recette : peut saisir une recette (toutes les informations) consulter
son solde, afficher la liste de ses recettes
Le gestionnaire de CookinGest a un tableau de bord de la semaine qui lui affiche le
créateur de recette de la semaine (ayant les recettes les plus commandées), le top 5
de la semaine (les recettes les plus commandées), le Client de la semaine (celui
ayant payé le plus de commande cette semaine). Il a aussi un tableau de gestion des
produits : ajouter un produit, afficher la liste des produits, afficher la liste des
produits à restocker, augmenter le stock d’un produit, supprimer une recette,
supprimer un client (ce dernier est optionnel)

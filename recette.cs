using System;
using MySql.Data.MySqlClient;//utilisation de la bibliothèque

using static System.Console;

namespace projet
{
    public class  recette 
    {
        #region // Attributs
       
        public string NomRec { get; set; }
        public string CategorieRec { get; set; }
        public string descriptifRec { get; set; }
        public decimal Prix { get; set; }
        public int PtsBonus { get; set; }
        // Constructeur
        public recette(string nomRec, string categorieRec, string descriptifRec, decimal prix, int ptsBonus)
        {
           
            NomRec = nomRec;
            CategorieRec = categorieRec;
            this.descriptifRec = descriptifRec;
            Prix = prix;
            PtsBonus = ptsBonus;
        }
        #endregion
       
        #region // Méthodes de saisie
        public static string Saisie(string message)
        {
            string input = "";
            do
            {
                Console.WriteLine(message);
                input = Console.ReadLine() ?? "";
            } while (input == "");
            return input.ToLower();
        }

        public static int SaisieEntier(string message, int min = 0, int max = 120)
        {
            int input;
            do
            {
                WriteLine(message);
                input = Convert.ToInt32(Console.ReadLine());
            } while (input < min || input > max);
            return input;
        }

        public static bool SaisieBooleen(string message)
        {
            Console.WriteLine(message);
            return Convert.ToBoolean(Console.ReadLine());
        }
        #endregion

        #region // Création de la recette 
        public static creationRecette()
        {
            string nomRec = Saisie("Écrire le nom de la recette");
            string categorieRec = Saisie("Écrire la catégorie de la recette");
            string descriptifRec = Saisie("Écrire le descriptif de la recette");
            decimal prix = SaisieEntier("Écrire le prix de la recette");
            int ptsBonus = SaisieEntier("Écrire le nombre de points bonus de la recette");
        }
        #endregion
    }
}
using System;
using MySql.Data.MySqlClient;//utilisation de la bibliothèque
using static System.Console;

namespace Cookieges_projet
{
    public class Recette
    {
          #region // Attributs
       
        public string NomRec { get; set; }
        public string CategorieRec { get; set; }
        public string descriptifRec { get; set; }
        public double Prix { get; set; }
        public int PtsBonus { get; set; }
        // Constructeur
        public Recette(string nomRec, string categorieRec, string descriptifRec, double prix, int ptsBonus)
        {
           
            this.NomRec = nomRec;
            this.CategorieRec = categorieRec;
            this.descriptifRec = descriptifRec;
            this.Prix = prix;
            this.PtsBonus = ptsBonus;
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
        public static double SaisieDecimal(string message, double min = 0, double max = 120)
        {
            double input;
            do
            {
                WriteLine(message);
                input = Convert.ToDouble(Console.ReadLine());
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
        public static Recette creationRecette()
        {
            string nomRec = Saisie("Écrire le nom de la recette");
            string categorieRec = Saisie("Écrire la catégorie de la recette");
            string descriptifRec = Saisie("Écrire le descriptif de la recette");
            double prix = SaisieDecimal("Écrire le prix de la recette");
            int ptsBonus = SaisieEntier("Écrire le nombre de points bonus de la recette");
            new Recette(nomRec, categorieRec, descriptifRec, prix, ptsBonus);
            MySqlConnection maConnection = new MySqlConnection("SERVER=localhost;PORT=3306;DATABASE=COOKINGUEST;UID=root;PASSWORD=root;");
            maConnection.Open();
            string query = $"INSERT INTO Recette (nomRec,categorieRec,descriptifRec,prix,ptsBonus) VALUES ('{nomRec}', '{categorieRec}', '{descriptifRec}', {prix}, {ptsBonus});";
            MySqlCommand command = new MySqlCommand(query, maConnection);
            command.ExecuteNonQuery();
            return new Recette(nomRec, categorieRec, descriptifRec, prix, ptsBonus);
        }

        #endregion
    }
}

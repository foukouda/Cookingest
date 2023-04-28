using System;
using MySql.Data.MySqlClient;//utilisation de la bibliothèque

namespace Cookieges_projet
{
    public class Client
    {
        #region // Attributs
        private string Nom { get; set; }
        private string Prenom { get; set; }
        private int Age { get; set; }
        private string Telephone { get; set; }
        private string Email { get; set; }  
        private string Domicile { get; set; }
        private int PtsBonus { get; set; }
        private bool Createur { get; set; }
        private string Mdp { get; set; }

        // Constructeur
        public Client(string nom, string prenom, int age, string telephone, string email, string Domicile, int PtsBonus, bool createur, string Mdp)
        {
    
            Nom = nom;
            Prenom = prenom;
            Age = age;
            Telephone = telephone;
            Email = email;
            this.Domicile = Domicile;            
            this.PtsBonus = PtsBonus;
            Createur = createur;
            this.Mdp = Mdp;
        }
        #endregion
       
        #region // Méthodes de saisie
        private static string Saisie(string message)
        {
            string input;
            do
            {
                Console.WriteLine(message);
                input = Console.ReadLine().ToLower();
            } while (string.IsNullOrEmpty(input));
            return input;
        }

        private static int SaisieEntier(string message, int min = 0, int max = 120)
        {
            int input;
            do
            {
                Console.WriteLine(message);
                input = Convert.ToInt32(Console.ReadLine());
            } while (input < min || input > max);
            return input;
        }

        private static bool SaisieBooleen(string message)
        {
            Console.WriteLine(message);
            return Convert.ToBoolean(Console.ReadLine());
        }
        #endregion

        #region // Création du client
        public static Client CreateurClient()
        {
            // Saisie des informations
            string email;
            bool go_on = true;
            do{
                email = Saisie("Écrire votre email");
                if (email.Contains("@") && email.Contains(".") && email.Contains("gmail"))
                {
                    if (Verifemail(email))
                    {
                        Console.WriteLine("Votre email est déjà utilisé");
                    }
                    else
                    {
                         go_on = false;
                    }     
                }
                else
                {
                    Console.WriteLine("Votre email n'est pas valide");
                }
            } while (go_on); 
            string nom = Saisie("Écrire votre nom");
            string prenom = Saisie("Écrire votre prénom");
            bool createur = SaisieBooleen("Écrire si vous êtes créateur (true/false)");
            int age = SaisieEntier("Écrire votre âge");
            string telephone = Saisie("Écrire votre téléphone");
            string Domicile = Saisie("Écrire votre adresse");
            string mdp = Saisie("Écrire votre mot de passe");
            // Vérification du mot de passe
            bool verif;
            do
            {
                verif = true;
                mdp = mdp.ToLower();

                if (mdp.Contains(nom) || mdp.Contains(prenom))
                {
                    Console.WriteLine("Votre mot de passe ne doit pas contenir votre nom ou prénom");
                    verif = false;
                }
                else if (mdp.Length < 8)
                {
                    Console.WriteLine("Votre mot de passe doit contenir au moins 8 caractères");
                    verif = false;
                }
                else if (mdp.Contains(" "))
                {
                    Console.WriteLine("Votre mot de passe ne doit pas contenir d'espace");
                    verif = false;
                }

                if (!verif) mdp = Saisie("Réécrire votre mot de passe");

            } while (!verif);

            String mdp2 = Saisie("Réécrire votre mot de passe");
            while (mdp != mdp2)
            {
                Console.WriteLine("Les mots de passe ne correspondent pas");
                mdp2 = Saisie("Réécrire votre mot de passe");
            }
            new Client(nom, prenom, age, telephone, Domicile, email, 0, createur, mdp);
            // Ajout dans la base de données
            MySqlConnection maConnection = new MySqlConnection("SERVER=localhost;PORT=3306;DATABASE=COOKINGUEST;UID=root;PASSWORD=root;");
            maConnection.Open();
            string query = $"INSERT INTO Client (Nom, Prenom, Age, Telephone, Domicile, Mail, PtsBonus, Createur, Mdp) VALUES ('{nom}', '{prenom}', {age}, '{telephone}', '{Domicile}', '{email}', 0, {createur}, '{mdp}');";
            MySqlCommand command = new MySqlCommand(query, maConnection);
            command.ExecuteNonQuery();
            return new Client(nom, prenom, age, telephone, Domicile, email, 0, createur, mdp);
        }
        #endregion

        #region // Vérification email SQL
       public static bool Verifemail(string email)
       {
            email = email.ToLower();
            MySqlConnection maConnection = new MySqlConnection("SERVER=localhost;PORT=3306;DATABASE=COOKINGUEST;UID=root;PASSWORD=root;");
            maConnection.Open();
            string query = $"SELECT Mail FROM Client WHERE Mail = '{email}';";
            MySqlCommand command = new MySqlCommand(query, maConnection);
            
            return command.ExecuteScalar() != null;
        }

        
        
        
        #endregion
    }
}

using System;
using MySql.Data.MySqlClient;//utilisation de la bibliothèque

namespace Cookieges_projet
{
    public class Client
    {
        #region // Attributs
        private int Id { get; set; }
        private string Nom { get; set; }
        private string Prenom { get; set; }
        private int Age { get; set; }
        private string Telephone { get; set; }
        private string Email { get; set; }  
        private string adresse { get; set; }
        private int PtsBonus { get; set; }
        private bool Createur { get; set; }
        private string Mdp { get; set; }

        // Constructeur
        public Client(int id, string nom, string prenom, int age, string telephone, string email, string adresse, int PtsBonus, bool createur, string Mdp)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Age = age;
            Telephone = telephone;
            Email = email;
            this.adresse = adresse;
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
            string nom = Saisie("Écrire votre nom");
            string prenom = Saisie("Écrire votre prénom");
            int age = SaisieEntier("Écrire votre âge");
            string telephone = Saisie("Écrire votre téléphone");
            string adresse = Saisie("Écrire votre adresse");
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

            bool createur = SaisieBooleen("Écrire si vous êtes créateur (true/false)");
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

            return new Client(1, nom, prenom, age, telephone, adresse, email, 0, createur, mdp);
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
            
            return email == command.ExecuteScalar().ToString();
        }
        
        #endregion
    }
}

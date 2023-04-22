using System;

namespace Cookieges_projet
{
    public class Client
    {
        private int Id { get; set; }
        private string Nom { get; set; }
        private string Prenom { get; set; }
        private int Age { get; set; }
        private string Telephone { get; set; }
        private string Email { get; set; }
        private int PtsBonus { get; set; }
        private bool Createur { get; set; }
        private string Mdp { get; set; }

        // Constructeur
        public Client(int id, string nom, string prenom, int age, string telephone, string email, int PtsBonus, bool createur, string Mdp)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Age = age;
            Telephone = telephone;
            Email = email;
            this.PtsBonus = PtsBonus;
            Createur = createur;
            this.Mdp = Mdp;
        }

        // Méthodes de saisie
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

        public static Client CreateurClient()
        {
            // Saisie des informations
            string nom = Saisie("Écrire votre nom");
            string prenom = Saisie("Écrire votre prénom");
            int age = SaisieEntier("Écrire votre âge");
            string telephone = Saisie("Écrire votre téléphone");
            string email = Saisie("Écrire votre email");
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

            return new Client(1, nom, prenom, age, telephone, email, 0, createur, mdp);
        }
    }
}

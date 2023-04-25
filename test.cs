using System;
using System.Collections.Generic;   
using System.Linq;
using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;

namespace projet
{
    class test 
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static void connection()
        {
            //création de l'instance de la connexion: canal de communication
            MySqlConnection maConnection = new MySqlConnection("SERVER=localhost;PORT=3306;" + "DATABASE = CookieData ; UID = userTesteur; PASSWORD =123456; ");
            //ouverture de la connexion
            maConnection.Open();

            //création d'une commande vers le canal de communication
            MySqlCommand command = maConnection.CreateCommand();
            //insertion de texte de commande: texte de la requête
            command.CommandText = "select * from Club;";
            //création de structure de réception du résultat
            MySqlDataReader reader;
            //exécution et récupération du résultat
            reader = command.ExecuteReader();


            //ici valueString est un tableau qui va contenir à chaque
            //itération les valeurs de la nouvelle ligne
            //une valeur par case
            string[] valueString = new string[reader.FieldCount];
            //FieldCount c'est quoi alors?
            while (reader.Read())//retourne une nouvelle ligne à chaque itération
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    valueString[i] = reader.GetValue(i).ToString();
                    Console.Write(valueString[i] + "\t");
                }
                Console.WriteLine();
            }
          
            //fermeture de la connexion
            maConnection.Close();
        }
        static void affichageTable()
        {
          

            // Create a connection to the database
            MySqlConnection maConnection = new MySqlConnection("SERVER=localhost;PORT=3306;" + "DATABASE = CookieData ; UID = root; PASSWORD =root; ");
            maConnection.Open();

            // Create a command to retrieve the names of all tables in the database
            MySqlCommand command = maConnection.CreateCommand();
            command.CommandText = "SHOW TABLES;";
            MySqlDataReader reader = command.ExecuteReader();

            // Read and display the names of all tables
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(0));
            }

            // Close the connection to the database
            maConnection.Close();
        }
    }
}
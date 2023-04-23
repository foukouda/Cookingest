using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    
//verif adresse mail 
static bool verifMail(string mail)
{
    bool valide = false;
    string[] mailSplit = mail.Split('@');
    if (mailSplit.Length != 2)
    {
        
    }
    else
    {
        string[] mailSplit2 = mailSplit[1].Split('.');
        if (mailSplit2.Length != 2)
        {
            Console.WriteLine("Adresse mail invalide");
        }
        else
        {
            Console.WriteLine("Adresse mail valide");
        }
    }
    return valide ;
}

//verif de mots passe + barre de chargement 

static int verifMdp(string mdp, string prenom, string nom)
{
    int a=0;
    if (mdp.Length < 8)
    {
        a=10;
    }
    else if (mdp.Length > 15)
    {
       a=10;
    }
    else if (mdp.Contains(" "))
    {
       a=10;
    }
    else if (mdp.Contains("1234567890"))
    {
        a++; 
    }
    else if (mdp.Contains("azertyuiop"))
    {
        a++;
    }
    else if (mdp.Contains("AZERTYUIOP"))
    {
        a++;
    }
    return a;
}
//création d'un nouveau compte client 
static void CreationCompteClient()
{
 
 
    Console.WriteLine("Veuillez saisir votre nom");
    string? nom = Console.ReadLine();

 if (nom==null)
 {
    do
    {
        Console.WriteLine("Veuillez saisir un nom valide");
        nom = Console.ReadLine();

    }while (nom == null);
 }  
    Console.WriteLine("Veuillez saisir votre prenom");
    string? prenom =Console.ReadLine();

 if (prenom==null)
 {
    do
    { 
        Console.WriteLine("Veuillez saisir un prenom valide");
        prenom = Console.ReadLine();

    } while (prenom == null);
 }
    Console.WriteLine("Veuillez saisir votre adresse mail");
    string? adressemail = Console.ReadLine();

 if (adressemail == null || verifMail(adressemail) == false)
 {
    do
    {

        Console.WriteLine("Veuillez saisir une adresse mail valide");
        adressemail = Console.ReadLine();

    }while (adressemail == null || verifMail(adressemail) == false);

 }

   
    string? mdp = Console.ReadLine();
    if (mdp == null || verifMdp(mdp,prenom,nom) >10)
    {
        do
        {
            Console.WriteLine("Veuillez saisir un mot de passe valide");
            mdp = Console.ReadLine();
        } while (mdp == null || verifMdp(mdp, prenom, nom) > 10);
    }

  
   
}
 }
}

    








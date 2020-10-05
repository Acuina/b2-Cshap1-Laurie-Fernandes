using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;

namespace commune

{
    class Program
    {
        private static List<Ville> nbreh;

        static void Main(string[] args)
        {
            List<Ville> listeVille = new List<Ville>();

            Console.WriteLine("Bienvenue dans l'application de gestion des villes !");
            
            while (true)
            {
                Console.WriteLine("Que souhaitez vous faire ?");
                string choix_util = Menu_util();

                if (choix_util == "1")
                {
                    Ville p = createVille();
                    listeVille.Add(p);
                }
                else if (choix_util == "2")
                {
                    affiche(listeVille);
                }
                else if (choix_util == "3")
                {
                    affiche(nbreh);
                }
                else if (choix_util == "Q")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Je n'ai pas compris");
                }
            }
            Console.ReadKey();
        }
        public static string Menu_util()
        {
            string choix_util;
            Console.WriteLine("1.Ajouter une Ville");
            Console.WriteLine("2.Afficher la liste des Ville");
            Console.WriteLine("3.Afficher le nombre total d'habitants");
            Console.WriteLine("Q.Quitter");
            choix_util = Console.ReadLine();

            return choix_util;
        }

        public static Ville createVille()
        {
            Ville p = new Ville();


            p.Villes = demande_ville();

            p.Postal = demande_entier("Quel est son code postal ?");

            p.nbres = demande_entier("Combien y'a t'il d'habitants ?");


            return p;
        }

        public static string creer_message(Ville p)

        {
       
            string message;
            
            if (p.Postal == 0)
            {
                message = " code postal incorrect veuillez entrer un code valide. Ex: 38000" ;

            }
            else
            {
                message = "nom : " + p.Villes.ToUpper() + " , Code postal : " + p.Postal + " Nombre d'habitants : " + p.nbres ;

            }
            
            return (message);
        }


        public static void affiche(List<Ville> listeVille)

        {
            Console.WriteLine("Liste des Villes créées : ");
            foreach (Ville p in listeVille)

            {
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                string message;
                message = creer_message(p);
                Console.WriteLine(message);
                Console.WriteLine("----------------------------------------------------------------------------------------------");
            }
           
        }
        /*
         * public static void affiche(List<nbreh> nbreh)

        {
            Console.WriteLine("Nombre total d'habitants de toutes les villes : ");
            foreach (nbreh p in nbreh)

            {
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                string message;
                message = creer_message(p);
                Console.WriteLine(message);
                Console.WriteLine("----------------------------------------------------------------------------------------------");
            }

        }
        
        private static string creer_message(nbreh p)
        {
            throw new NotImplementedException();
        }
        */

        public static int demande_entier(string message)
        {
            Console.WriteLine(message);
            int valeurconverti;
            string entier;

            entier = Console.ReadLine();

            while (!(int.TryParse(entier, out valeurconverti) || valeurconverti < 1))
            {
                Console.WriteLine("Entrez un nombre valide svp");
                entier = Console.ReadLine();
            }
            while (!int.TryParse(entier, out valeurconverti))
            {
                Console.WriteLine("Saisie Incorrecte : le nom de la saisie n'est pas valide ");
                entier = Console.ReadLine();
            }

   
            return valeurconverti;
        }


        public static float demande_decimal(string message)
        {
            Console.WriteLine(message);
            float valeurconverti;
            string dec;
            dec = Console.ReadLine();
           

            while (!float.TryParse(dec, out valeurconverti))
            {
                Console.WriteLine("Saisie Incorrecte : le nom de la saisie n'est pas valide ");
                dec = Console.ReadLine();
            }


            return valeurconverti;
        }

        public static string demande_ville()
        {
            Console.WriteLine("quel est le nom de cette nouvelle ville ?");
            string Ville = Console.ReadLine();

            while (string.IsNullOrEmpty(Ville))
            {
                Console.WriteLine("Saisie Incorrecte: le nom de la ville ne doit pas être vide ");
                Ville = Console.ReadLine();
            }

            return Ville;


        }

    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using MyApp.Service;
namespace MyApp
{
    class Program
    {
            private static DemandeALutilisateur _DemandeALutilisateur = new DemandeALutilisateur();
        static void Main(string[] args)
        {
            DemandeALutilisateur _DemandeALutilisateur = new DemandeALutilisateur();
            DepartementService _DepartementService = new DepartementService(_DemandeALutilisateur);
            CommuneService _CommuneService = new CommuneService(_DemandeALutilisateur,_DepartementService);
            HabitantService _HabitanService = new HabitantService(_DemandeALutilisateur, _CommuneService);



            List<Commune> listcommune = new List<Commune>();

            while (true)
            {
                
                string choixUtilisateur = MenuUtilisateur();

                if (choixUtilisateur == "1")
                {
                    _DepartementService.CreeDepartement();

                }
                else if (choixUtilisateur == "2")
                {
                    
                }
                else if (choixUtilisateur == "3")
                {
                    
                }
                else if (choixUtilisateur == "4")
                {

                }
                else if (choixUtilisateur == "5")
                {
                   
                }
                else if (choixUtilisateur == "Q")
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

        private static string MenuUtilisateur()
        {
            Console.WriteLine("Que voulez-vous faire ?");
            Console.WriteLine("1. Créer une personne");
            Console.WriteLine("2. Afficher la liste des personnes");
            Console.WriteLine("3. Créer une matière");
            Console.WriteLine("4. Afficher les matières");
            Console.WriteLine("5. Créer une salle");
            Console.WriteLine("Q. Quitter");
            string choixUtilisateur = _DemandeALutilisateur.saisieNom("");
            return choixUtilisateur;
        }




        public static void affiche(List<Commune> listcommunes)
        {
            Console.WriteLine("Liste des communes créées:");
            foreach(Commune c in listcommunes)
            {
                var culture = CultureInfo.GetCultureInfo("en-GB");
                string nb = string.Format(culture,"{0:n0}", c.NbHab);
                nb = nb.Replace(",", ".");
                string message_p1 = "Nom: " + c.Nom + " Code Postal: " + c.CodePost;
                string message_p2 = "Nombre d'habitants: " + nb;
                Console.WriteLine(message_p1);
                Console.WriteLine(message_p2);
            }
        }
        
        public static void calculNbtotalHabs(List<Commune> listcommunes)
        {
            int Nbtot = 0;
            foreach (Commune c in listcommunes)
            {
                Nbtot = Nbtot + c.NbHab;
            }
            var culture = CultureInfo.GetCultureInfo("en-GB");
            string nb = string.Format(culture,"{0:n0}", Nbtot);
            nb = nb.Replace(",", ".");
            string message = "Nombre total d'habitants: " + nb;        
            Console.WriteLine(message);
        }
    }
}

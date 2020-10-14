using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MyApp.Services
{
    public class DepartementServices
    {
        private DemandeALutilisateur _demandeALutilisateur;

        public DepartementServices(DemandeALutilisateur demandealutilisateur)
        {
            this._demandeALutilisateur = demandealutilisateur;
        }
        public Departement ajouterDepartement()
        {
            Departement d = new Departement();
            d.nom = _demandeALutilisateur.saisieNom("Saisissez le nom de votre departement");
            d.numD = _demandeALutilisateur.saisieEntier("Saisissez le code du departement");

            return d;
        }
        public void calculNbtotalHabs(List<Commune> listcommunes)
        {
            int Nbtot = 0;
            foreach (Commune c in listcommunes)
            {
                Nbtot = Nbtot + c.NbHab;
            }
            var culture = CultureInfo.GetCultureInfo("en-GB");
            string nb = string.Format(culture, "{0:n0}", Nbtot);
            nb = nb.Replace(",", ".");
            string message = "Nombre total d'habitants: " + nb;
            Console.WriteLine(message);
        }

        public void afficheDepartement(List<Departement> listdepartement, List<Commune>listecommune)
        {
            Console.WriteLine("Departements:");
            foreach (Departement d in listdepartement)
            {
                string message = "Nom: " + d.nom + ", code: " + d.numD;
                Console.WriteLine(message);
            }
            Console.WriteLine("commune:");
            foreach(Commune c in listecommune)
            {
                 string message_p1 = "Nom: " + c.Nom + " Code Postal: " + c.CodePost;
                string message_p2 = "Nombre d'habitants: " + c.NbHab;
                Console.WriteLine(message_p1);
                Console.WriteLine(message_p2);
            }
        }
    }
}
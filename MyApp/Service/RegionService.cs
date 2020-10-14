using MyApp.Model;
using MyApp.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MyApp.Service
{
    public class RegionService
    {
        private DemandeALutilisateur _DemandeALutilisateur;
        private DepartementServices _departementServices;
        private CommuneService _CommuneService;

        public RegionService(DemandeALutilisateur demandealutilisateur, DepartementServices departementServices, CommuneService communeService)
        {
            this._DemandeALutilisateur = demandealutilisateur;
            this._departementServices = departementServices;
            this._CommuneService = communeService;
        }
        public Region ajouterRegion()
        {
            Region r = new Region();
            r.nomR = _DemandeALutilisateur.saisieNom("Saisissez le nom de votre region");
            r.codeR = _DemandeALutilisateur.saisieEntier("Saisissez le code du region");

            return r;
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
        public void afficheRegion(List<Departement> listdepartement, List<Commune> listecommune, List<Region> listregion)
        {
            Console.WriteLine("Departements:");
            foreach(Region r in listregion)
            {
                string message = "Nom: " + r.nomR + ", code: " + r.codeR;
                Console.WriteLine(message);
            }
            Console.WriteLine("commune:");
            foreach (Departement d in listdepartement)
            {
                string message = "Nom: " + d.nom + ", code: " + d.numD;
                Console.WriteLine(message);
            }
            Console.WriteLine("commune:");
            foreach (Commune c in listecommune)
            {
                string message_p1 = "Nom: " + c.Nom + " Code Postal: " + c.CodePost;
                string message_p2 = "Nombre d'habitants: " + c.NbHab;
                Console.WriteLine(message_p1);
                Console.WriteLine(message_p2);
            }
        }
    }
}

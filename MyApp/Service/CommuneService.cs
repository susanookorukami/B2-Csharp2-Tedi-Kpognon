using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using MyApp.Model;

namespace MyApp.Services
{
    public class CommuneService
    {

        private DemandeALutilisateur _demandeALutilisateur;
        private DepartementServices _departementServices;

        public CommuneService(DemandeALutilisateur demandealutilisateur, DepartementServices departementServices)
        {
            this._demandeALutilisateur = demandealutilisateur;
            this._departementServices = departementServices;
        }
        public Commune ajouterCommune()
        {
            
            Commune c = new Commune();
            c.Nom = _demandeALutilisateur.saisieNom("Quel est le nom de votre ville ?");
            c.CodePost = _demandeALutilisateur.saisieEntier("Quel est de code postal ?");
            c.NbHab = _demandeALutilisateur.saisieEntier("Combie y a-t-il d'habitants ?");
            

            


            return c;
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
        public void affiche(List<Commune> listcommunes, List<Departement> listdepartement)
        {
            Console.WriteLine("Liste des communes créées:");
            

            foreach (Commune c in listcommunes)
            {
                var culture = CultureInfo.GetCultureInfo("en-GB");
                string nb = string.Format(culture, "{0:n0}", c.NbHab);
                nb = nb.Replace(",", ".");
                string message_p1 = "Nom: " + c.Nom + " Code Postal: " + c.CodePost;
                string message_p2 = "Nombre d'habitants: " + nb;
                Console.WriteLine(message_p1);
                Console.WriteLine(message_p2);
            }
            Console.WriteLine("Departements:");
            foreach (Departement d in listdepartement)
            {
                string message = "Nom: " + d.nom + ", code: " + d.numD;
                Console.WriteLine(message);
            }

        }
    }
}

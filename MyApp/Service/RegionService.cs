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
    }
}

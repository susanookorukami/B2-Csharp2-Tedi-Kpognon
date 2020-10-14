using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Model
{
    public class Region
    {
        public int codeR;
        public string nomR;

        public List<Commune> Communes { get; set; }
        public List<Departement> Departements { get; set; }

    }
}

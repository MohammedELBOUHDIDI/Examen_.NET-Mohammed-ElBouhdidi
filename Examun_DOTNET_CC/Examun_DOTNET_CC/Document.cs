using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examun_DOTNET_CC
{
    public abstract class Document
    {
        public Guid id { get; set; }
        public String Titre { get; set; }
        public String Auteur { get; set; }
        public int Annee { get; set; }

        public Document(string titre, string auteur, int annee)
        {
            this.id = Guid.NewGuid();
            this.Titre = titre;
            this.Auteur = auteur;
            this.Annee = annee;
        }
        public abstract void AfficherDetails();
    }
}

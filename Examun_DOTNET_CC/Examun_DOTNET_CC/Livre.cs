using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examun_DOTNET_CC
{
    public class Livre : Document
    {
        public int Nb_pages { get; set; }

        public Livre(string titre, string auteur, int annee, int nombrePages)
            : base(titre, auteur, annee)
        {
            this.Nb_pages = nombrePages;
        }

        public override void AfficherDetails()
        {
            Console.Write("le titre de livre est"+ this.Titre+"\n");
            Console.Write("l'auteur de ce livre est"+ this.Auteur + "\n");
            Console.Write("L'annee de redaction du livre est"+ this.Annee + "\n");
            Console.Write("le nombre de page dans le livre est"+ this.Nb_pages + "\n");

        }
    }
}

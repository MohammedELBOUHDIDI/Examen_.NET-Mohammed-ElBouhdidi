using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examun_DOTNET_CC
{
    public class DocumentPDF : Document
    {
        public int TailleEnMo { get; set; }

        public DocumentPDF (string titre, string auteur, int annee, int nombre)
            : base(titre, auteur, annee)
        {
            this.TailleEnMo = nombre;
        }

        public override void AfficherDetails()
        {
            Console.Write("le titre de PDF est"+ this.Titre + "\n");
            Console.Write("l'auteur de ce PDF est"+this.Auteur + "\n");
            Console.Write("L'annee de redaction du PDF est"+ this.Annee + "\n");
            Console.Write("le nombre de mot dans le PDF est"+this.TailleEnMo + "\n");

        }
    }
}

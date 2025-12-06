using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examun_DOTNET_CC
{
    public class Magazine : Document
    {
        public int Numero { get; set; }

        public Magazine(string titre, string auteur, int annee, int nombre)
            : base(titre, auteur, annee)
        {
            this.Numero = nombre;
        }

        public override void AfficherDetails()
        {
            Console.Write("le titre de magazine est" + this.Titre + "\n");
            Console.Write("l'auteur de ce magazine est" + this.Auteur + "\n");
            Console.Write("L'annee de redaction du magazine est" + this.Annee + "\n");
            Console.Write("le numero de magazine est" + this.Numero + "\n");

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examun_DOTNET_CC
{
    public class Bibliotheques
    {
        public List<Document> documents = new List<Document>();
        public void AjouterDocument(Document d)
        {
            documents.Add(d);
        }

        public void SupprimerDocument(Guid id)
        {
            try
            {
                bool trouvé = false;

                for (int i = 0; i < documents.Count; i++)
                {
                    if (documents[i].id == id)
                    {
                        documents.RemoveAt(i);
                        trouvé = true;
                        Console.WriteLine($" Document {id} supprimé avec succès.");
                        break;
                    }
                }

                if (!trouvé)
                {
                    throw new DocumentNonTrouveException($"Le document avec l'ID {id} n'a pas été trouvé.");
                }
            }
            catch (DocumentNonTrouveException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Rechercher(String MotCle)
        {
            foreach (Document d in documents)
            {
                if (d.Titre == MotCle)
                {
                    d.AfficherDetails();

                }
                else if (d.Auteur == MotCle)
                {
                    d.AfficherDetails();
                }
                else
                {
                    throw new DocumentNonTrouveException($"Le document n'existe pas dans la bibliotheque");
                }
            }

        }

        public void AfficherTous()
        {
            foreach (Document d in documents)
            {
                d.AfficherDetails();
            }
        }

        public void Sauvegarder(string cheminFichier)
        {
            using (FileStream fs = new FileStream(cheminFichier, FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                foreach (var doc in documents)
                {
                    if (doc is Livre livre)
                    {
                        string ligneCSV =
                        $"Livre;" +
                        $"{livre.id};" +
                        $"{livre.Titre};" +
                        $"{livre.Auteur};" +
                        $"{livre.Annee};" +
                        $"{livre.Nb_pages}";
                        sw.WriteLine(ligneCSV);
                    }
                    if (doc is Magazine magazine)
                    {
                        string ligneCSV =
                            $"Magazine;" +
                            $"{magazine.id};" +
                            $"{magazine.Titre};" +
                            $"{magazine.Auteur};" +
                            $"{magazine.Annee};" +
                            $"{magazine.Numero}";

                        sw.WriteLine(ligneCSV);
                    }
                    if (doc is DocumentPDF pdf)
                    {
                        string ligneCSV =
                            $"DocumentPDF;" +
                            $"{pdf.id};" +
                            $"{pdf.Titre};" +
                            $"{pdf.Auteur};" +
                            $"{pdf.Annee};" +
                            $"{pdf.TailleEnMo}";
                        sw.WriteLine(ligneCSV);

                    }
                }
            }
        }

        public void Charger(string cheminFichier)
        {
            try
            {
                //Partie3: 3-"using" s’occupe déjà de libérer le stream automatiquement, donc Dispose() n’est pas nécessaire.
                using (StreamReader sr = new StreamReader(cheminFichier))
                {
                    string ligne;

                    
                    while ((ligne = sr.ReadLine()) != null)
                    {
                        try
                        {
                            
                            string[] data = ligne.Split(';');

                            if (data.Length < 5)
                                throw new FormatException("Format CSV incorrect.");

                            string typeDoc = data[0];
                            Guid id = Guid.Parse(data[1]);
                            string titre = data[2];
                            string auteur = data[3];
                            int annee = int.Parse(data[4]);

                            Document doc = null;
                            switch (typeDoc)
                            {
                                case "Livre":
                                    if (data.Length != 6) throw new FormatException("Format Livre incorrect.");
                                    int nbPages = int.Parse(data[5]);
                                    doc = new Livre(titre, auteur, annee, nbPages);
                                    break;

                                case "Magazine":
                                    if (data.Length != 6) throw new FormatException("Format Magazine incorrect.");
                                    int numero = int.Parse(data[5]);
                                    doc = new Magazine(titre, auteur, annee, numero);
                                    break;

                                case "DocumentPDF":
                                    if (data.Length != 6) throw new FormatException("Format DocumentPDF incorrect.");
                                    int taille = int.Parse(data[5]);
                                    doc = new DocumentPDF( titre, auteur, annee, taille);
                                    break;

                                default:
                                    throw new Exception($"Type de document inconnu : {typeDoc}");
                            }
                            documents.Add(doc);
                        }
                        catch (FormatException fe)
                        {
                            Console.WriteLine($" Ligne ignorée (format incorrect) : {fe.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Erreur lors du chargement d'une ligne : {ex.Message}");
                        }
                    }
                }

                Console.WriteLine("Bibliothèque chargée avec succès.");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($" ERREUR : Fichier non trouvé. {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($" ERREUR d'accès au fichier : {ex.Message}");
            }
        }
    }
}

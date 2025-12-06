using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examun_DOTNET_CC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Message d'introduction personnalisé
            Console.WriteLine("Bienvenue dans la bibliothèque !");
            Console.WriteLine("Réalisé par : Mohammed Elbouhdidi\n");
            Bibliotheques maBibliotheque = new Bibliotheques();
            bool quitter = false;

            while (!quitter)
            {
                //menu
                Console.WriteLine("\n--- Menu Bibliothèque ---");
                Console.WriteLine("1. Ajouter un document");
                Console.WriteLine("2. Afficher tous les documents");
                Console.WriteLine("3. Rechercher par mot-clé");
                Console.WriteLine("4. Supprimer un document");
                Console.WriteLine("5. Sauvegarder dans un fichier");
                Console.WriteLine("6. Charger depuis un fichier");
                Console.WriteLine("7. Quitter");

                Console.Write("Choisissez une option : ");
                string choix = Console.ReadLine();
                try
                {
                    switch (choix)
                    {
                        // 1. AJOUTER UN DOCUMENT
                        case "1":
                            Console.WriteLine("\nQuel type de document souhaitez-vous ajouter ?");
                            Console.WriteLine("1. Livre");
                            Console.WriteLine("2. Magazine");
                            Console.WriteLine("3. Document PDF");
                            Console.Write("Votre choix : ");
                            string type = Console.ReadLine();

                            Console.Write("Titre : ");
                            string titre = Console.ReadLine();

                            Console.Write("Auteur : ");
                            string auteur = Console.ReadLine();

                            Console.Write("Année : ");
                            int annee = int.Parse(Console.ReadLine());

                            Document doc = null;

                            if (type == "1")
                            {
                                Console.Write("Nombre de pages : ");
                                int pages = int.Parse(Console.ReadLine());
                                doc = new Livre(titre, auteur, annee, pages);
                            }
                            else if (type == "2")
                            {
                                Console.Write("Numéro du magazine : ");
                                int numero = int.Parse(Console.ReadLine());
                                doc = new Magazine(titre, auteur, annee, numero);
                            }
                            else if (type == "3")
                            {
                                Console.Write("Taille (Mo) : ");
                                int taille = int.Parse(Console.ReadLine());
                                doc = new DocumentPDF(titre, auteur, annee, taille);
                            }
                            else
                            {
                                Console.WriteLine("Type invalide.");
                                break;
                            }

                            maBibliotheque.AjouterDocument(doc);
                            Console.WriteLine("✔ Document ajouté avec succès par Elbouhdidi_Mohammed.");
                            break;

                        // 2. AFFICHER TOUS
                        case "2":
                            Console.WriteLine("\n--- Liste des documents (Elbouhdidi_Mohammed) ---");
                            maBibliotheque.AfficherTous();
                            break;

                        // 3. RECHERCHER
                        case "3":
                            Console.Write("Mot-clé : ");
                            string mot = Console.ReadLine();
                            Console.WriteLine($"\nRésultats de recherche par Elbouhdidi_Mohammed :");
                            maBibliotheque.Rechercher(mot);
                            break;

                        // 4. SUPPRIMER
                        case "4":
                            Console.Write("Entrez l'ID à supprimer : ");
                            Guid idASupprimer = Guid.Parse(Console.ReadLine());
                            maBibliotheque.SupprimerDocument(idASupprimer);
                            Console.WriteLine("Document supprimé par Elbouhdidi_Mohammed.");
                            break;

                        // 5. SAUVEGARDER
                        case "5":
                            Console.Write("Chemin du fichier : ");
                            string cheminS = Console.ReadLine();
                            maBibliotheque.Sauvegarder(cheminS);
                            Console.WriteLine("Sauvegarde terminée par Elbouhdidi_Mohammed.");
                            break;

                        // 6. CHARGER
                        case "6":
                            Console.Write("Chemin du fichier : ");
                            string cheminC = Console.ReadLine();
                            maBibliotheque.Charger(cheminC);
                            Console.WriteLine("Chargement effectué par Elbouhdidi_Mohammed.");
                            break;

                        // 7. QUITTER
                        case "7":
                            quitter = true;
                            Console.WriteLine("Au revoir !");
                            break;

                        default:
                            Console.WriteLine("Choix invalide.");
                            break;
                    }
                }
                catch (DocumentNonTrouveException ex)
                {
                    Console.WriteLine($"Erreur : {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Une erreur est survenue : {ex.Message}");
                }
            }
        }
    }

}

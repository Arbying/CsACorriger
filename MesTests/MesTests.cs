using System;
using Modele;

namespace MesTest
{
    public class MesTests
    {
        public static void Main()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("Tests Personnes");
            Console.WriteLine("**********************************");

            // Création d'instances de la classe Personne avec les noms Banushi et Reinders
            Personne personne1 = new Personne("Banushi", "Arber", new DateTime(2000, 1, 1));
            Personne personne2 = new Personne("Reinders", "Sébastient", new DateTime(1995, 5, 23));

            // Affichage des informations de ces personnes
            Console.WriteLine(personne1.ToString());
            Console.WriteLine(personne2.ToString());

            // Modification des informations de la personne1
            personne1.Prenom = "Pimousse";
            personne1.DateNaissance = new DateTime(1995, 2, 28);

            // Affichage de la nouvelle information de la personne1
            Console.WriteLine(personne1.ToString());

            // Comparaison de deux personnes
            if (personne1.Equals(personne2))
            {
                Console.WriteLine("Les personnes sont identiques.");
            }
            else
            {
                Console.WriteLine("Les personnes sont différentes.");
            }

            // Test de la méthode SaveUnXML
            personne1.SaveUnXML("personne1");
            Console.WriteLine("La personne1 a été enregistrée avec succès en XML.");

            // Test de la méthode LoadUnXML
            Personne personneLoadedFromXML = Personne.LoadUnXML("personne1");
            Console.WriteLine("Personne chargée à partir du XML : " + personneLoadedFromXML.ToString());

            // Test de la méthode SaveVecXML
            List<Personne> personnes = new List<Personne>() { personne1, personne2 };
            Personne.SaveVecXML("personnes", personnes);
            Console.WriteLine("La liste des personnes a été enregistrée avec succès en XML.");

            // Test de la méthode LoadVecXML
            List<Personne> loadedPersonnesFromXML = Personne.LoadVecXML("personnes");
            Console.WriteLine("Personnes chargées à partir du XML : ");
            foreach (Personne p in loadedPersonnesFromXML)
            {
                Console.WriteLine(p.ToString());
            }

            // Test de la méthode AjoutVecXML
            Personne personne3 = new Personne("Anna", "Conda", new DateTime(1985, 6, 30));
            Personne.AjoutVecXML("personnes", personne3);
            Console.WriteLine("La personne3 a été ajoutée avec succès à la liste des personnes dans le XML.");

            // Recharger la liste pour vérifier l'ajout
            loadedPersonnesFromXML = Personne.LoadVecXML("personnes");
            Console.WriteLine("Personnes chargées à partir du XML après l'ajout : ");
            foreach (Personne p in loadedPersonnesFromXML)
            {
                Console.WriteLine(p.ToString());
            }



            Console.WriteLine();

            Console.WriteLine("**********************************");
            Console.WriteLine("Tests Caissiers");
            Console.WriteLine("**********************************");

            // Création d'instances de la classe Caissier avec les mêmes noms et prénoms que précédemment
            Caissier caissier1 = new Caissier("Banushi", "Arber", new DateTime(2000, 1, 1), 1, 1234, 100.0f);
            Caissier caissier2 = new Caissier("Reinders", "Sébastient", new DateTime(1995, 5, 23), 2, 5678, 200.0f);

            // Affichage des informations de ces caissiers
            Console.WriteLine(caissier1.ToString());
            Console.WriteLine(caissier2.ToString());

            // Modification des informations de caissier1
            caissier1.Prenom = "Pimousse";
            caissier1.DateNaissance = new DateTime(1995, 2, 28);
            caissier1.MDP = 4321;
            caissier1.TotalVentes = 150.0f;

            // Affichage de la nouvelle information de caissier1
            Console.WriteLine(caissier1.ToString());

            // Comparaison de deux caissiers
            if (caissier1.Equals(caissier2))
            {
                Console.WriteLine("Les caissiers sont identiques.");
            }
            else
            {
                Console.WriteLine("Les caissiers sont différents.");
            }

            // Sauvegarde d'une instance de Caissier dans un fichier XML
            caissier1.SaveUnXML("Caissier1");

            // Chargement d'une instance de Caissier depuis un fichier XML
            Caissier loadedCaissier = Caissier.LoadUnXML("Caissier1");

            // Affichage de l'information du caissier chargé pour vérifier que les données ont été correctement chargées
            Console.WriteLine(loadedCaissier.ToString());

            // Création d'une liste de Caissier et sauvegarde dans un fichier XML
            List<Caissier> caissiers = new List<Caissier> { caissier1, caissier2 };
            Caissier.SaveVecXML("Caissiers", caissiers);

            // Chargement d'une liste de Caissier depuis un fichier XML
            List<Caissier> loadedCaissiers = Caissier.LoadVecXML("Caissiers");

            // Affichage des informations des caissiers chargés pour vérifier que les données ont été correctement chargées
            foreach (Caissier c in loadedCaissiers)
            {
                Console.WriteLine(c.ToString());
            }

            // Ajout d'une nouvelle instance de Caissier à la liste dans le fichier XML
            Caissier caissier3 = new Caissier("Pit", "Hon", new DateTime(1990, 12, 12), 3, 9876, 250.0f);
            Caissier.AjoutVecXML("Caissiers", caissier3);

            // Rechargement et affichage de la liste de Caissier depuis le fichier XML pour vérifier que le nouveau caissier a été ajouté
            loadedCaissiers = Caissier.LoadVecXML("Caissiers");
            foreach (Caissier c in loadedCaissiers)
            {
                Console.WriteLine(c.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("**********************************");
            Console.WriteLine("Tests Gérants");
            Console.WriteLine("**********************************");

            // Création d'instances de la classe Gerant avec les mêmes noms et prénoms que précédemment
            Gerant gerant1 = new("Banushi", "Arber", new DateTime(2000, 1, 1), 1, 1234, 500.0f);
            Gerant gerant2 = new Gerant("Reinders", "Sébastient", new DateTime(1995, 5, 23), 2, 5678, 1000.0f);

            // Affichage des informations de ces gérants
            Console.WriteLine(gerant1.ToString());
            Console.WriteLine(gerant2.ToString());

            // Modification des informations de gerant1
            gerant1.Prenom = "Pimousse";
            gerant1.DateNaissance = new DateTime(1995, 2, 28);
            gerant1.MDP = 4321;
            gerant1.Bonus = 750.0f;

            // Affichage de la nouvelle information de gerant1
            Console.WriteLine(gerant1.ToString());

            // Comparaison de deux gérants
            if (gerant1.Equals(gerant2))
            {
                Console.WriteLine("Les gérants sont identiques.");
            }
            else
            {
                Console.WriteLine("Les gérants sont différents.");
            }

            Console.WriteLine();
            Console.WriteLine("**********************************");
            Console.WriteLine("Tests Article");
            Console.WriteLine("**********************************\n");

            // Test de l'égalité entre deux articles
            Article article1 = new Article(1234567890123, "Chocolat noir bio", 2.5f, 5, 10);
            Article article2 = new Article(1234567890123, "Chocolat noir bio", 2.5f, 5, 10);
            Console.WriteLine("Test d'égalité entre deux articles :");
            Console.WriteLine(article1.ToString());
            Console.WriteLine(article2.ToString());
            Console.WriteLine("Résultat du test : " + article1.Equals(article2) + "\n");

            // Test de l'affichage d'un article
            Article article3 = new Article(7890123456789, "Lait écrémé bio", 1.2f, 2, 20);
            Console.WriteLine("Test d'affichage d'un article :");
            Console.WriteLine(article3.ToString() + "\n");

            // Test de modification de la quantité d'un article
            Console.WriteLine("Test de modification de la quantité d'un article :");
            Article article4 = new Article(1111111111111, "Eau minérale naturelle", 0.5f, 1, 5);
            Console.WriteLine("Quantité initiale : " + article4.Quantite);
            article4.Quantite = 10;
            Console.WriteLine("Quantité modifiée : " + article4.Quantite + "\n");

            Console.WriteLine();
            Console.WriteLine("**********************************");
            Console.WriteLine("Tests MesArticles");
            Console.WriteLine("**********************************\n");

            // Test d'égalité entre deux mes articles
            Article article5 = new Article(1234567890123, "Chocolat noir bio", 2.5f, 5, 10);
            Article article6 = new Article(1234567890123, "Chocolat noir bio", 2.5f, 5, 10);
            MesArticles mesArticles5 = new MesArticles(2, article5, 5.0f);
            MesArticles mesArticles6 = new MesArticles(2, article6, 5.0f);
            Console.WriteLine("Test d'égalité entre deux mes articles :");
            Console.WriteLine(mesArticles5.ToString());
            Console.WriteLine(mesArticles6.ToString());
            Console.WriteLine("Résultat du test : " + mesArticles5.Equals(mesArticles6) + "\n");

            // Test d'affichage d'un mes article
            Article article7 = new Article(7890123456789, "Lait écrémé bio", 1.2f, 2, 20);
            MesArticles mesArticles7 = new MesArticles(3, article7, 3.6f);
            Console.WriteLine("Test d'affichage d'un mes article :");
            Console.WriteLine(mesArticles7.ToString() + "\n");

            // Test de modification de la quantité d'un mes article
            Console.WriteLine("Test de modification de la quantité d'un mes article :");
            Article article8 = new Article(1111111111111, "Eau minérale naturelle", 0.5f, 1, 5);
            MesArticles mesArticles8 = new MesArticles(1, article8, 0.5f);
            Console.WriteLine("Quantité initiale : " + mesArticles8.Qu);
            mesArticles8.Qu = 5;
            Console.WriteLine("Quantité modifiée : " + mesArticles8.Qu + "\n");

            Console.WriteLine("**********************************");
            Console.WriteLine("Tests Client");
            Console.WriteLine("**********************************");

            // Tests avec constructeur par défaut
            Client client1 = new Client();
            Client client2 = new Client();
            Console.WriteLine(client1.Equals(client2)); // True

            // Tests avec constructeur avec paramètres
            Client client3 = new Client("Banushi", "Arber", new DateTime(2000, 1, 1), 1, 1234567890, 10);
            Client client4 = new Client("Reinders", "Sébastien", new DateTime(1990, 12, 31), 2, 9876543210, 20);
            Console.WriteLine(client3.Equals(client4)); // False
            Console.WriteLine(client3.Equals(new Client("Banushi", "Arber", new DateTime(2000, 1, 1), 1, 1234567890, 10)));// True

            // Tests accesseurs
            Console.WriteLine(client3.CarteFidelite); // 1234567890
            Console.WriteLine(client4.Points); // 20

            // Tests méthode ToString
            Console.WriteLine(client3.ToString()); // Banushi Arber (01/01/2000) - Client (Carte de fidélité : 1234567890, Points de fidélité : 10)
            Console.WriteLine(client4.ToString()); // Reinders Sébastien (31/12/1990) - Client (Carte de fidélité : 9876543210, Points de fidélité : 20)





            // Tests de la classe Ticket
            Console.WriteLine();
            Console.WriteLine("**********************************");
            Console.WriteLine("Tests Ticket");
            Console.WriteLine("**********************************");

            Client aaaClient = new Client("Banushi", "Arber", new DateTime(2000, 1, 1),50, 1234567890, 100);
            Caissier aaaCaissier = new Caissier("Reinders", "Sébastient", new DateTime(1990, 2, 2), 234567890, 4321, 500.0f);

            Article article15 = new Article(5400000000004, "Article 5", 10.0f, 10, 50);
            Article article16 = new Article(5400000000005, "Article 6", 20.0f, 20, 25);
            Article article17 = new Article(5400000000006, "Article 7", 30.0f, 30, 15);

            MesArticles mesArticles11 = new MesArticles(2, article15, 20.0f);
            MesArticles mesArticles12 = new MesArticles(1, article16, 20.0f);
            MesArticles mesArticles23 = new MesArticles(3, article17, 90.0f);

            List<MesArticles> articlesEnCours = new List<MesArticles>();
            articlesEnCours.Add(mesArticles11);
            articlesEnCours.Add(mesArticles12);
            articlesEnCours.Add(mesArticles23);

            Ticket aaaTicket = new Ticket(10, aaaClient, aaaCaissier);
            aaaTicket.ArticlesEnCours = articlesEnCours;

            // Test du calcul du total
            if (aaaTicket.CalculerTotal() == 130.0f)
            {
                Console.WriteLine("Test CalculerTotal de la classe Ticket : OK");
            }
            else
            {
                Console.WriteLine("Test CalculerTotal de la classe Ticket : ERREUR");
            }

            // Test de la méthode ToString
            string expectedTicketString = "Date : " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "\n";
            expectedTicketString += "Ticket n°10\n";
            expectedTicketString += "Client : Banushi Arber (Carte de fidélité : 1234567890, 100 points)\n";
            expectedTicketString += "Caissier : Reinders Sébastient - Caissier (Intervenant n° 234567890, MDP : 4321, Total des ventes : 500)\n";
            expectedTicketString += "Articles :\n";
            expectedTicketString += "   2 x Article 5 (Prix : 10€, Points : 10, Quantité : 50) = 20€\n";
            expectedTicketString += "   1 x Article 6 (Prix : 20€, Points : 20, Quantité : 25) = 20€\n";
            expectedTicketString += "   3 x Article 7 (Prix : 30€, Points : 30, Quantité : 15) = 90€\n";
            expectedTicketString += "Total : 130€\n";

            if (aaaTicket.ToString() == expectedTicketString)
            {
                Console.WriteLine("Test ToString de la classe Ticket : OK");
            }
            else
            {
                Console.WriteLine("Test ToString de la classe Ticket : ERREUR");
            }


            Console.ReadLine();

        }
    }
}

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Bienvenue au jeu de devinettes !");
            int nombreATrouver, bornesInf, bornesSup, tentatives = 0;
            double note = 0;
            List<int> choixFaits = new List<int>();

            // Étape 3 : Définir les bornes
            Console.Write("Entrez la borne inférieure : ");
            bornesInf = LireEntierAvecException();
            Console.Write("Entrez la borne supérieure : ");
            bornesSup = LireEntierAvecException();

            if (bornesInf >= bornesSup)
            {
                throw new ArgumentException("La borne inférieure doit être inférieure à la borne supérieure !");
            }

            // Génération d'un nombre aléatoire à trouver
            Random random = new Random();
            nombreATrouver = random.Next(bornesInf, bornesSup + 1);

            Console.WriteLine($"Devinez un nombre entre {bornesInf} et {bornesSup}.");

            while (true)
            {
                try
                {
                    Console.Write("Votre choix : ");
                    int choix = LireEntierAvecException();

                    if (choix < bornesInf || choix > bornesSup)
                    {
                        throw new ArgumentOutOfRangeException($"Saisissez un nombre compris entre {bornesInf} et {bornesSup}.");
                    }

                    tentatives++;
                    choixFaits.Add(choix);

                    if (choix == nombreATrouver)
                    {
                        Console.WriteLine("Vous avez gagné !");
                        note = (double)(bornesSup - bornesInf + 1) / tentatives;
                        Console.WriteLine($"Nombre de tentatives : {tentatives}");
                        Console.WriteLine($"Votre note : {note:F2}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Vous avez perdu. Essayez encore !");
                    }

                    Console.WriteLine("Vos choix précédents : " + string.Join(", ", choixFaits));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur : {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur initiale : {ex.Message}");
        }
    }

    // Méthode pour lire un entier avec exception
    static int LireEntierAvecException()
    {
        if (!int.TryParse(Console.ReadLine(), out int resultat))
        {
            throw new FormatException("Veuillez entrer un nombre entier valide.");
        }
        return resultat;
    }
}

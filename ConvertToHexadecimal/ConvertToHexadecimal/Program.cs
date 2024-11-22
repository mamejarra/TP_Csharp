namespace ConvertToHexadecimal
{
    internal class Program
    {
        // Méthode pour convertir un entier en hexadécimal
        static string ConvertToHexadecimal(int number)
        {
            if (number == 0) return "0";

            string hexChars = "0123456789ABCDEF"; // Table de caractères hexadécimaux
            string hexadecimal = "";

            while (number > 0)
            {
                int remainder = number % 16; // Reste de la division par 16
                hexadecimal = hexChars[remainder] + hexadecimal; // Ajouter le caractère correspondant
                number /= 16; // Réduire le nombre en divisant par 16
            }

            return hexadecimal;
        }

        static void Main()
        {
            // Liste pour stocker les conversions
            Dictionary<int, string> conversions = new Dictionary<int, string>();

            // Lire plusieurs entiers
            Console.WriteLine("Entrez les entiers à convertir (séparés par des espaces) :");
            string input = Console.ReadLine();
            string[] numbers = input.Split(' ');

            foreach (string num in numbers)
            {
                if (int.TryParse(num, out int number))
                {
                    string hexValue = ConvertToHexadecimal(number);
                    conversions[number] = hexValue; // Ajouter à la liste des conversions
                }
                else
                {
                    Console.WriteLine($"'{num}' n'est pas un entier valide ? Veuillez entrer un entier please");
                }
            }

            // Afficher les résultats
            Console.WriteLine("\nConversions des entiers en hexadécimal :");
            foreach (var entry in conversions)
            {
                Console.WriteLine($"Entier : {entry.Key} -> Hexadécimal : {entry.Value}");
            }
        }
    }
}

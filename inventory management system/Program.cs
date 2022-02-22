using System;
using static System.Environment;

namespace inventory_management_system
{
    class inventory_management_system
    {
        private static List<Article> Lager = new List<Article>();
        private new const String Abstandhalter = "\n--------------------------------------------------------------\n";

        static void Main(string[] args)
        {
            //Article List

            Lager.Add(new Article("Regal"));
            Lager.Add(new Article("Regal1"));
            Lager.Add(new Article("Regal2"));
            Lager.Add(new Article("Regal3"));
            Lager.Add(new Article("Regal4"));
            Lager.Add(new Article("Regal5"));
            Lager.Add(new Electronic("Smartphone1", 1000, 350, 10));


            while (true)
            {
                Lagerbestand();
            }
        }

        static void Lagerbestand()
        {
            Console.WriteLine("Lagerbestand:\n");

            for (int i = 0; i < Lager.Count; i++)
            {
                Console.WriteLine(Lager[i]);
            }

            Console.WriteLine($"{Abstandhalter}1) Verkaufen\t2) Wareneingang");

            switch (Console.ReadLine())
            {
                case "1":
                    Verkauf();
                    break;
                case "2":
                    Wareneingang();
                    break;
                default:
                    break;
            }
        }

        static void Verkauf()
        {
            int sellArtNr;
            int sellCount;
            string company, buyerName, compAdress, compMail;

            Console.WriteLine("Sell\n");


            do
            {
                Console.WriteLine("ArtNr: ");
            } while (!int.TryParse(Console.ReadLine(), out sellArtNr));

            //Does Article Exist?

            if (!Article.Exists(sellArtNr, Lager))
            {
                Console.WriteLine("Article does not exist!");
                return;
            }

            do
            {
                Console.WriteLine("Count: ");
            } while (!int.TryParse(Console.ReadLine(), out sellCount));

            //Count < available Count?

            if (!Article.CountAvailable(sellArtNr, sellCount, Lager))
            {
                Console.WriteLine("Not enough stock!");
                return;
            }

            Console.WriteLine($"{Article.getPrize(sellCount, sellArtNr, Lager)}$");

            Console.WriteLine("Contact info:\n");

            Console.WriteLine("Company:");
            company = Console.ReadLine();

            Console.WriteLine("\nName:");
            buyerName = Console.ReadLine();

            Console.WriteLine("\nAdress:");
            compAdress = Console.ReadLine();

            Console.WriteLine("\nE-Mail:");
            compMail = Console.ReadLine();

            Console.WriteLine("\n\n---------------------------------------------");
            Console.WriteLine("1) Done 2)Print Receipt");

            switch (Console.ReadLine())
            {
                case "2":
                    WriteReceipt(sellArtNr, sellCount, company, compAdress, buyerName, compMail, Lager, Article.getPrize(sellCount, sellArtNr, Lager));
                    break;
                default:
                    break;
            }

            Lager[sellArtNr-1].Count -= sellCount;
        }

        private static void WriteReceipt(int sellArtNr, int sellCount, string? company, string? compAdress, string? buyerName, string? compMail, List<Article> lager, double prize)
        {
            StreamWriter sw = new StreamWriter(getReceiptSavePath()+@"\receipt.txt");

            sw.WriteLine(company);
            sw.WriteLine(buyerName);
            sw.WriteLine(compAdress);
            sw.WriteLine(compMail + "\n");

            sw.WriteLine($"{sellCount}x {lager[sellArtNr-1].Name} NR: {lager[sellArtNr-1].getID():d5}\t{prize}$");

            sw.Close();

        }

        private static string getReceiptSavePath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        static void Wareneingang()
        {
            int count, price, power;
            string name;


            Console.WriteLine($"{Abstandhalter}1) neuer Artikel\t2) bestehender Artikel");

            if (Convert.ToInt32(Console.ReadLine()) == 1)
            {
                Console.WriteLine($"{Abstandhalter}Zu welcher Kategorie gehört der Artikel?\t1) Keiner\t2) Elektronik");

                if (Convert.ToInt32(Console.ReadLine())== 1)
                {
                    EingabeProperties_standart(out name, out count, out price);

                    Lager.Add(new Article(name, count, price));
                }
                else
                {
                    EingabeProperties_electronics(out name, out count, out price, out power);

                    Lager.Add(new Electronic(name, count, price, power));
                }
            }
            else
            {

            }
        }
        
        //Eingabe von einem normalen Artikel

        static void EingabeProperties_standart(out string name, out int count, out int price)
        {
            Console.Write("Name: ");        ////In Methode auslagern
            name = Console.ReadLine();

            Console.Write("Anzahl: ");
            int.TryParse(Console.ReadLine(), out count);

            Console.Write("Preis: ");
            int.TryParse(Console.ReadLine(), out price);


        }

        //Eingabe von einem Elektronik-Artikel

        static void EingabeProperties_electronics(out string name, out int count, out int price, out int power)
        {
            EingabeProperties_standart(out name, out count, out price);

            Console.Write("Stromverbrauch: ");

            do
            { } while (int.TryParse(Console.ReadLine(), out power));
        }

    }
}


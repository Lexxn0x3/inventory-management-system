﻿using System;
using static System.Environment;

namespace inventory_management_system
{
    class inventory_management_system
    {
        public static List<Article> list = new List<Article>();
        

        static void Main(string[] args)
        {
            //Article List

            list.Add(new Article("Regal"));
            list.Add(new Article("Regal1"));
            list.Add(new Article("Regal2"));
            list.Add(new Article("Regal3"));
            list.Add(new Article("Regal4"));
            list.Add(new Article("Regal5"));
            list.Add(new Electronic("Smartphone1", 1000, 350, 10));


            while (true)
            {
                Lagerbestand();
            }
        }

        static void Lagerbestand()
        {
            Console.WriteLine("Lagerbestand:\n");

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            Console.WriteLine($"{MyConstants.Abstandhalter}1) Verkaufen\t2) Wareneingang");

            switch (Console.ReadLine())
            {
                case "1":
                    Verkauf();
                    break;
                case "2":
                    WarenEingang.Eingang();
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

            if (!Article.Exists(sellArtNr, list))
            {
                Console.WriteLine("Article does not exist!");
                return;
            }

            do
            {
                Console.WriteLine("Count: ");
            } while (!int.TryParse(Console.ReadLine(), out sellCount));

            //Count < available Count?

            if (!Article.CountAvailable(sellArtNr, sellCount, list))
            {
                Console.WriteLine("Not enough stock!");
                return;
            }

            Console.WriteLine($"{Article.getPrize(sellCount, sellArtNr)}$");

            Console.WriteLine("Contact info:\n");

            company = Eingabe_String("Company");

            buyerName = Eingabe_String("buyerName");

            compAdress = Eingabe_String("Adresse");

            compMail = Eingabe_String("E-Mail");

            Console.WriteLine("\n\n---------------------------------------------");
            Console.WriteLine("1) Done 2)Print Receipt");

            switch (Console.ReadLine())
            {
                case "2":
                    WriteReceipt(sellArtNr, sellCount, company, compAdress, buyerName, compMail, list, Article.getPrize(sellCount, sellArtNr));
                    break;
                default:
                    break;
            }

            list[sellArtNr-1].Count -= sellCount;
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

        

        static string Eingabe_String(string Eingabetext)
        {
            Console.Write($"{Eingabetext}: ");
            string Eingabe = Console.ReadLine();

            return Eingabe;
        }

        static int Eingabe_Int(string Eingabetext)
        {
            int Eingabe;

            Console.WriteLine($"{Eingabetext}: ");
            do
            { } while (int.TryParse(Console.ReadLine(), out Eingabe));

            return Eingabe;
        }

    }
}


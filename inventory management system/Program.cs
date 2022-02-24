﻿using System;
using static System.Environment;

namespace inventory_management_system
{
    class Program
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
                Console.Clear();
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

            Console.WriteLine($"{ImsHelper.Abstandhalter}1) Verkaufen\t2) Wareneingang");

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
            string company, buyerName, compAddress, compMail;
            Article article;

            Console.WriteLine("Sell\n");

            do
            {
                Console.WriteLine("ArtNr: ");
            } while (!int.TryParse(Console.ReadLine(), out sellArtNr));

            //Does Article Exist?

            if (!Article.getArticleFromArtNr(sellArtNr, out article))
            {
                Console.WriteLine("Article does not exist!");
                return;
            }

            do
            {
                Console.WriteLine("Count: ");
            } while (!int.TryParse(Console.ReadLine(), out sellCount));

            //Count < available Count?

            if (!Article.CountAvailable(sellArtNr, sellCount))
            {
                Console.WriteLine("Not enough stock!");
                return;
            }

            Console.WriteLine($"{article.Price*sellCount}$");

            Console.WriteLine("Contact info:\n");

            company = ImsHelper.InputWithPrompt("Company: ");

            buyerName = ImsHelper.InputWithPrompt("Name: ");

            compAddress = ImsHelper.InputWithPrompt("Address: ");

            compMail = ImsHelper.InputWithPrompt("E-Mail: ");

            Console.WriteLine("\n\n---------------------------------------------");
            Console.WriteLine("1) Done    2) Print Receipt");

            switch (Console.ReadLine())
            {
                case "2":
                    Order newOrder = new Order(article, sellCount, company, compAddress, compMail, buyerName);
                    newOrder.WriteReceipt();
                    break;
                default:
                    break;
            }

            list[sellArtNr-1].Count -= sellCount;
        }
    }
}


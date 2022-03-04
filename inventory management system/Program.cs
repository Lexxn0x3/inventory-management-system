using System;
using static System.Environment;

namespace inventory_management_system
{
    class Program
    {
        public static List<Article> list = new List<Article>();
        
        static void Main(string[] args)
        {
            //Article List

            //list.Add(new Article("Regal"));
            //list.Add(new Article("Regal1"));
            //list.Add(new Article("Regal2"));
            //list.Add(new Article("Regal3"));
            //list.Add(new Article("Regal4"));
            //list.Add(new Article("Regal5"));
            //list.Add(new Electronic("Smartphone1", 1000, 350, 10));


            while (true)
            {
                Console.Clear();
                Inventory();
                Selection();
            }
        }

        private static void Selection()
        {
            Console.WriteLine($"{ImsHelper.stringSeperator}1) Verkaufen\t2) Wareneingang");

            switch (Console.ReadLine())
            {
                case "1":
                    Sell();
                    break;
                case "2":
                    ProductManagement.ReceiveProduct(list);
                    break;
                default:
                    break;
            }
        }

        static void Inventory()
        {
            Console.WriteLine("Lagerbestand:\n");

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        static void Sell()
        {
            int sellArtNr;
            int sellCount;
            string company, buyerName, compAddress, compMail;
            Article article;

            Console.WriteLine("Sell\n");

            do
            {
                Console.WriteLine("ArtNr: ");
            } 
            while (!int.TryParse(Console.ReadLine(), out sellArtNr));

            //Does Article Exist?

            if (!Article.GetArticleFromArtNr(sellArtNr, list, out article))
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

            Console.WriteLine($"{article.Price*sellCount}$");

            Console.WriteLine("Contact info:\n");

            company = ImsHelper.InputWithPrompt("Company: ");

            buyerName = ImsHelper.InputWithPrompt("Name: ");

            compAddress = ImsHelper.InputWithPrompt("Address: ");

            compMail = ImsHelper.InputWithPrompt("E-Mail: ");

            Console.Write(ImsHelper.stringSeperator);
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

            list[Article.GetArticleIndex(sellArtNr, list)].Count -= sellCount;
        }
    }
}


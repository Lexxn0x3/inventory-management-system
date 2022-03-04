namespace inventory_management_system
{
    internal class ProductManagement
    {
        //static int count, price, power;
        //static string name;

        public static void ReceiveProduct(List<Article> list)
        {
            int selection;

            do
            {
                Console.WriteLine($"{ImsHelper.stringSeperator}1) neuer Artikel\t2) bestehender Artikel");
            } 
            while (!int.TryParse(Console.ReadLine(), out selection));

            if (selection == 1)
            {
                NewProduct(list);
            }
            else
            {
                ExistingProduct(list);
            }
        }

        //neues Produkt

        static void NewProduct(List<Article> list)
        {
            string name;
            int count, price, power, selection;
            Article article;

            do
            {
                Console.WriteLine($"{ImsHelper.stringSeperator}Zu welcher Kategorie gehört der Artikel?\t1) Keiner\t2) Elektronik");
            } 
            while (!int.TryParse(Console.ReadLine(), out selection));

            switch (selection)
            {
                case 1:
                    GetProperties(out name, out count, out price);

                    article = new Article(name, count, price);
                    break;

                default:
                    GetProperties(out name, out count, out price, out power);

                    article = new Electronic(name, count, price, power);
                    break;
            }

            list.Add(article);
        }

        //vorhandenes Produkt

        static void ExistingProduct(List<Article> list)
        {
            int artnr;
            Article article;

            Console.WriteLine($"{ImsHelper.stringSeperator}");
            
            do 
            {
                artnr = ImsHelper.InputWithPromptInt("Wie lautet die Artikelnummer des Produktes");
            }
            while (!Article.GetArticleFromArtNr(artnr, list, out article));

            int selection = ImsHelper.InputWithPromptInt("Welchen Atribut möchten sie verändern?\t1) name\t2) addarticle\t3)price");

            switch (selection)
            {
                case 1:
                    article.Name = ImsHelper.InputWithPrompt("newname");
                    break;
                case 2:
                    article.Count += ImsHelper.InputWithPromptInt($"how many {article.Name} do you want to add?");
                    break;
                case 3:
                    article.Price = ImsHelper.InputWithPromptInt("newprice");
                    break;
                default:
                    ExistingProduct(list);
                    break;
            }

            list[Article.GetArticleIndex(artnr, list)] = article;
        }

        //Eingabe von einem normalen Artikel

        static void GetProperties(out string name, out int count, out int price)
        {
            name = ImsHelper.InputWithPrompt("name");

            count = ImsHelper.InputWithPromptInt("Anzahl");

            price = ImsHelper.InputWithPromptInt("Preis");
        }

        //Eingabe von einem Elektronik-Artikel

        static void GetProperties(out string name, out int count, out int price, out int power)
        {
            GetProperties(out name, out count, out price);

            power = ImsHelper.InputWithPromptInt("Stromverbrauch");
        }

    }
}

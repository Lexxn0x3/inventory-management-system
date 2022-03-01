using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management_system
{
    internal class WarenEingang : Program
    {
        static int count, price, power;
        static string name;

        public static void Eingang()
        {
            Console.WriteLine($"{ImsHelper.Abstandhalter}1) neuer Artikel\t2) bestehender Artikel");

            if (Convert.ToInt32(Console.ReadLine()) == 1)
            {
                NewProduct();
            }
            else
            {
                ExistingProduct();
            }
        }

        //neues Produkt

        static void NewProduct()
        {
            Console.WriteLine($"{ImsHelper.Abstandhalter}Zu welcher Kategorie gehört der Artikel?\t1) Keiner\t2) Elektronik");

            if (Convert.ToInt32(Console.ReadLine()) == 1)
            {
                EingabeProperties_standart(out name, out count, out price);

                list.Add(new Article(name, count, price));
                
            }
            else
            {
                EingabeProperties_electronics(out name, out count, out price, out power);

                list.Add(new Electronic(name, count, price, power));
            }
        }

        //vorhandenes Produkt

        static void ExistingProduct()
        {
            Console.WriteLine($"{ImsHelper.Abstandhalter}");

            int artnr;
            Article article;
            do {artnr = ImsHelper.InputWithPromptInt("Wie lautet die Artikelnummer des Produktes");
            }while (!Article.getArticleFromArtNr(artnr, out article));

            int Eingabe = ImsHelper.InputWithPromptInt("Welchen Atribut möchten sie verändern?\t1) name\t2) addarticle\t3)price");
            switch (Eingabe)
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
                    ExistingProduct();
                    break;

                    list[artnr-1] = article;
            }
        }

        //Eingabe von einem normalen Artikel

        static void EingabeProperties_standart(out string name, out int count, out int price)
        {
            name = ImsHelper.InputWithPrompt("name");

            count = ImsHelper.InputWithPromptInt("Anzahl");

            price = ImsHelper.InputWithPromptInt("Preis");
        }

        //Eingabe von einem Elektronik-Artikel

        static void EingabeProperties_electronics(out string name, out int count, out int price, out int power)
        {
            EingabeProperties_standart(out name, out count, out price);

            power = ImsHelper.InputWithPromptInt("Stromverbrauch");
        }

    }
}

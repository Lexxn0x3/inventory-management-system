using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management_system
{
    internal class WarenEingang : inventory_management_system
    {
        static int count, price, power;
        static string name;

        public static void Eingang()
        {
            Console.WriteLine($"{MyConstants.Abstandhalter}1) neuer Artikel\t2) bestehender Artikel");

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
            Console.WriteLine($"{MyConstants.Abstandhalter}Zu welcher Kategorie gehört der Artikel?\t1) Keiner\t2) Elektronik");

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

        static void ExistingProduct()
        {
            Console.WriteLine($"{MyConstants.Abstandhalter}Zu welcher Kategorie gehört der Artikel?\t1) Keiner\t2) Elektronik");

        }

        //vorhandenes Produkt

        //Eingabe von einem normalen Artikel

        static void EingabeProperties_standart(out string name, out int count, out int price)
        {
            name = Eingabe_String("name");

            count = Eingabe_Int("Anzahl");

            price = Eingabe_Int("Preis");
        }

        //Eingabe von einem Elektronik-Artikel

        static void EingabeProperties_electronics(out string name, out int count, out int price, out int power)
        {
            EingabeProperties_standart(out name, out count, out price);

            power = Eingabe_Int("Stromverbrauch");
        }
    }
}

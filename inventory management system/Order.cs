using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management_system
{
    internal class Order
    {
        Article article;
        int count;
        string companyName;
        string buyerName;
        string adress;
        string mail;

        public Order(Article orderArticle, int count, string compname, string adress, string mail, string buyer)
        {
            this.article = orderArticle;
            this.count = count;
            this.companyName = compname;
            this.adress = adress;
            this.mail = mail;
            this.buyerName = buyer;
        }

        public void WriteReceipt()
        {
            StreamWriter sw = new StreamWriter(getReceiptSavePath()+@"\receipt.txt");

            sw.WriteLine(companyName);
            sw.WriteLine(buyerName);
            sw.WriteLine(adress);
            sw.WriteLine(mail + "\n");

            sw.WriteLine($"{count}x {article.Name} NR: {article.getID():d5}\t{getTotalPrice()}$");

            sw.Close();
        }

        private static string getReceiptSavePath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        private double getTotalPrice()
        {
            return article.Price*count;
        }
    }
}

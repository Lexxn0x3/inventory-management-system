using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management_system
{
    class Order
    {
        Article article;
        int count;
        string companyName;
        string buyerName;
        string address;
        string mail;

        public Order(Article orderArticle, int count, string compname, string adress, string mail, string buyer)
        {
            this.article = orderArticle;
            this.count = count;
            this.companyName = compname;
            this.address = adress;
            this.mail = mail;
            this.buyerName = buyer;
        }

        public void WriteReceipt()
        {
            StreamWriter sw = new StreamWriter(GetReceiptSavePath()+@"\receipt.txt");

            sw.WriteLine(companyName);
            sw.WriteLine(buyerName);
            sw.WriteLine(address);
            sw.WriteLine(mail + "\n");

            sw.WriteLine($"{count}x {article.Name} NR: {article.ID:d10}\t{GetTotalPrice()}$");

            sw.Close();
        }

        private static string GetReceiptSavePath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        private double GetTotalPrice()
        {
            return article.Price*count;
        }
    }
}

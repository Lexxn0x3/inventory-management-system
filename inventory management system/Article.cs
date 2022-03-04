namespace inventory_management_system
{
    internal class Article
    {
        public int ID { get; }
        public string Name { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }

        public Article(string name, int count = 0, double price = 0)
        {
            this.Name = name;
            this.Count = count;
            this.Price = price;
            this.ID = GetID();
        }
        private int GetID() 
        {
            Random random = new();
            return random.Next();
        }

        public override string ToString()
        {
            string str = "";

            str = $"{ID:d10}, {Name}, x{Count}, {Price}$";
            return str;
        }

        public static bool GetArticleFromArtNr(int artNr, List<Article> list, out Article article)
        {
            foreach (Article curArticle in list)
            {
                if (curArticle.ID == artNr)
                {
                    article = curArticle;
                    return true;
                }
            }
            article = null;
            return false;
        }

        public static int GetArticleIndex(int artNr, List<Article> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].ID == artNr)
                    return i;
            }
            return -1;
        }

        public static bool CountAvailable(int sellArtNr, int sellCount , List<Article> list)
        {
            return list[GetArticleIndex(sellArtNr, list)].Count >= sellCount;
        }
    }

    class Electronic : Article
    {
        public int Power { get; set; }

        public Electronic(string name, int count = 0, double price = 0, int power = 0) : base(name, count, price)
        {
            this.Power=power;
        }

        public override string ToString()
        {
            string str = "";

            str = $"{ID:d10}, {Name}, x{Count}, {Price}$, {Power}Watt";
            return str;
        }
    }
}

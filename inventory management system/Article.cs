﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management_system
{
    internal class Article : inventory_management_system
    {
        private static int currentID;

        protected int ID;
        public string Name { get; set; }
        public int Count { get; set; }
        public double Prize { get; set; }

        public Article(string name, int count = 0, double prize = 0)
        {
            this.Name = name;
            this.Count = count;
            this.Prize = prize;
            this.ID = GetNextID();
        }

        static Article() => currentID = 0;
        protected int GetNextID() => ++currentID;

        public override string ToString()
        {
            string str = "";

            str = $"{ID:d5}, {Name}, x{Count}, {Prize}$";
            return str;
        }


        public static bool getArticleFromArtNr(int artNr, out Article article)
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

        internal static double getPrize(int sellCount, int sellArtNr)
        {
            return list[sellArtNr-1].Prize*sellCount;
        }

        internal static bool CountAvailable(int sellArtNr, int sellCount)
        {
            return list[sellArtNr-1].Count > sellCount;
        }

        public int getID()
        {
            return ID;
        }
    }

    class Electronic : Article
    {
        public int Power { get; set; }

        public Electronic(string name, int count = 0, double prize = 0, int power = 0) : base(name, count, prize)
        {
            this.Name=name;
            this.Count=count;
            this.Power=power;
            this.Prize=prize;
        }

        public override string ToString()
        {
            string str = "";

            str = $"{ID:d5}, {Name}, x{Count}, {Prize}$, {Power}Watt";
            return str;
        }
    }
}

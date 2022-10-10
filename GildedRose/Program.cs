using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        public static Program app = new Program();

        public static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            List<Item> items = new ()
            {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 },
                new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
            };

            app.PrintStatus(items);
        }

        public void UpdateQuality(IList<Item> items)
        {
            foreach (var item in items)
            {
                switch (item.Name)
                {
                    case "Aged Brie":
                        
                        if (item.Quality < 50)
                        {
                            item.Quality++;
                        }

                        item.SellIn--;

                        if (item.SellIn < 0 && item.Quality < 50)
                        {
                            item.Quality++;
                        }

                        break;

                    case "Backstage passes to a TAFKAL80ETC concert":

                        if (item.Quality < 50)
                        {
                            item.Quality++;
                        }

                        if (item.SellIn < 11 && item.Quality < 50)
                        {
                            item.Quality++;
                        }
                        
                        if (item.SellIn < 6 && item.Quality < 50)
                        {
                            item.Quality++;
                        }

                        item.SellIn--;

                        if (item.SellIn < 0)
                        {
                            item.Quality = 0;    
                        }

                        break;

                    case "Sulfuras, Hand of Ragnaros":
                        break;

                    case string s when s.StartsWith("Conjured"):
                        
                        if (item.Quality >= 2)
                        {
                            item.Quality-=2;
                        }
                        else if (item.Quality > 0)
                        {
                            item.Quality--;
                        }

                        item.SellIn--;

                        break;

                    default:
                        if (item.Quality > 0)
                        {
                            item.Quality--;
                        }

                        item.SellIn--;

                        if(item.SellIn < 0 && item.Quality > 0)
                        {
                            item.Quality--;
                        }

                        break;
                }
            }
        }

        public void PrintStatus(IList<Item> items)
        {
            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");

                for (var j = 0; j < items.Count; j++)
                {
                    Console.WriteLine(items[j].Name + ", " + items[j].SellIn + ", " + items[j].Quality);
                }

                Console.WriteLine("");

                app.UpdateQuality(items);
            }
        }
    }
}
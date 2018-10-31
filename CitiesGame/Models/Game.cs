using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitiesGame.Models
{
    public static class Game
    {
        public static List<GameItem> Items = new List<GameItem>();

        public static object _locker = new object();

        public static void AddItem(GameItem item)
        {
            if(string.IsNullOrWhiteSpace(item.Author))
            {
                item.Author = "Anonimus";
            }
            item.Time = DateTime.Now;

            lock (_locker)
            {
                Items.Add(item);
            }
        }
    }
}
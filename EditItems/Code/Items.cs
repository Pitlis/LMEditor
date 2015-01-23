using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Items;

namespace EditItems.Code
{
    [Serializable]
    public class Items
    {
        public List<Item> items { get; set; }

        public Items()
        {
            items = new List<Assets.Items.Item>();
        }

        public void AddItem(string name, string descr, int price)
        {
            Item item = new Item() { Name = name, Description = descr, Price = price };
            if (items.FindAll((i) => i.Name == name).Count != 0)
            {
                throw new Exception("Имя вещи уже используется!");
            }
            items.Add(item);
        }
        public Item GetItem(int index)
        {
            return items[index];
        }
        public void RemoveItem(int index)
        {
            items.Remove(items[index]);
        }
        public void Edit(int index, string name, string descr, int price)
        {
            if(name != items[index].Name)
            {
                int ind = items.FindIndex((i) => i.Name == name);
                if (ind != index && ind != -1)
                    throw new Exception("Имя вещи уже используется!");
            }

            items[index].Name = name;
            items[index].Description = descr;
            items[index].Price = price;
        }

        public Dictionary<int, string> GetAllItems()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            for (int i = 0; i < items.Count; ++i)
            {
                dict.Add(i, items[i].Name);
            }
            return dict;
        }
    }
}

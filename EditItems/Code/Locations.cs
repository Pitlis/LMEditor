using Assets.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditItems.Code
{
    [Serializable]
    public class Locations
    {        
        public List<Location> locations { get; set; }

        public Locations()
        {
            locations = new List<Location>();
        }

        public void AddLocation(string name, string descr, int searchTime, int level, int experienceForVisiting, Day timeOfDay, int reputationOfFracton, Dictionary<int, List<ItemOnLocation>> itemsOnLocation)
        {
            Location location = new Location() { Name = name, Description = descr, SearchTime = searchTime, Level = level, ExperienceForVisiting = experienceForVisiting, TimeOfDay = timeOfDay, ReputationOfFracton = reputationOfFracton, LevelsItems = ConvertDictToList(itemsOnLocation) };
            location.SetItemsOnLocaton(itemsOnLocation);
            if (locations.FindAll((l) => l.Name == name).Count != 0)
            {
                throw new Exception("Имя локации уже используется!");
            }
            locations.Add(location);
        }
        public Location GetLocation(int index)
        {
            return locations[index];
        }
        public void RemoveLocation(int index)
        {
            locations.Remove(locations[index]);
        }
        public void Edit(int index, string name, string descr, int searchTime, int level, int experienceForVisiting, Day timeOfDay, int reputationOfFracton, Dictionary<int, List<ItemOnLocation>> itemsOnLocation)
        {
            if (name != locations[index].Name)
            {
                int ind = locations.FindIndex((l) => l.Name == name);
                if (ind != index && ind != -1)
                    throw new Exception("Имя локации уже используется!");
            }

            locations[index].Name = name;
            locations[index].Description = descr;
            locations[index].SearchTime = searchTime;
            locations[index].Level = level;
            locations[index].ExperienceForVisiting = experienceForVisiting;
            locations[index].TimeOfDay = timeOfDay;
            locations[index].ReputationOfFracton = reputationOfFracton;
            locations[index].SetItemsOnLocaton(itemsOnLocation);
            locations[index].LevelsItems = ConvertDictToList(itemsOnLocation);
        }

        public Dictionary<int, string> GetAllLocations()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            for (int i = 0; i < locations.Count; ++i)
            {
                dict.Add(i, locations[i].Name);
            }
            return dict;
        }

        public static Dictionary<int, List<ItemOnLocation>> ConvertListToDict(List<LevelItem> LevelsItems, FileItems fileItems)//выгрузка из файла
        {
            Dictionary<int, List<ItemOnLocation>> dict = new Dictionary<int, List<ItemOnLocation>>();
            foreach (var li in LevelsItems)
            {
                foreach(var it in li.ItemsOnLocation)
                {
                    Item item = fileItems.items.items.Find(i => i.Name == it.itemName);
                    if (item != null)
                    {
                        it.item = item;
                    }
                    else
                    {
                        it.item = null;
                    }
                }
                for (int i = 0; i < li.ItemsOnLocation.Count; i++)
                {
                    if (li.ItemsOnLocation[i].item == null)
                        li.ItemsOnLocation.RemoveAt(i);
                }
            }
            foreach(var li in LevelsItems)
            {
                dict.Add(li.level, li.ItemsOnLocation);
            }
            for (int i = 1; i <= 100; i++)
            {
                if(!dict.ContainsKey(i))
                {
                    dict.Add(i, new List<ItemOnLocation>());
                }
            }
            return dict;
        }
        public static List<LevelItem> ConvertDictToList(Dictionary<int, List<ItemOnLocation>> dict)//сохранение в файл
        {
            List<LevelItem> list = new List<LevelItem>();
            foreach(var d in dict)
            {
                foreach (var it in d.Value)
                {
                    it.itemName = it.item.Name;
                }
                if(d.Value.Count != 0)
                    list.Add(new LevelItem() { level = d.Key, ItemsOnLocation = d.Value });
            }
            return list;
        }

    }
}

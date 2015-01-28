using System.Collections;
using System.Collections.Generic;
using Assets.Items;
using System;
using EditItems.Code;
using System.Xml.Serialization;

[Serializable]
public class Location{

    public string Name { get; set; }
    public string Description { get; set; }
    public int SearchTime { get; set; }
    public int Level { get; set; }
    public int ExperienceForVisiting { get; set; }
    public Day TimeOfDay { get; set; }
    public int ReputationOfFracton { get; set; }

    public List<LevelItem> LevelsItems { get; set; } // только для решения проблем с сериализацией словаря, не использовать!!!
    
    Dictionary<int, List<ItemOnLocation>> ItemsOnLocation { get; set; }

    public Location() { }
    public void SetItemsOnLocaton(Dictionary<int, List<ItemOnLocation>> dict)
    {
        ItemsOnLocation = dict;
    }
    public Dictionary<int, List<ItemOnLocation>> GetItemsOnLocation()
    {
        return ItemsOnLocation;
    }
}
[Serializable]
public class ItemOnLocation{
    public string itemName;
    public int Probabilitys { get; set; }
    [XmlIgnoreAttribute]
    public Item item { get; set; }
}
[Serializable]
public enum Day
{
    Always,
    Morning,
    Noon,
    Evening,
    Night
}

[Serializable]
public class LevelItem
{
    public List<ItemOnLocation> ItemsOnLocation { get; set; }
    public int level;
    public LevelItem() { }

}

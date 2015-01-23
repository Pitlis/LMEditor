using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Items
{
    //Какая-то вещь - базовые характеристики всех игровых предметов, которые создаются и уничтожаются
    public abstract class ItemAbstract
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }


    }
}

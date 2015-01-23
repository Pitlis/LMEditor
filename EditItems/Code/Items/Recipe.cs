using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Items
{
    //Рецепт - вещь, которую можно купить, в которой содержится инструкция для создания другой вещи.
    [Serializable]
    public class Recipe: ItemAbstract
    {
        public int ExperienceGain { get;  set; }
        public List<Reagent> Reagents { get;  set; }
        public List<Result> Results { get;  set; }
        
        public Recipe()
        {
            ;
        }

        [Serializable]
        public class Result
        {            
            public Item item { get; set; }
            public int Count { get; set; }

            public Result(Item _item, int count)
            {
                item = _item;
                Count = count;
            }
            public Result()
            {
                ;
            }

        }
        [Serializable]
        public class Reagent
        {
            public Item item { get; set; }
            public int Count { get; set; }

            public Reagent(Item _item, int count)
            {
                item = _item;
                Count = count;
            }
            public Reagent() { ;}
        }
    }
}

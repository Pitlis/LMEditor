using Assets.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditItems.Code
{
    [Serializable]
    public class Recipes
    {
        public List<Recipe> recipes { get; set; }

        public Recipes()
        {
            recipes = new List<Recipe>();
        }

        public void AddItem(string name, string descr, int price, List<Recipe.Reagent> reagents, List<Recipe.Result> results, int experienceGain, int minLevel)
        {
            Recipe recipe = new Recipe() { Name = name, Description = descr, Price = price, ExperienceGain = experienceGain, Results = results, Reagents = reagents, minPlayersLevel = minLevel};
            if (recipes.FindAll((i) => i.Name == name).Count != 0)
            {
                throw new Exception("Имя рецепта уже используется!");
            }
            recipes.Add(recipe);
        }
        public Recipe GetRecipe(int index)
        {
            return recipes[index];
        }
        public void RemoveRecipe(int index)
        {
            recipes.Remove(recipes[index]);
        }
        public void Edit(int index, string name, string descr, int price, List<Recipe.Reagent> reagents, List<Recipe.Result> results, int experienceGain, int minLevel)
        {
            int ind = recipes.FindIndex((i) => i.Name == name);
            if (ind != index && ind != -1)
                throw new Exception("Имя вещи уже используется!");

            recipes[index].Name = name;
            recipes[index].Description = descr;
            recipes[index].Price = price;
            recipes[index].ExperienceGain = experienceGain;
            recipes[index].Results = results;
            recipes[index].Reagents = reagents;
            recipes[index].minPlayersLevel = minLevel;
        }

        public Dictionary<int, string> GetAllRecipes()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            for (int i = 0; i < recipes.Count; ++i)
            {
                dict.Add(i, recipes[i].Name);
            }
            return dict;
        }

    }
}

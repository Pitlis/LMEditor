using Assets.Items;
using EditItems.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EditItems
{
    /// <summary>
    /// Interaction logic for RecipeEditor.xaml
    /// </summary>
    public partial class RecipeEditor : Window
    {
        public FileItems fileItems;
        public List<Recipe.Reagent> reagents;
        public List<Recipe.Result> results;

        int RecipeIndex = -1;
        public RecipeEditor()
        {
            InitializeComponent();
            ListRecipes.SelectionMode = SelectionMode.Single;
            listResults.SelectionMode = SelectionMode.Single;
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
            reagents = new List<Recipe.Reagent>();
            results = new List<Recipe.Result>();
        }

        private void ListReagents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ListRecipes.ItemsSource = fileItems.recipes.GetAllRecipes();

            listResults.ItemsSource = fileItems.items.GetAllItems();
        }

        void UpdateList()
        {
            ListRecipes.UnselectAll();
            ListRecipes.ItemsSource = fileItems.recipes.GetAllRecipes();
        }

        private void btnCreate(object sender, RoutedEventArgs e)
        {
            recipName.Clear();
            recipDescr.Clear();
            recipPrice.Clear();
            txtO.Clear();
            txtLevel.Clear();
            reagents = new List<Recipe.Reagent>();
            results = new List<Recipe.Result>();
            UpdateReagentsList();
            UpdateResultsList();
            listResults.SelectedItem = null;
        }

        private void btnSave(object sender, RoutedEventArgs e)
        {
            try
            {
                if (recipName.Text == null || recipDescr.Text == null)
                    throw new Exception("Пустые поля!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            int price = 0;
            try
            {
                price = Int32.Parse(recipPrice.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if(results.Count == 0)
            {
                MessageBox.Show("Нет результатов рецепта!");
                return;
            }
            if(reagents.Count == 0)
            {
                MessageBox.Show("Нет ингредиентов!");
                return;
            }
            int op = 0;
            try
            {
                op = Int32.Parse(txtO.Text);
            }
            catch{ op = 0;}
            int minLevel = 0;
            try
            {
                minLevel = Int32.Parse(txtLevel.Text);
            }
            catch{minLevel = 1;}
            try
            {
                if (RecipeIndex == -1)
                {
                    fileItems.recipes.AddItem(recipName.Text, recipDescr.Text, price, reagents, results, op, minLevel);
                }
                else
                {
                    fileItems.recipes.Edit(((KeyValuePair<int, string>)ListRecipes.SelectedItem).Key, recipName.Text, recipDescr.Text, price, reagents, results, op, minLevel);
                }
                FileItems.SaveFile(fileItems);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            UpdateList();
        }

        private void btnRemove(object sender, RoutedEventArgs e)
        {
            if (ListRecipes.SelectedItem == null)
                return;
            int id = ((KeyValuePair<int, string>)ListRecipes.SelectedItem).Key;
            fileItems.recipes.RemoveRecipe(id);
            FileItems.SaveFile(fileItems);
            UpdateList();
        }

        public void UpdateListItemsEvent(object sender, EventArgs e)
        {
            listResults.ItemsSource = fileItems.items.GetAllItems();
        }

        private void btnAddItem(object sender, RoutedEventArgs e)
        {
            int index = -1;
            int count = 0 ;

            AddReagent windowAdd = new AddReagent();
            windowAdd.fileItems = fileItems;
            if(windowAdd.ShowDialog() == true)
            {
                index = windowAdd.id;
                count = windowAdd.count;
            }
            reagents.Add(new Recipe.Reagent(fileItems.items.GetItem(index), count));
            UpdateReagentsList();
        }

        void UpdateReagentsList()
        {
            listReagents.ItemsSource = null;
            listReagents.ItemsSource = reagents;
        }
        void UpdateResultsList()
        {
            listResults.ItemsSource = null;
            listResults.ItemsSource = results;
        }

        private void btnDeleteItem(object sender, RoutedEventArgs e)
        {
            if (listReagents.SelectedItem == null)
                return;
            reagents.Remove(reagents[listReagents.SelectedIndex]);
            UpdateReagentsList();
        }


        private void ListRecipe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListRecipes.SelectedItem == null)
            {
                btnCreate(new Object(), new RoutedEventArgs());
            }
            else
            {
                int id = ((KeyValuePair<int, string>)ListRecipes.SelectedItem).Key;
                RecipeIndex = id;

                Recipe recipe = fileItems.recipes.GetRecipe(id);
                recipName.Text = recipe.Name;
                recipDescr.Text = recipe.Description;
                recipPrice.Text = recipe.Price.ToString();
                txtO.Text = recipe.ExperienceGain.ToString();
                txtLevel.Text = recipe.minPlayersLevel.ToString();

                results = recipe.Results;
                reagents = recipe.Reagents;
                UpdateReagentsList();
                UpdateResultsList();
            }
        }

        private void btnAddItemResult(object sender, RoutedEventArgs e)
        {
            int index = -1;
            int count = 0;

            AddResult windowAdd = new AddResult();
            windowAdd.fileItems = fileItems;
            if (windowAdd.ShowDialog() == true)
            {
                index = windowAdd.id;
                count = windowAdd.count;
            }
            results.Add(new Recipe.Result(fileItems.items.GetItem(index), count));
            UpdateResultsList();
        }

        private void btnDeleteItemResult(object sender, RoutedEventArgs e)
        {
            if (listResults.SelectedItem == null)
                return;
            try
            {
                results.Remove(results[listResults.SelectedIndex]);
            }
            catch { return; }
            UpdateResultsList();
        }
    }
}

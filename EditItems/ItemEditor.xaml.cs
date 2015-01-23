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
    /// Interaction logic for ItemEditor.xaml
    /// </summary>
    public partial class ItemEditor : Window
    {
        public FileItems fileItems;
        public event EventHandler<EventArgs> changeItemsList;

        public ItemEditor()
        {
            InitializeComponent();
            ListItems.SelectionMode = SelectionMode.Single;
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        int ItemIndex = -1;
        private void btnSave(object sender, RoutedEventArgs e)
        {
            try
            {
                if (itemName.Text == null || itemDescr.Text == null)
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
                price = Int32.Parse(itemPrice.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            try
            {
                if (ItemIndex == -1)
                {
                    fileItems.items.AddItem(itemName.Text, itemDescr.Text, price);
                }
                else
                {
                    fileItems.items.Edit(((KeyValuePair<int, string>)ListItems.SelectedItem).Key, itemName.Text, itemDescr.Text, price);
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


        void UpdateList()
        {
            ListItems.UnselectAll();
            ListItems.ItemsSource = fileItems.items.GetAllItems();
            changeItemsList(new Object(), new EventArgs());
        }

        private void btnRemove(object sender, RoutedEventArgs e)
        {
            if (ListItems.SelectedItem == null)
                return;
            int id = ((KeyValuePair<int, string>)ListItems.SelectedItem).Key;
            fileItems.items.RemoveItem(id);
            FileItems.SaveFile(fileItems);
            UpdateList();
        }

        private void btnCreate(object sender, RoutedEventArgs e)
        {
            itemDescr.Clear();
            itemName.Clear();
            itemPrice.Clear();
            ItemIndex = -1;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ListItems.ItemsSource = fileItems.items.GetAllItems();
        }

        private void ListItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string name = ((KeyValuePair<int, string>)ListItems.SelectedItem).Value;
            if(ListItems.SelectedItem == null)
            {
                btnCreate(new Object(), new RoutedEventArgs());
            }
            else
            {
                int id = ((KeyValuePair<int, string>)ListItems.SelectedItem).Key;
                ItemIndex = id;

                Item item = fileItems.items.GetItem(id);
                itemName.Text = item.Name;
                itemDescr.Text = item.Description;
                itemPrice.Text = item.Price.ToString();
            }

        }
    }
}

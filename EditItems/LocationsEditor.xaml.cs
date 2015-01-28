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
    public partial class LocationsEditor : Window
    {
        public FileItems fileItems;
        public FileLocations fileLocations;
        Dictionary<int, List<ItemOnLocation>> ItemsOnLocation;
        int currentLevel = 0;


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            int[] levels = new int[100];
            for (int i = 0; i < 100; ++i)
                levels[i] = i + 1;
            cmbLevel.ItemsSource = levels;
            FileLocations.DownloadItems(fileLocations, fileItems);
            cmbTimeOfDay.ItemsSource = new List<Day>() { Day.Always, Day.Morning, Day.Noon, Day.Evening, Day.Night };
            cmbTimeOfDay.SelectedIndex = 0;
            UpdateList();
            btnCreate(new Object(), new RoutedEventArgs());
        }

        public LocationsEditor()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
            ListLocations.SelectionMode = SelectionMode.Single;
            listItems.SelectionMode = SelectionMode.Single;
        }

        int LocationIndex = -1;

        void UpdateList()
        {
            ListLocations.UnselectAll();
            ListLocations.ItemsSource = fileLocations.locations.GetAllLocations();
        }

        private void btnCreate(object sender, RoutedEventArgs e)
        {
            locationName.Clear();
            locationDescr.Clear();
            txtO.Clear();
            txtLevel.Clear();
            txtSearchTime.Clear();
            txtReputation.Clear();
            currentLevel = 1;
            ItemsOnLocation = new Dictionary<int,List<ItemOnLocation>>();
            for (int i = 0; i < 100; i++)
			{
			    ItemsOnLocation.Add(i+1, new List<ItemOnLocation>());
            }
            UpdateItemsList();
            cmbLevel.SelectedIndex = 0;
            cmbTimeOfDay.SelectedIndex = 0;
            listItems.SelectedItem = null;
            LocationIndex = -1;
        }

        private void btnSave(object sender, RoutedEventArgs e)
        {
            try
            {
                if (locationName.Text == null || locationDescr.Text == null || txtO.Text == null || txtLevel.Text == null || txtSearchTime.Text == null || txtReputation.Text == null)
                    throw new Exception("Пустые поля!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            int reputation = 0;
            try
            {
                reputation = Int32.Parse(txtReputation.Text);
            }
            catch (Exception ex)
            {
                reputation = 0;
            }
            if (ItemsOnLocation.Count == 0)
            {
                MessageBox.Show("Нет выпадающих предметов!");
                return;
            }
            int op = 0;
            try
            {
                op = Int32.Parse(txtO.Text);
            }
            catch{ op = 0;}
            int searchTime = 0;
            try
            {
                searchTime = Int32.Parse(txtSearchTime.Text);
            }
            catch {
                MessageBox.Show("Некорректное время поиска на локации");
                return;
            }
            int minLevel = 0;
            try
            {
                minLevel = Int32.Parse(txtLevel.Text);
            }
            catch{minLevel = 1;}

            try
            {
                if (LocationIndex == -1)
                {
                    fileLocations.locations.AddLocation(locationName.Text, locationDescr.Text, searchTime, minLevel, op, (Day)cmbTimeOfDay.SelectedItem, reputation, ItemsOnLocation);
                }
                else
                {
                    fileLocations.locations.Edit(((KeyValuePair<int, string>)ListLocations.SelectedItem).Key, locationName.Text, locationDescr.Text, searchTime, minLevel, op, (Day)cmbTimeOfDay.SelectedItem, reputation, ItemsOnLocation);
                }
                FileLocations.SaveFile(fileLocations);
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
            if (ListLocations.SelectedItem == null)
                return;
            int id = ((KeyValuePair<int, string>)ListLocations.SelectedItem).Key;
            fileLocations.locations.RemoveLocation(id);
            FileLocations.SaveFile(fileLocations);
            UpdateList();
        }

        private void btnAddItem(object sender, RoutedEventArgs e)
        {
            Item it = null;
            int p = 0;

            AddItemForLocation windowAdd = new AddItemForLocation();
            windowAdd.fileItems = fileItems;
            if (windowAdd.ShowDialog() == true)
            {
                it = fileItems.items.GetItem(windowAdd.id);
                p = windowAdd.Pr;
            }
            ItemsOnLocation[currentLevel].Add(new ItemOnLocation() { item = it, Probabilitys = p });
            UpdateItemsList();
        }

        void UpdateItemsList()
        {
            listItems.ItemsSource = null;
            listItems.ItemsSource = ItemsOnLocation[currentLevel];
        }

        private void btnDeleteItem(object sender, RoutedEventArgs e)
        {
            if (listItems.SelectedItem == null)
                return;
            ItemsOnLocation[currentLevel].Remove(ItemsOnLocation[currentLevel][listItems.SelectedIndex]);
            UpdateItemsList();
        }


        private void ListLocation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListLocations.SelectedItem == null)
            {
                btnCreate(new Object(), new RoutedEventArgs());
            }
            else
            {
                int id = ((KeyValuePair<int, string>)ListLocations.SelectedItem).Key;
                LocationIndex = id;

                Location loc = fileLocations.locations.GetLocation(id);
                ItemsOnLocation = loc.GetItemsOnLocation();
                locationName.Text = loc.Name;
                locationDescr.Text = loc.Description;
                txtSearchTime.Text = loc.SearchTime.ToString();
                txtO.Text = loc.ExperienceForVisiting.ToString();
                txtLevel.Text = loc.Level.ToString();
                txtReputation.Text = loc.ReputationOfFracton.ToString();
                cmbTimeOfDay.SelectedItem = loc.TimeOfDay;
                cmbLevel.SelectedIndex = 0;
                listItems.ItemsSource = ItemsOnLocation[1];
                currentLevel = 1;
            }
        }


        private void cmbLevel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listItems.ItemsSource = null;
            listItems.ItemsSource = ItemsOnLocation[(int)cmbLevel.SelectedItem];
            currentLevel = (int)cmbLevel.SelectedItem;
        }

    }
}

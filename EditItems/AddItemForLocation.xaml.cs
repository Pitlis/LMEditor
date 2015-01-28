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
    public partial class AddItemForLocation : Window
    {
        public FileItems fileItems;
        public int Pr = 0;
        public int id = 0;
        public AddItemForLocation()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            cmbItem.ItemsSource = fileItems.items.GetAllItems();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int c = 0;
            try
            {
                c = Int32.Parse(txtP.Text);
                if (c < 0 || c > 100)
                    throw new Exception();
            }
            catch
            {
                MessageBox.Show("Некорректное число!");
                return;
            }
            if (cmbItem.SelectedItem != null)
            {
                id = ((KeyValuePair<int, string>)cmbItem.SelectedItem).Key;
                Pr = c;
                this.DialogResult = true;
            }

        }
    }
}

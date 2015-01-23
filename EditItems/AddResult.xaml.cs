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
    public partial class AddResult : Window
    {
        public FileItems fileItems;
        public int id;
        public int count;

        public AddResult()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            listItems.ItemsSource = fileItems.items.GetAllItems();
        }

        private void btnAdd(object sender, RoutedEventArgs e)
        {
            int c = 0;
            try
            {
                c = Int32.Parse(txtCount.Text);
            }
            catch
            {
                MessageBox.Show("Некорректное число!");
                return;
            }
            if (listItems.SelectedItem != null)
            {
                id = ((KeyValuePair<int, string>)listItems.SelectedItem).Key;
                count = c;
                this.DialogResult = true;
            }

        }
    }
}

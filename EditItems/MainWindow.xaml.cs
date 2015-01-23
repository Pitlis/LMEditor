using EditItems.Code;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace EditItems
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpenFile(object sender, RoutedEventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "~";
            openFileDialog1.Filter = "XML-File | *.xml";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            FileItems fileItems = null;
            if (openFileDialog1.ShowDialog() != null)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {

                            fileItems = FileItems.OpenFile(myStream, openFileDialog1.FileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
                OpenWindows(fileItems);
            }
        }


        private void btnCreateFile(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "itemsUnity"; // Default file name
            dlg.DefaultExt = ".xml"; // Default file extension
            dlg.Filter = "XML-File | *.xml"; ; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results

            string filename = dlg.FileName;
            if (result == true)
            {
                // Save document
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename, false))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(FileItems));
                    ser.Serialize(file, new FileItems());
                }
            }
            FileItems fileItems = null;
            try
            {
                using (Stream stream = File.Open(filename, FileMode.Open))
                {
                    fileItems = FileItems.OpenFile(stream, filename);
                }
            }
            catch { return; }
            OpenWindows(fileItems);
        }

        void OpenWindows(FileItems fileItems)
        {
            ItemEditor itemEditor = new ItemEditor();
            itemEditor.fileItems = fileItems;
            itemEditor.Show();

            RecipeEditor WindowRecipe = new RecipeEditor();
            itemEditor.changeItemsList += WindowRecipe.UpdateListItemsEvent;
            WindowRecipe.fileItems = fileItems;
            WindowRecipe.Show();

            this.Close();
        }
    }
}

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
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace EditItems
{
    /// <summary>
    /// Interaction logic for LocationEditorFiles1.xaml
    /// </summary>
    public partial class LocationEditorFiles1 : Window
    {
        public LocationEditorFiles1()
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

            FileLocations fileLocation = null;
            if (openFileDialog1.ShowDialog() != null)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {

                            fileLocation = FileLocations.OpenFile(myStream, openFileDialog1.FileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
                OpenWindows(fileLocation);
            }
        }

        private void btnCreateFile(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "LocationsUnity"; // Default file name
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
                    XmlSerializer ser = new XmlSerializer(typeof(FileLocations));
                    ser.Serialize(file, new FileLocations());
                }
            }
            FileLocations fileLocations = null;
            try
            {
                using (Stream stream = File.Open(filename, FileMode.Open))
                {
                    fileLocations = FileLocations.OpenFile(stream, filename);
                }
            }
            catch { return; }
            OpenWindows(fileLocations);
        }

        void OpenWindows(FileLocations fileLocation)
        {
            FileItems fileItems = null;
            while(fileItems == null)
            {
                fileItems = OpenFileWithItems();
            }

            LocationsEditor locationEditor = new LocationsEditor();
            locationEditor.fileItems = fileItems;
            locationEditor.fileLocations = fileLocation;
            locationEditor.Show();
            this.Close();
        }

        FileItems OpenFileWithItems()
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
            }
            return fileItems;
        }
    }
}

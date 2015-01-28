using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EditItems.Code
{
    [Serializable]
    public class FileLocations
    {
        static string FileName;
        public Locations locations;
        public FileLocations()
        {
            locations = new Locations();
        }

        public static FileLocations OpenFile(Stream stream, string fileName)
        {
            FileName = fileName;
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(FileLocations));
            FileLocations fileLocation = (FileLocations)reader.Deserialize(stream);
            foreach(Location l in fileLocation.locations.locations)
            {
                l.SetItemsOnLocaton(l.GetItemsOnLocation());
            }
            return fileLocation;
        }
        public static void SaveFile(FileLocations fileLocation)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(FileName, false))
            {
                XmlSerializer ser = new XmlSerializer(typeof(FileLocations), new Type[] { typeof(Locations), typeof(Location), typeof(LevelItem) });
                ser.Serialize(file, fileLocation);
            }
        }

        public static void DownloadItems(FileLocations fileLocation, FileItems fileItems)
        {
            foreach(var loc in fileLocation.locations.locations)
            {
                loc.SetItemsOnLocaton(Locations.ConvertListToDict(loc.LevelsItems, fileItems));
            }
        }
    }
}

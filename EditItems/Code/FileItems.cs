using Assets.Items;
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
    public class FileItems
    {
        public Items items;
        public Recipes recipes;
        static string FileName;

        public FileItems()
        {
            items = new Items();
            recipes = new Recipes();
        }



        public static FileItems OpenFile(Stream stream, string fileName)
        {
            FileName = fileName;
            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(FileItems));
            FileItems FileItem = (FileItems)reader.Deserialize(stream);
            return FileItem;
        }
        public static void SaveFile(FileItems fileItems)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(FileName, false))
            {
                XmlSerializer ser = new XmlSerializer(typeof(FileItems), new Type[] { typeof(Items), typeof(Item), typeof(Recipes), typeof(Recipe), typeof(Recipe.Result), typeof(Recipe.Reagent) });
                ser.Serialize(file, fileItems);
            }
        }
    }
}

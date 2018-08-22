using System;
using System.IO;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using RM_DataBase_classes.DataClass;
using System.Reflection;

namespace RM_DataBase_classes
{
    public class DataBaseFiles
    {
        private DirectoryInfo dataProjectDirInfo;

        public static string dataProjectItemsFile = "Items.json";
        private List<Rm_DataBase_Item> JsonItem;
        public static string dataProjectWeaponsFile = "Weapons.json";
        //private JsonReader JsonWeapons;
        public static string dataProjectArmorsFile = "Armors.json";
        //private JsonReader JsonArmors;
        public static string dataProjectEnemiesFile = "Enemies.json";
        //private JsonReader JsonEnemies;

        public static string dataProjectActorsFile = "";
        public static string dataProjectAnimationsFile = "";
        public static string dataProjectClassesFile = "";
        public static string dataProjecCommonEventsFile = "";
        public static string dataProjectSkillsFile = "";
        public static string dataProjectStatesFile = "";
        public static string dataProjectSystemFile = "";
        public static string dataProjectTilesetsFile = "";
        public static string dataProjectTroopsFile = "";
        
        JavaScriptSerializer json_serializer;

        public DataBaseFiles(string dirname)
        {
        	this.json_serializer = new JavaScriptSerializer();
            this.dataProjectDirInfo = new DirectoryInfo(dirname);

            if (this.dataProjectDirInfo.Exists)
            {
                List<string> arrayFiles = new List<string>(Directory.GetFiles(this.dataProjectDirInfo.ToString()));

                if (arrayFiles.Contains(this.dataProjectDirInfo.ToString() + DataBaseFiles.dataProjectItemsFile))
                {
                    //this.JsonItem = JsonConvert.DeserializeObject<List<Rm_DataBase_Item>>(File.ReadAllText(this.dataProjectDirInfo.ToString() + "\\" + DataBaseFiles.dataProjectItemsFile));
                    this.JsonItem = this.LoadJson<Rm_DataBase_Item>(this.dataProjectDirInfo.ToString() + "\\" + DataBaseFiles.dataProjectItemsFile);
                }
            }
        }
        
        public static T GetObject<T>(Dictionary<string,object> dict)
		{
		    Type type = typeof(T);
		    iRmDbObject obj = (iRmDbObject)Activator.CreateInstance(type);
		
		    foreach (var kv in dict)
		    {
				PropertyInfo property = type.GetProperty(kv.Key);
				if (property != null)
			    	property.SetValue(obj, kv.Value);
		    }
		    return (T)obj;
		}
		
        public List<TypeObj> LoadJson<TypeObj>(string file)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			List<TypeObj> tmp = new List<TypeObj>(50);
			
			string str = System.IO.File.ReadAllText(file);
			
			Object[] rm_items = (Object[])json_serializer.DeserializeObject(str);
			foreach (Object rm_item in rm_items)
			{
				if (rm_item == null)
					continue;
				
				TypeObj tmp_item = GetObject<TypeObj>(rm_item as Dictionary<string,object>);
				tmp.Add(tmp_item);
			}
			return tmp;
		}
		
        public bool saveDataBase(bool backup = true)
		{
        	
        	Dictionary<string, Type> dataBFile = new Dictionary<string, Type>(10);
        	dataBFile.Add(DataBaseFiles.dataProjectItemsFile, typeof(Rm_DataBase_Item));

        	foreach (KeyValuePair<string, Type> element in dataBFile) {
        		string fileName = this.dataProjectDirInfo.ToString() + element.Key;
	        	if (backup)
	        		System.IO.File.Copy(fileName,fileName + ".backup", true);

				List<object> tmp_items = new List<object>(50);
				tmp_items.Add(null);
				tmp_items.AddRange(this.JsonItem);
				string str_out = this.json_serializer.Serialize(tmp_items);
				System.IO.File.WriteAllText(fileName, str_out);
        	}
			return true;
		}
		
        public List<Rm_DataBase_Item> Items { get { return this.JsonItem; } }
    }
}

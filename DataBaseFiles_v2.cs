using System;
using System.IO;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using RM_DataBase_classes.DataClass;
using System.Reflection;
using System.Drawing;
using System.Text;

namespace RM_DataBase_classes
{
    public class DataBaseFiles
    {
        private DirectoryInfo dataProjectDirInfo;
        private bool DirectoryLoaded;
        private string[] fillesInDataDir;

        public static string dataProjectItemsFile = "Items.json";
        private List<Rm_DataBase_Item> JsonItem;
        private bool itemDataLoaded;
        
        public static string dataProjectWeaponsFile = "Weapons.json";
        private List<Rm_DataBase_Weapon> JsonWeapons;
        private bool WeaponsDataLoaded;
        
        public static string dataProjectArmorsFile = "Armors.json";
        //private JsonReader JsonArmors;
        //private bool armorsDataLoaded;
        
        public static string dataProjectEnemiesFile = "Enemies.json";
        //private JsonReader JsonEnemies;
        //private bool EnemiesDataLoaded;
        
        public static string dataProjectIconSet = "IconSet.png";
        public static Image iconSet;
        private static bool IconSetLoaded;

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

        /// <summary>
        /// Classe de Gestion des fichiers Json de la database RM
        /// </summary>
        /// <param name="dirname">Rpg Maker Data Directory (files .JSON)</param>
        public DataBaseFiles(string dirname)
        {
        	this.json_serializer = new JavaScriptSerializer();
            this.dataProjectDirInfo = new DirectoryInfo(dirname);
            this.DirectoryLoaded = this.dataProjectDirInfo.Exists;

            if (this.DirectoryLoaded)
            {
                List<string> arrayFiles = new List<string>(Directory.GetFiles(this.dataProjectDirInfo.ToString()));
				
                //File name
                string itemFP = this.dataProjectDirInfo.ToString() + "\\" + DataBaseFiles.dataProjectItemsFile;
                string weaponFP = this.dataProjectDirInfo.ToString() + "\\" + DataBaseFiles.dataProjectItemsFile;
                // Image Todo modifier pour le chercher dans le bon rep
                string iconSetFP = this.dataProjectDirInfo.ToString() + "\\..\\img\\system\\" + DataBaseFiles.dataProjectIconSet;
                	
                //File Found
                this.itemDataLoaded = arrayFiles.Contains(itemFP);
                this.WeaponsDataLoaded = arrayFiles.Contains(weaponFP);
                DataBaseFiles.IconSetLoaded = File.Exists(iconSetFP);
                
                // initialise Data
                if (itemDataLoaded)
                {
                    this.JsonItem 		= this.LoadJson<Rm_DataBase_Item>(itemFP);
                }
                
                if (this.WeaponsDataLoaded)
                {
                	this.JsonWeapons 	= this.LoadJson<Rm_DataBase_Weapon>(weaponFP);
                }
                
                if (DataBaseFiles.IconSetLoaded)
                {
                	DataBaseFiles.iconSet = Image.FromFile(iconSetFP);
                }
                else 
                	DataBaseFiles.iconSet = null;
            }
            else
            	throw new Exception("Directory not found : " + dirname);
        }
        
        public static T GetObject<T>(Dictionary<string,object> dict)
		{
		    Type type = typeof(T);
		    iRmDbObject obj = (iRmDbObject)Activator.CreateInstance(type);
		
		    foreach (var kv in dict)
		    {
		    	string name = kv.Key;
		    	if (name == "params")
		    		name = "p_params";
		    	
				PropertyInfo property = type.GetProperty(name);
				if (property != null)
			    	property.SetValue(obj, kv.Value);
		    }
		    return (T)obj;
		}
        
        /// <summary>
        /// Return a Image from the IconSet by the Id.
        /// </summary>
        /// <param name="id">Id in the IconSet</param>
        /// <returns>Image 32 * 32 of icon</returns>
        public static Image GetIcon(int id)
        {
        	if (!DataBaseFiles.IconSetLoaded)
        		throw new Exception("IconSet not found");
        		
        	int taille = 32;
        	int nb_line = DataBaseFiles.iconSet.Width / taille;
        	
        	int y = (id / nb_line) * taille;
        	int x = (id % nb_line) * taille;
        	
        	Bitmap btm = new Bitmap(taille,taille);
        	Graphics grp = Graphics.FromImage(btm);
        	grp.DrawImage(DataBaseFiles.iconSet,new Rectangle(0,0,taille,taille),new Rectangle(x,y,taille,taille),GraphicsUnit.Pixel);
        	
        	return Image.FromHbitmap(btm.GetHbitmap());
        }
		
        /// <summary>
        /// Load the Json in a generic type List of object
        /// </summary>
        /// <param name="file">File name</param>
        /// <returns>List of object</returns>
        public List<TypeObj> LoadJson<TypeObj>(string file)
		{		
			List<TypeObj> tmp = new List<TypeObj>(50);
            string str = "";


            try { // Problème d'ouverture de fichier 
				str = System.IO.File.ReadAllText(file);
			} catch (Exception) {
				
				throw new Exception("Read file error");
			}
			
			try { // Problème au chargement du JSON
				Object[] rm_items = (Object[])json_serializer.DeserializeObject(str);
				foreach (Object rm_item in rm_items)
				{
					if (rm_item == null)
						continue;
					
					TypeObj tmp_item = GetObject<TypeObj>(rm_item as Dictionary<string,object>);
					tmp.Add(tmp_item);
				}
				return tmp;
			} catch (Exception e) {
				// a voir si on change l'exception ou pas.
				throw e;
			}
			
		}
		
        public string DecodeString(string str)
		{
        	string rtStr = "";
        	rtStr = str.Replace("\\u0027","'").Replace("\\u003c","<").Replace("\\u003e",">").Replace("\\u0026","&");
        	return rtStr;
        }
        
        /// <summary>
        /// Function de sauvegarde
        /// Todo : function mal écrite, a revoir.
        /// </summary>
        /// <param name="backup">Si une copie du fichier d'origine est faites</param>
        /// <returns>It'is ok</returns>
        public bool saveDataBase(bool backup = true)
		{
        	Encoding encode = new UTF8Encoding(true ,true);
        	
        	Dictionary<string, Type> dataBFile = new Dictionary<string, Type>(10);
        	dataBFile.Add(DataBaseFiles.dataProjectItemsFile, typeof(Rm_DataBase_Item));

        	foreach (KeyValuePair<string, Type> element in dataBFile) {
        		string fileName = this.dataProjectDirInfo.ToString() + element.Key;
	        	if (backup)
	        		System.IO.File.Copy(fileName,fileName + ".backup", true);
				
	        	string str_out = "[" + Environment.NewLine + "null";
	        	foreach (Rm_DataBase_Item db_item in this.JsonItem) {
	        		str_out += "," 
	        			+ Environment.NewLine 
	        			+ DecodeString(this.json_serializer.Serialize(db_item));
	        	}
	        	str_out += Environment.NewLine + "]";
				System.IO.File.WriteAllText(fileName, str_out);
        	}
			return true;
		}
		
        /// <summary>
        /// List of Items
        /// </summary>
        public List<Rm_DataBase_Item> Items 
        { 
        	get { 
        		if (!this.itemDataLoaded)
	        		throw new Exception("Item Data not loaded.");

        		return this.JsonItem; 
        	}
        	set { this.JsonItem = value; } // todo non securisé
        }
        
        /// <summary>
        /// List of Weapons
        /// </summary>
        public List<Rm_DataBase_Weapon> Weapons 
        { 
        	get { 
        		if (!this.WeaponsDataLoaded)
	        		throw new Exception("Weapon Data not loaded.");
	        		
        		return this.JsonWeapons; 
        	}
        	set { this.JsonWeapons = value; } // todo non securisé
        }
        
        public List<Rm_DataBase_Item> CloneItemsList()
        {
        		List<Rm_DataBase_Item> cl = new List<Rm_DataBase_Item>(this.Items.Count);
        		foreach (var item in this.Items) {
        			cl.Add(item.Clone() as Rm_DataBase_Item);
        		}
        		return cl; 
        }
    }
}

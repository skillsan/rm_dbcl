using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace RM_DataBase_classes
{
    public class DataBaseFiles
    {
        private DirectoryInfo dataProjectDirInfo;

        public static string dataProjectItemsFile = "Items.json";
        private List<Rm_DataBase_Item> JsonItem;
        public static string dataProjectWeaponsFile = "Weapons.json";
        private JsonReader JsonWeapons;
        public static string dataProjectArmorsFile = "Armors.json";
        private JsonReader JsonArmors;
        public static string dataProjectEnemiesFile = "Enemies.json";
        private JsonReader JsonEnemies;

        public static string dataProjectActorsFile = "";
        public static string dataProjectAnimationsFile = "";
        public static string dataProjectClassesFile = "";
        public static string dataProjecCommonEventsFile = "";
        public static string dataProjectSkillsFile = "";
        public static string dataProjectStatesFile = "";
        public static string dataProjectSystemFile = "";
        public static string dataProjectTilesetsFile = "";
        public static string dataProjectTroopsFile = "";

        public DataBaseFiles(string dirname)
        {
            this.dataProjectDirInfo = new DirectoryInfo(dirname);

            if (this.dataProjectDirInfo.Exists)
            {
                List<string> arrayFiles = new List<string>(Directory.GetFiles(this.dataProjectDirInfo.ToString()));

                if (arrayFiles.Contains(this.dataProjectDirInfo.ToString() + "\\" + DataBaseFiles.dataProjectItemsFile))
                {
                    this.JsonItem = JsonConvert.DeserializeObject<List<Rm_DataBase_Item>>(File.ReadAllText(this.dataProjectDirInfo.ToString() + "\\" + DataBaseFiles.dataProjectItemsFile));
                }
            }
        }

        public List<Rm_DataBase_Item> Items { get { return this.JsonItem; } }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.Script.Serialization;


namespace RM_DataBase_classes.DataClass 
{
	public class Rm_DataBase_Object_Base : iRmDbObject

    {
        protected int 				prop_id;
        protected string 			prop_description;
        protected int 				prop_iconIndex;
        protected string 			prop_name;
        protected string 			prop_note;
        protected int 				prop_price;

        
        public 	int id 				{ get{return this.prop_id;} 			set{this.prop_id = value;} }
        public 	string description 	{ get{return this.prop_description;} 	set{this.prop_description = value;} }
        public 	int iconIndex 		{ get{return this.prop_iconIndex;} 		set{this.prop_iconIndex = value;} }
        public 	string name 		{ get{return this.prop_name;} 			set{this.prop_name = value;} }
        public 	int price 			{ get{return this.prop_price;} 			set{this.prop_price = value;} }

        public 	string note			
        { 
        	get{return this.prop_note;} 			
        	set{this.prop_note = value;} 
        }

        
        [ScriptIgnore]
        public Image icon {get{return DataBaseFiles.GetIcon(this.iconIndex);}}
        
		public override string ToString()
		{
			return this.id + " : " + this.name;
		}

        public Rm_DataBase_Object_Base()
        {
			this.id = 0;
        	this.description = "";
        	this.iconIndex = 0;
        	this.name = "noname";
        	this.note = "";
        	this.price = 0;
        }
        
        public iRmDbObject Clone(){
        	Rm_DataBase_Item newObj = new Rm_DataBase_Item();
        	newObj.id = this.id;
        	newObj.description = this.description;
        	newObj.iconIndex = this.iconIndex;
        	newObj.name = this.name;
        	newObj.note = this.note;
        	newObj.price = this.price;
        	
        	return newObj;
        }
    }
}

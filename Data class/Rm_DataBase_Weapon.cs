using System;
using System.Collections.Generic;


namespace RM_DataBase_classes.DataClass 
{
	public class Rm_DataBase_Weapon : iRmDbObject

    {
        private int 				prop_id;
        private int 				prop_animationId;
        private string 				prop_description;
        private int 				prop_etypeId;
        private object 				prop_traits;
        private int 				prop_iconIndex;
        private string 				prop_name;
        private string 				prop_note;
        private object[] 			prop_params;
        private int 				prop_price;
        private int 				prop_wtypeId;
        
        public 	int id 				{ get{return this.prop_id;} 			set{this.prop_id = value;} }
        public 	int animationId 	{ get{return this.prop_animationId;} 	set{this.prop_animationId = value;} }
        public 	string description 	{ get{return this.prop_description;} 	set{this.prop_description = value;} }
        public 	int etypeId 		{ get{return this.prop_etypeId;} 		set{this.prop_etypeId = value;} }
        public 	object traits 		{ get{return this.prop_traits;} 		set{this.prop_traits = value;} }
        public 	int iconIndex 		{ get{return this.prop_iconIndex;} 		set{this.prop_iconIndex = value;} }
        public 	string name 		{ get{return this.prop_name;} 			set{this.prop_name = value;} }
        public 	string note			{ get{return this.prop_note;} 			set{this.prop_note = value;} }
        public 	object[] p_params 	{ get{return this.prop_params;}			set{this.prop_params = value;} }
        public 	int price 			{ get{return this.prop_price;} 			set{this.prop_price = value;} }
        public 	int wtypeId 		{ get{return this.prop_wtypeId;} 		set{this.prop_wtypeId = value;} }
        
        public Rm_DataBase_Weapon()
        {
			this.id = 0;
        	this.animationId = 0;
        	this.description = "";
        	this.iconIndex = 0;
        	this.name = "noname";
        	this.note = "";
        	this.price = 0;
        }
        
        public iRmDbObject Clone(){
        	Rm_DataBase_Item newObj = new Rm_DataBase_Item();
        	newObj.id = this.id;
        	newObj.animationId = this.animationId;
        	newObj.description = this.description;
        	newObj.iconIndex = this.iconIndex;
        	newObj.name = this.name;
        	newObj.note = this.note;
        	newObj.price = this.price;
        	
        	return newObj;
        }
    }
}

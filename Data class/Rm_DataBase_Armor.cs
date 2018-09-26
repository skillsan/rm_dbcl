using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.Script.Serialization;


namespace RM_DataBase_classes.DataClass 
{
	public class Rm_DataBase_Armor : Rm_DataBase_Object_Base

    {
        private int                 prop_atypeId;
        private int 				prop_etypeId;
        private object 				prop_traits;
        private object[] 			prop_params;
        
        public 	int atypeId         { get{return this.prop_atypeId; } 	    set{this.prop_atypeId = value;} }
        public 	int etypeId 		{ get{return this.prop_etypeId;} 		set{this.prop_etypeId = value;} }
        public 	object traits 		{ get{return this.prop_traits;} 		set{this.prop_traits = value;} }
        public 	object[] p_params 	{ get{return this.prop_params;}			set{this.prop_params = value;} }


        public override string ToString()
        {
            return this.id + " : " + this.name;
        }

        public Rm_DataBase_Armor()
        {
			this.id = 0;
        	this.prop_atypeId = 0;
        	this.description = "";
        	this.iconIndex = 0;
        	this.name = "noname";
        	this.note = "";
        	this.price = 0;
        }
        
        public new iRmDbObject Clone(){
            Rm_DataBase_Armor newObj = new Rm_DataBase_Armor();
        	newObj.id = this.id;
        	newObj.atypeId = this.prop_atypeId;
        	newObj.description = this.description;
        	newObj.iconIndex = this.iconIndex;
        	newObj.name = this.name;
        	newObj.note = this.note;
        	newObj.price = this.price;
        	
        	return newObj;
        }
    }
}

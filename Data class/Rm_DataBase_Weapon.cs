﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.Script.Serialization;


namespace RM_DataBase_classes.DataClass 
{
	public class Rm_DataBase_Weapon : Rm_DataBase_Object_Base

    {
        private int 				prop_animationId;
        private int 				prop_etypeId;
        private object 				prop_traits;
        private object[] 			prop_params;
        private int 				prop_wtypeId;
        
        public 	int animationId 	{ get{return this.prop_animationId;} 	set{this.prop_animationId = value;} }
        public 	int etypeId 		{ get{return this.prop_etypeId;} 		set{this.prop_etypeId = value;} }
        public 	object traits 		{ get{return this.prop_traits;} 		set{this.prop_traits = value;} }
        public 	object[] p_params 	{ get{return this.prop_params;}			set{this.prop_params = value;} }
        public 	int wtypeId 		{ get{return this.prop_wtypeId;} 		set{this.prop_wtypeId = value;} }

        public override string ToString()
        {
            return this.id + " : " + this.name;
        }

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
        
        public new iRmDbObject Clone(){
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

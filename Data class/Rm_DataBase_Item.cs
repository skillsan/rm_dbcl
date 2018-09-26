using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.Script.Serialization;


namespace RM_DataBase_classes.DataClass 
{
	public class Rm_DataBase_Item : Rm_DataBase_Object_Base

    {
        private int 				prop_animationId;
        private bool 				prop_consumable;
        private Rm_DataBase_Damage  prop_damage;
        private object[] 			prop_effects;
        private int 				prop_hitType;
        private int 				prop_itypeId;
        private int 				prop_occasion;
        private int 				prop_repeats;
        private int 				prop_scope;
        private int 				prop_speed;
        private int 				prop_successRate;
        private int 				prop_tpGain;

        
        public 	int animationId 	{ get{return this.prop_animationId;} 	set{this.prop_animationId = value;} }
        public 	bool consumable		{ get{return this.prop_consumable;} 	set{this.prop_consumable = value;} }
        public  Dictionary<string, object> damage 
        { 
        	get
        	{
        		Dictionary<string,object> o_out = new Dictionary<string, object>(5);
        		o_out.Add("critical", this.prop_damage.critical);
        		o_out.Add("elementId", this.prop_damage.elementId);
        		o_out.Add("formula", this.prop_damage.formula);
        		o_out.Add("type", this.prop_damage.type);
        		o_out.Add("variance", this.prop_damage.variance);
        		
        		return o_out;
        	} 
        	
        	set
        	{
        		if (value != null)
	        		this.prop_damage = new Rm_DataBase_Damage(
	        			(bool)value["critical"],
	        			(int)value["elementId"],
	        			(string)value["formula"],
	        			(int)value["type"],
	        			(int)value["variance"]
	        		);
        		else
        			this.prop_damage = new Rm_DataBase_Damage();
        	}
        }
        public 	object[] effects 	{ get{return this.prop_effects;} 		set{this.prop_effects = value;} }
        public 	int hitType 		{ get{return this.prop_hitType;} 		set{this.prop_hitType = value;} }
        public 	int itypeId 		{ get{return this.prop_itypeId;} 		set{this.prop_itypeId = value;} }
        public 	int occasion 		{ get{return this.prop_occasion;}		set{this.prop_occasion = value;} }
        public 	int repeats 		{ get{return this.prop_repeats;} 		set{this.prop_repeats = value;} }
        public 	int scope 			{ get{return this.prop_scope;} 			set{this.prop_scope = value;} }
        public 	int speed 			{ get{return this.prop_speed;} 			set{this.prop_speed = value;} }
        public 	int successRate 	{ get{return this.prop_successRate;} 	set{this.prop_successRate = value;} }
        public 	int tpGain 			{ get{return this.prop_tpGain;}			set{this.prop_tpGain = value;} }
               
		public override string ToString()
		{
			return this.id + " : " + this.name;
		}

        public Rm_DataBase_Item()
        {
			this.id = 0;
        	this.animationId = 0;
        	this.consumable = false;
        	this.damage = null;
        	this.description = "";
        	this.effects = null;
        	this.hitType = 0;
        	this.iconIndex = 0;
        	this.itypeId = 0;
        	this.name = "noname";
        	this.note = "";
        	this.occasion = 0;
        	this.price = 0;
        	this.repeats = 0;
        	this.scope = -1;
        	this.speed = 1;
        	this.successRate = 0;
        	this.tpGain = 0;
        }
        
        public new iRmDbObject Clone(){
        	Rm_DataBase_Item newObj = new Rm_DataBase_Item();
        	newObj.id = this.id;
        	newObj.animationId = this.animationId;
        	newObj.consumable = this.consumable;
        	newObj.description = this.description;
        	newObj.damage = this.damage;
        	newObj.effects = this.effects;
        	newObj.hitType = this.hitType;
        	newObj.iconIndex = this.iconIndex;
        	newObj.itypeId = this.itypeId;
        	newObj.name = this.name;
        	newObj.note = this.note;
        	newObj.occasion = this.occasion;
        	newObj.price = this.price;
        	newObj.repeats = this.repeats;
        	newObj.scope = this.scope;
        	newObj.speed = this.speed;
        	newObj.successRate = this.successRate;
        	newObj.tpGain = this.tpGain;
        	
        	return newObj;
        }
    }
}

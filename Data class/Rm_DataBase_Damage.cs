/*
 * Crée par SharpDevelop.
 * Utilisateur: jhohweiller
 * Date: 21/08/2018
 * Heure: 16:26
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Reflection;
using System.Collections.Generic;

namespace RM_DataBase_classes.DataClass
{
	/// <summary>
	/// Description of Rm_DataBase_Damage.
	/// </summary>
	public class Rm_DataBase_Damage
	{
		private bool prop_critical;
		private int prop_elementId;
		private string prop_formula;
		private int prop_type;
		private int prop_variance;
		
		public bool critical { get{return this.prop_critical;} set{this.prop_critical = value;} }
		public int elementId { get{return this.prop_elementId;} set{this.prop_elementId = value;} }
		public string formula { get{return this.prop_formula;} set{this.prop_formula = value;} }
		public int type { get{return this.prop_type;} set{this.prop_type = value;} }
		public int variance { get{return this.prop_variance;} set{this.prop_variance = value;} }
		
		public Rm_DataBase_Damage()
		{
			this.prop_critical = false;
			this.prop_elementId = 0;
			this.prop_formula = "";
			this.prop_type = 0;
			this.prop_variance = 0;
		}
		
		public Rm_DataBase_Damage(bool crit, int elid, string formula, int type, int var)
		{
			this.prop_critical = crit;
			this.prop_elementId = elid;
			this.prop_formula = formula;
			this.prop_type = type;
			this.prop_variance = var;
		}
		
		public Rm_DataBase_Damage Clone()
		{
			Rm_DataBase_Damage newobj = new Rm_DataBase_Damage();
			newobj.critical = this.prop_critical;
			newobj.elementId = this.prop_elementId;;
			newobj.formula = this.prop_formula;
			newobj.type = this.prop_type;
			newobj.variance = this.prop_variance;
			return newobj;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.CharacterClasses
{
    public class EntityData
    {
        #region Field Region

        public string EntityName;

        public int Strength;
        public int Dexterity;
        public int Cunning;
        public int Willpower;
        public int Magic;
        public int Constitution;

        public string HealthFormula;
        public string StaminaFormula;
        public string MagicFormula;

        #endregion

        #region Constructor Region
        
        private EntityData()
        {
        }

        public EntityData(
            string entityName, 
            int strength, 
            int dexterity, 
            int cunning, 
            int willpower, 
            int magic, 
            int constitution, 
            string health, 
            string stamina, 
            string mana)
        {
            EntityName = entityName;
            Strength = strength;
            Dexterity = dexterity;
            Cunning = cunning;
            Willpower = willpower;
            Cunning = cunning;
            Willpower = willpower;
            Magic = magic;
            Constitution = constitution;
            HealthFormula = health;
            StaminaFormula = stamina;
            MagicFormula = mana;
        }

        #endregion

        #region Method Region

        public override string ToString()
        {
            string toString = EntityName + ", ";
            toString += Strength.ToString() + ", ";
            toString += Dexterity.ToString() + ", ";
            toString += Cunning.ToString() + ", ";
            toString += Willpower.ToString() + ", ";
            toString += Magic.ToString() + ", ";
            toString += Constitution.ToString() + ", ";
            toString += HealthFormula + ", ";
            toString += StaminaFormula + ", ";
            toString += MagicFormula;

            return toString;
        }

        public object Clone()
        {
            EntityData data = new EntityData();

            data.EntityName = this.EntityName;
            data.Strength = this.Strength;
            data.Dexterity = this.Dexterity;
            data.Cunning = this.Cunning;
            data.Willpower = this.Willpower;
            data.Magic = this.Magic;
            data.Constitution = this.Constitution;
            data.HealthFormula = this.HealthFormula;
            data.StaminaFormula = this.StaminaFormula;
            data.MagicFormula = this.MagicFormula;

            return data;
        }

        #endregion
    }
}

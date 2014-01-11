using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RpgLibrary.SkillClasses;
using RpgLibrary.SpellClasses;

using RpgLibrary.EffectClasses;

namespace RpgLibrary.CharacterClasses
{
    
    public enum EntityType { Character, NPC, Monster, Creature }

    public sealed class Entity
    {
        #region Vital Field and Property Region

        private string entityName;
        private string entityClass;
        private EntityType entityType;
        

        public string EntityName
        {
            get { return entityName; }
            private set { entityName = value; }
        }

        public string EntityClass
        {
            get { return entityClass; }
            private set { entityClass = value; }
        }

        public EntityType EntityType
        {
            get { return entityType; }
            private set { entityType = value; }
        }


        #endregion

        #region Skill Field and Property Region

        readonly Dictionary<string, Skill> skills;
        readonly List<Modifier> skillModifiers;

        public Dictionary<string, Skill> Skills
        {
            get { return skills; }
        }

        public List<Modifier> SkillModifiers
        {
            get { return skillModifiers; }
        }

        #endregion

        #region Spell Field and Property Region

        readonly Dictionary<string, Spell> spells;
        readonly List<Modifier> spellModifiers;

        public Dictionary<string, Spell> Spells
        {
            get { return spells; }
        }

        public List<Modifier> SpellModifiers
        {
            get { return spellModifiers; }
        }

        #endregion

        #region Talent Field and Property Region

        
        readonly List<Modifier> talentModifiers;

      


        #endregion

        #region Basic Attribute and Property Region

        public int strength;
        public int dexterity;
        public int cunning;
        public int willpower;


        public int strengthModifier;
        public int dexterityModifier;
        public int cunningModifier;
        public int willpowerModifier;
        

        public int Strength
        {
            get { return strength + strengthModifier; }
            private set { strength = value; }
        }

        public int Dexterity
        {
            get { return dexterity + dexterityModifier; }
            private set { dexterity = value; }
        }

        public int Cunning
        {
            get { return cunning + cunningModifier; }
            private set { cunning = value; }
        }


        public int Willpower
        {
            get { return willpower + willpowerModifier; }
            private set { willpower = value; }
        }

       

        #endregion

        #region Calculated Attribute Field and Property Region

        private AttributePair health;
        private AttributePair stamina;
        private AttributePair mana;

        public AttributePair Health
        {
            get { return health; }
        }

        public AttributePair Stamina
        {
            get { return stamina; }
        }

        public AttributePair Mana
        {
            get { return mana; }
        }

       
        private int damage;
        private int defense;

        #endregion

        //#region Resistance and Weakness Field and Property Region

        //private readonly List<Resistance> resistances;

        //public List<Resistance> Resistances
        //{
        //    get { return resistances; }
        //}

        //private readonly List<Weakness> weaknesses;

        //public List<Weakness> Weaknesses
        //{
        //    get { return weaknesses; }
        //}

        //#endregion

        #region Level Field and Property Region

        private int level;
        private long experience;

        public int Level
        {
            get { return level; }
            private set { level = value; }
        }

        public long Experience
        {
            get { return experience; }
            private set { experience = value; }
        }

        #endregion

        #region Constructor Region

        private Entity()
        {
            Strength = 10;
            Dexterity = 10;
            Cunning = 10;
            Willpower = 10;
    
            health = new AttributePair(0);
           
            mana = new AttributePair(0);

            skills = new Dictionary<string, Skill>();
            spells = new Dictionary<string, Spell>();
        
            skillModifiers = new List<Modifier>();
            spellModifiers = new List<Modifier>();
           

           
        }

        public Entity(
            string name, 
            EntityData entityData, 
             
            EntityType entityType) : this()
        {
            EntityName = name;
            EntityClass = entityData.EntityName;
           
            EntityType = entityType;

            Strength = entityData.Strength;
            Dexterity = entityData.Dexterity;
            Cunning = entityData.Cunning;
            Willpower = entityData.Willpower;
           
            health = new AttributePair(0);
            stamina = new AttributePair(0);
            mana = new AttributePair(0);
        }

        #endregion

        #region Method Region

        public void Update(TimeSpan elapsedTime)
        {
            foreach (Modifier modifier in skillModifiers)
                modifier.Update(elapsedTime);

            foreach (Modifier modifier in spellModifiers)
                modifier.Update(elapsedTime);

            foreach (Modifier modifier in talentModifiers)
                modifier.Update(elapsedTime);
        }

        #endregion
    }
}

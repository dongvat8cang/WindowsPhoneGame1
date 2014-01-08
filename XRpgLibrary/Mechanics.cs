using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RpgLibrary.CharacterClasses;
using RpgLibrary.SkillClasses;

namespace RpgLibrary
{
    public enum DieType { D4 = 4, D6 = 6, D8 = 8, D10 = 10, D12 = 12, D20 = 20, D100 = 100 }

    public static class Mechanics
    {
        #region Field Region

        static Random random = new Random();

        #endregion

        #region Property Region
        #endregion

        #region Constructor Region
        #endregion

        #region Method Region

        public static int RollDie(DieType die)
        {
            return random.Next(0, (int)die) + 1;
        }

        public static bool UseSkill(Skill skill, Entity entity, DifficultyLevel difficulty)
        {
            bool result = false;

            int target = skill.SkillValue + (int)difficulty;

            foreach (string s in skill.ClassModifiers.Keys)
                if (s == entity.EntityClass)
                    target += skill.ClassModifiers[s];

            foreach (Modifier m in entity.SkillModifiers)
            {
                if (m.Modifying == skill.SkillName)
                {
                    target += m.Amount;
                }
            }

            string lower = skill.PrimaryAttribute.ToLower();

            switch (lower)
            {
                case "strength":
                    target += Skill.AttributeModifier(entity.Strength);
                    break;
                case "dexterity":
                    target += Skill.AttributeModifier(entity.Dexterity);
                    break;
                case "cunning":
                    target += Skill.AttributeModifier(entity.Cunning);
                    break;
                case "willpower":
                    target += Skill.AttributeModifier(entity.Willpower);
                    break;
                case "magic":
                    target += Skill.AttributeModifier(entity.Magic);
                    break;
                case "constitution":
                    target += Skill.AttributeModifier(entity.Constitution);
                    break;
            }

            if (Mechanics.RollDie(DieType.D100) <= target)
                result = true;

            return result;
        }

        public static int GetAttributeByString(Entity entity, string attribute)
        {
            int value = 0;

            switch (attribute.ToLower())
            {
                case "strength":
                    value = entity.Strength;
                    break;
                case "dexterity":
                    value = entity.Dexterity;
                    break;
                case "cunning":
                    value = entity.Cunning;
                    break;
                case "willpower":
                    value = entity.Willpower;
                    break;
                case "magic":
                    value = entity.Magic;
                    break;
                case "constitution":
                    value = entity.Constitution;
                    break;
            }

            return value;
        }

        #endregion

        #region Virtual Method Region
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

using RpgLibrary.CharacterClasses;
using RpgLibrary.ItemClasses;
using RpgLibrary.SkillClasses;
using RpgLibrary.SpellClasses;


namespace WindowsPhoneGame1.Components
{
    static class DataManager
    {
        #region Field Region

        static Dictionary<string, ArmorData> armor = new Dictionary<string,ArmorData>();
       

        static Dictionary<string, EntityData> entities = new Dictionary<string,EntityData>();

        static Dictionary<string, SkillData> skills = new Dictionary<string, SkillData>();

        #endregion

        #region Property Region

        public static Dictionary<string, ArmorData> ArmorData
        {
            get { return armor; }
        }


        public static Dictionary<string, EntityData> EntityData
        {
            get { return entities; }
        }

       

        public static Dictionary<string, SkillData> SkillData
        {
            get { return skills; }
        }

        #endregion

        #region Constructor Region
        #endregion

        #region Method Region

        public static void ReadEntityData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Classes", "*.xnb");

            foreach (string name in filenames)
            {
                string filename = @"Game\Classes\" + Path.GetFileNameWithoutExtension(name);
                EntityData data = Content.Load<EntityData>(filename);
                EntityData.Add(data.EntityName, data);
            }
        }

        public static void ReadArmorData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Items\Armor", "*.xnb");

            foreach (string name in filenames)
            {
                string filename = @"Game\Items\Armor\" + Path.GetFileNameWithoutExtension(name);
                ArmorData data = Content.Load<ArmorData>(filename);
                ArmorData.Add(data.Name, data);
            }
        }

      

     
        public static void ReadSkillData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Skills", "*.xnb");

            foreach (string name in filenames)
            {
                string filename = @"Game\Skills\" + Path.GetFileNameWithoutExtension(name);
                SkillData data = Content.Load<SkillData>(filename);
                SkillData.Add(data.Name, data);
            }
        }

        #endregion

        #region Virtual Method region
        #endregion
    }
}

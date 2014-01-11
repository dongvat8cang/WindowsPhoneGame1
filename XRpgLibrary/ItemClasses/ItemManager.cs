using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class ItemManager
    {
        #region Fields Region

        Dictionary<string, Armor> armors = new Dictionary<string, Armor>();
       

        #endregion

        #region Keys Property Region

   
        public Dictionary<string, Armor>.KeyCollection ArmorKeys
        {
            get { return armors.Keys; }
        }


        #endregion

        #region Constructor Region

        public ItemManager()
        {
        }

        #endregion

        #region Weapon Methods

   



        #endregion

        #region Armor Methods

        public void AddArmor(Armor armor)
        {
            if (!armors.ContainsKey(armor.Name))
            {
                armors.Add(armor.Name, armor);
            }
        }

        public Armor GetArmor(string name)
        {
            if (armors.ContainsKey(name))
            {
                return (Armor)armors[name].Clone();
            }

            return null;
        }

        public bool ContainsArmor(string name)
        {
            return armors.ContainsKey(name);
        }

        #endregion

        #region Shield Methods

    


        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.ItemClasses
{
    public class ItemDataManager
    {
        #region Field Region

        readonly Dictionary<string, ArmorData> armorData = new Dictionary<string, ArmorData>();
      
        

        #endregion

        #region Property Region

        public Dictionary<string, ArmorData> ArmorData
        {
            get { return armorData; }
        }

   

     

      

        #endregion

        #region Constructor Region
        #endregion

        #region Method Region
        #endregion
    }
}
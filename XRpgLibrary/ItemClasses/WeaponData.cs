using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RpgLibrary.EffectClasses;

namespace RpgLibrary.ItemClasses
{
    public class WeaponData
    {
        public string Name;
        public string Type;
        public int Price;
        public float Weight;
        public bool Equipped;
        public Hands NumberHands;
        public int AttackValue;
        public int AttackModifier;
        public DamageEffectData DamageEffectData;
        public string[] AllowableClasses;

        public WeaponData()
        {
            DamageEffectData = new DamageEffectData();
        }

        public override string ToString()
        {
            string toString = Name + ", ";
            toString += Type + ", ";
            toString += Price.ToString() + ", ";
            toString += Weight.ToString() + ", ";
            toString += NumberHands.ToString() + ", ";
            toString += AttackValue.ToString() + ", ";
            toString += AttackModifier.ToString() + ", ";
            toString += DamageEffectData.ToString();

            foreach (string s in AllowableClasses)
                toString += ", " + s;

            return toString;
        }
    }
}

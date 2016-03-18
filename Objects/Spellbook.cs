using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ZzukBot.ExtensionFramework.Classes;
using ZzukBot.Game.Statics;
using ZzukBot.Objects;
using CustomClassTemplate.Data;
using CustomClassTemplate.Settings;

namespace CustomClassTemplate.Objects
{
    internal class Spellbook
    {
        private static Spell lastSpell = new Spell(string.Empty, -1, false, false);

        private List<Spell> spells;
       // public string ShieldName = "";      For Gui To chose shield!

        //--Healing Spells--//
        //---------------------------------------------------------------------------------------------------------Shield--//
        public static readonly Spell Shield = new Spell("Holy Shield", 310, false, false,
            isWanted:
                () =>
                //--What Parametters to take care of before casting--//
                    Helpers.CanCast("Holy Shield") && !Me.GotAura("Holy Shield"), customAction:
                () =>
                {
                    //--Custom Action - SelfCasting--//
                    Helpers.TryBuff("Holy Shield");
                });
        //----------------------------------------------------------------------------------------------------Flash Heal--//
        public static readonly Spell FlashHeal = new Spell("Flash of Light", 320, false, false,
            isWanted:
                () =>
                //--What Parametters to take care of before casting--//
                    Me.HealthPercent <= 60 &&
                    Helpers.CanCast("Flash of Light"), customAction:
                () =>
                {
                    //--Custom Action - SelfCasting--//
                    Helpers.TryBuff("Flash of Light");
                });
        //-----------------------------------------------------------------------------------------------------Holy Light--//
        public static readonly Spell HolyLight = new Spell("Holy Light", 330, false, false,
            isWanted:
                () =>
                //--What Parametters to take care of before casting--//
                    Helpers.CanCast("Holy Light") && Me.HealthPercent <= 40, customAction:
                () =>
                {
                    //--Custom Action - SelfCasting--//
                    Helpers.TryBuff("Holy Light");
                });
        //-----------------------------------------------------------------------------------------------------Holy Light--//
        public static readonly Spell LayonCock = new Spell("Lay on Hands", 330, false, false, true,
            isWanted:
                () =>
                //--What Parametters to take care of before casting--//
                    Helpers.CanCast("Lay on Hands") && Me.HealthPercent <= 20, customAction:
                () =>
                {
                    //--Custom Action - SelfCasting--//
                    Helpers.TryBuff("Lay on Hands");
                });

        //--Dmg Spells--//
        //-----------------------------------------------------------------------------------------------------------Seal--//
        public static readonly Spell Seal = new Spell(CustomClassSettings.Values.WeaponEnchant, 310, false, false,
           isWanted:
               () =>
                   //--What Parametters to take care of before casting--//
                   Helpers.CanCast(CustomClassSettings.Values.WeaponEnchant) && !Me.GotAura(CustomClassSettings.Values.WeaponEnchant), customAction:
               () =>
               {
                    //--Custom Action - SelfCasting--//
                    Helpers.TryBuff(CustomClassSettings.Values.WeaponEnchant);
               });
        //-------------------------------------------------------------------------------------------------------Judgement--//
        public static readonly Spell Judgement = new Spell("Judgement", 750, false, true, true,
            isWanted:
                () =>
                //--What Parametters to take care of before casting--//
                    Helpers.CanCast("Judgement") && !Me.GotAura(CustomClassSettings.Values.WeaponEnchant)
                 && Me.ManaPercent >= 10, 
            customAction:
                () =>
                {
                    Helpers.TryCast("Judgement");                    
                });
        
        //------------------------------------------------------------------------------------------------------Earth Shock--//
        public static readonly Spell Consecration = new Spell("Consecration", 700, false, true, true,
            isWanted:
                () =>
                //--What Parametters to take care of before casting--//
                    Helpers.CanCast("Consecration") && Target.Position.GetDistanceTo(Me.Position) <= 9, 
            customAction:
                () =>
                {
                    Helpers.TryCast("Consecration");                    
                });
        //-------------------------------------------------------------------------------------------------------Holy Shield--//
        public static readonly Spell HolyShield = new Spell("Holy Shield", 600, false, true, true, 
            isWanted:
                () =>
                //--What Parametters to take care of before casting--//
                    Helpers.CanCast("Holy Shield") && !Me.GotAura("Holy Shield"), customAction:
                () =>
                {
                    //--Custom Action - SelfCasting--//
                    Helpers.TryBuff("Holy Shield");
                });
        //--------------------------------------------------------------------------------------------------Hammer of Justice--//
        public static readonly Spell HammerofJustice = new Spell("Hammer of Justice", 650, false, true, true,
           isWanted:
               () =>
               //--What Parametters to take care of before casting--//                   
                   Helpers.CanCast("Hammer of Justice") && Target.HealthPercent >= 20, customAction:
                () =>
                {                    
                        Helpers.TryCast("Hammer of Justice");                                
                });
        //---------------------------------------------------------------------------------------------------Stoneclaw Totem--//
        public static readonly Spell HammerofWrath = new Spell("Hammer of Wrath", 150, false, true, true,
           isWanted:
               () =>
                   //--What Parametters to take care of before casting--//
                   //--What Parametters to take care of before casting--//                   
                   Helpers.CanCast("Hammer of Wrath") && Target.HealthPercent <= 20, customAction:
                () =>
                {
                    Helpers.TryCast("Hammer of Wrath");
                });
        //---------------------------------------------------------------------------------------------------Stoneclaw Totem--//
        public static readonly Spell Buff = new Spell(CustomClassSettings.Values.Buff, 310, true, false,
          isWanted:
              () =>
                  //--What Parametters to take care of before casting--//
                  Helpers.CanCast(CustomClassSettings.Values.Buff) && !Me.GotAura(CustomClassSettings.Values.Buff), customAction:
              () =>
              {
                   //--Custom Action - SelfCasting--//
                   Helpers.TryBuff(CustomClassSettings.Values.Buff);
              });

        //--If No Mana--//
        //--------------------------------------------------------------------------------------------------------Shoot Wand--//
        public static readonly Spell Attack = new Spell("Attack", 50, false, true, true, false,
            () => (!Helpers.CanCast("Lightning Bolt") && !Helpers.CanCast("Earth Shock") && !Helpers.CanCast("Flame Shock")) || Me.ManaPercent <= 15 && Helpers.CanCast("Attack"), customAction:
                () =>
                {   
                    ZzukBot.Game.Statics.Spell.Instance.Attack();
                });

        //-------------------------------------------------------------------------------------------------------------------//
        public Spellbook()
        {
            this.spells = new List<Spell>();
            this.InitializeSpellbook();
        }
        //-------------------------------------------------------------------------------------------------------------------//
        public IEnumerable<Spell> GetDamageSpells()
        {
            return Cache.Instance.GetOrStore("damageSpells", () => this.spells.Where(s => !s.IsBuff));
        }
        //-------------------------------------------------------------------------------------------------------------------//
        public IEnumerable<Spell> GetBuffSpells()
        {
            return Cache.Instance.GetOrStore("buffSpells", () => this.spells.Where(s => s.IsBuff && !s.DoesDamage));
        }

        
        //-------------------------------------------------------------------------------------------------------------------//
        public void UpdateLastSpell(Spell spell)
        {
            lastSpell = spell;
        }
        //-------------------------------------------------------------------------------------------------------------------//
        private void InitializeSpellbook()
        {
            foreach (var property in this.GetType().GetFields())
            {
                spells.Add(property.GetValue(property) as Spell);
            }

            spells = spells.OrderBy(s => s.Priority).ToList();
        }
        //-------------------------------------------------------------------------------------------------------------------//
        private static WoWUnit Me
        {
            get { return ObjectManager.Instance.Player; }
        }
        //-------------------------------------------------------------------------------------------------------------------//
        private static WoWUnit Target
        {
            get { return ObjectManager.Instance.Target; }
        }
        //-------------------------------------------------------------------------------------------------------------------//
        private static WoWUnit Pet
        {
            get { return ObjectManager.Instance.Pet; }
        }
        //-------------------------------------------------------------------------------------------------------------------//
    }
}

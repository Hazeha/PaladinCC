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
       

        //--Healing Spells--//        
        //----------------------------------------------------------------------------------------------------Flash Heal--//
        public static readonly Spell FlashHeal = new Spell("Flash of Light", 1400, false, false,
            isWanted:
                () =>
                //--What Parametters to take care of before casting--//
                    Me.HealthPercent <= 60 &&
                    Helpers.CanCast("Flash of Light"),
            customAction:
                () =>
                {
                    Helpers.TryCast("Flash of Light");
                });
        //-----------------------------------------------------------------------------------------------------Holy Light--//
        public static readonly Spell HolyLight = new Spell("Holy Light", 1500, false, false,
            isWanted:
                () =>
                //--What Parametters to take care of before casting--//
                    Helpers.CanCast("Holy Light") && Me.HealthPercent <= 40,
            customAction:
                () =>
                {
                    Helpers.TryCast("Holy Light");
                });
        //-----------------------------------------------------------------------------------------------------Holy Light--//
        public static readonly Spell LayonCock = new Spell("Lay on Hands", 700, false, false, true,
            isWanted:
                () =>
                //--What Parametters to take care of before casting--//
                    Helpers.CanCast("Lay on Hands") && Me.HealthPercent <= 20);

        //--Dmg Spells--//
        //-----------------------------------------------------------------------------------------------------------Seal--//
        public static readonly Spell Seal = new Spell(CustomClassSettings.Values.WeaponEnchant, 1000, false, false,
           isWanted:
               () =>
                   //--What Parametters to take care of before casting--// 
                   !Me.GotAura(CustomClassSettings.Values.WeaponEnchant) &&
                   Helpers.CanCast(CustomClassSettings.Values.WeaponEnchant), customAction:
                () =>
                {
                    //--Custom Action - SelfCasting--//
                    Helpers.ShouldBuffSelf(CustomClassSettings.Values.WeaponEnchant);
                });  
        //-------------------------------------------------------------------------------------------------------Judgement--//
        public static readonly Spell Judgement = new Spell("Judgement", 600, false, true, true,
            isWanted:
                () =>
                //--What Parametters to take care of before casting--//
                    Helpers.CanCast("Judgement") && Me.GotAura(CustomClassSettings.Values.WeaponEnchant)
                 && Me.ManaPercent >= 10, 
            customAction:
                () =>
                {
                    Helpers.TryCast("Judgement");                    
                });
        
        //------------------------------------------------------------------------------------------------------Earth Shock--//
        public static readonly Spell Consecration = new Spell("Consecration", 400, false, true, true,
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
        public static readonly Spell HolyShield = new Spell("Holy Shield", 200, false, true, true, 
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
        public static readonly Spell HammerofJustice = new Spell("Hammer of Justice", 300, false, true, true,
           isWanted:
               () =>
               //--What Parametters to take care of before casting--//                   
                   Helpers.CanCast("Hammer of Justice") && Target.HealthPercent >= 20, customAction:
                () =>
                {                    
                        Helpers.TryCast("Hammer of Justice");                                
                });
        //---------------------------------------------------------------------------------------------------Hammer of Wrath--//
        public static readonly Spell HammerofWrath = new Spell("Hammer of Wrath", 100, false, true, true,
           isWanted:
               () =>
                   //--What Parametters to take care of before casting--//
                   //--What Parametters to take care of before casting--//                   
                   Helpers.CanCast("Hammer of Wrath") && Target.HealthPercent <= 20, customAction:
                () =>
                {
                    Helpers.TryCast("Hammer of Wrath");
                });
        //---------------------------------------------------------------------------------------------------Blesseing Buff--//
        public static readonly Spell Buff = new Spell(CustomClassSettings.Values.Buff, 1200, true, false,
          isWanted:
              () =>
                  //--What Parametters to take care of before casting--//
                  Helpers.CanCast(CustomClassSettings.Values.Buff) && !Me.GotAura(CustomClassSettings.Values.Buff), customAction:
                () =>
                {
                    //--Custom Action - SelfCasting--//
                    Helpers.ShouldBuffSelf(CustomClassSettings.Values.Buff);
                });
        //---------------------------------------------------------------------------------------------------------Aura Buff--//
        public static readonly Spell BuffAura = new Spell(CustomClassSettings.Values.Aura, 1100, true, false,
          isWanted:
              () =>
                  //--What Parametters to take care of before casting--//
                  Helpers.CanCast(CustomClassSettings.Values.Aura) && !Me.GotAura(CustomClassSettings.Values.Aura), customAction:
                () =>
                {
                    //--Custom Action - SelfCasting--//
                    Helpers.ShouldBuffSelf(CustomClassSettings.Values.Aura);
                });

        //--If No Mana--//
        //--------------------------------------------------------------------------------------------------------Shoot Wand--//
        public static readonly Spell Attack = new Spell("Attack", 1000, false, true, true, false,
            () => Helpers.CanCast("Attack"), customAction:
                () =>                {   
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

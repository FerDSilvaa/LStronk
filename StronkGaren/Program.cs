using System;
using System.Linq;
using LeagueSharp;
using SharpDX;
using LeagueSharp.Common;

namespace StronkGaren
{
    public class Program
    {
        //Geral Settings
        private static String championName = "Garen"; 
        private static Obj_AI_Hero Player;
        public static Menu menu;
        private static Orbwalking.Orbwalker Orbwalker;
        public static Spell Q, W, E, R;
        public static string ver = "1.0.0.6";

        //Tiamat Prop
        public static bool HASeT;
        public static bool CANeT;

        //Youmuus Prop
        public static bool HASiY;
        public static bool CANiY;

        //Randuins
        public static bool HASiR;
        public static bool CANiR;

        //Let The Game Begin!! :^)
        static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
            
        }

        //Menu Config, Items, Spells, ChatPrint
        static void Game_OnGameLoad(EventArgs args)
        {

        Player = ObjectManager.Player;
        if (Player.ChampionName != championName) return;

        Drawing.OnDraw += Drawing_OnDraw;
        Game.OnGameUpdate += Game_OnGameUpdate;
        
        //Spells
        Q = new Spell(SpellSlot.Q);
        W = new Spell(SpellSlot.W);
        E = new Spell(SpellSlot.E, 165);
        R = new Spell(SpellSlot.R, 400);
        
        // Tiamat
        HASeT = Items.HasItem(3077);
        CANeT = Items.CanUseItem(3077);

        //Youmuus GhostBlade
        HASiY = Items.HasItem(3142);
        CANiY = Items.CanUseItem(3142);

        //Randuins
        HASiR = Items.HasItem(3143);
        CANiR = Items.CanUseItem(3143);
        
        //Assemblie Menu
        menu = new Menu("Stronk" + ObjectManager.Player.ChampionName, ObjectManager.Player.ChampionName, true);
        
        menu.AddSubMenu(new Menu("Orbwalker", "Orbwalker"));
        
        Orbwalker = new Orbwalking.Orbwalker(menu.SubMenu("Orbwalker"));
        
        var ts = new Menu("Target Selector", "Target Selector");
        
        TargetSelector.AddToMenu(ts);
        menu.AddSubMenu(ts);

        menu.AddSubMenu(new Menu("Combo", "Combo"));
        menu.SubMenu("Combo").AddItem(new MenuItem("useQ", "Use Q").SetValue(true));
        menu.SubMenu("Combo").AddItem(new MenuItem("useW", "Use W").SetValue(true));
        menu.SubMenu("Combo").AddItem(new MenuItem("useE", "Use E").SetValue(true));
        menu.SubMenu("Combo").AddItem(new MenuItem("useR", "Use R").SetValue(true));
        menu.SubMenu("Combo").AddItem(new MenuItem("ComboActive", "Combo").SetValue(new KeyBind(32, KeyBindType.Press)));

        menu.AddSubMenu(new Menu("Harass", "Harass"));
        menu.SubMenu("Harass").AddItem(new MenuItem("useQ", "Use Q").SetValue(true));
        menu.SubMenu("Harass").AddItem(new MenuItem("useE", "Use E").SetValue(true));
        menu.SubMenu("Harass").AddItem(new MenuItem("HarassActive", "Harass").SetValue(new KeyBind(67, KeyBindType.Press)));
        menu.SubMenu("Harass").AddItem(new MenuItem("AHActive", "autoHarass").SetValue(true));

        menu.AddSubMenu(new Menu("LaneClear", "LaneClear"));
        menu.SubMenu("LaneClear").AddItem(new MenuItem("useQ", "Use Q").SetValue(true));
        menu.SubMenu("LaneClear").AddItem(new MenuItem("useE", "Use E").SetValue(true));
        menu.SubMenu("LaneClear").AddItem(new MenuItem("Tiamat", "Tiamat").SetValue(true));
        menu.SubMenu("LaneClear").AddItem(new MenuItem("LC", "LaneClear").SetValue(new KeyBind(86, KeyBindType.Press)));

        menu.AddSubMenu(new Menu("LastHit", "LastHit"));
        menu.SubMenu("LastHit").AddItem(new MenuItem("useQ", "Use Q").SetValue(true));
        menu.SubMenu("LastHit").AddItem(new MenuItem("LH", "LastHit").SetValue(new KeyBind(88, KeyBindType.Press)));
        
        menu.AddToMainMenu();
        
        //ChatPrint onLoad
        Game.PrintChat("<font color='#77e20d'>Stronk" + championName + " # " + ver + "</font> DEMOGLIAAAAAA");
        }

        //On Game Call Actions
        static void Game_OnGameUpdate(EventArgs args)
        {
            
            if (menu.Item("ComboActive").IsActive())
            {
                Combo();
            }

            if (menu.Item("HarassActive").IsActive()){
                Harass();
            }

            if (menu.Item("AHActive").IsActive())
            {
                autoHarass();
            }

            if (menu.Item("LC").IsActive())
            {
                LaneClear();
            }


            if (menu.Item("LH").IsActive())
            {
                LastHit();
            }


        }

        static void Drawing_OnDraw(EventArgs args)
        {
        }

        //The Magic Part!!!
        public static void Combo()
        {
            var Target = TargetSelector.GetTarget(400, TargetSelector.DamageType.Physical);
            if (Target == null) return;
            
            if (Target.IsValidTarget() && Q.IsReady() && menu.SubMenu("Combo").Item("useQ").GetValue<bool>() == true)
            { 
            Q.Cast();
            }
            if (Target.IsValidTarget(E.Range) && E.IsReady() && menu.SubMenu("Combo").Item("useE").GetValue<bool>() == true)
            { 
            E.Cast();
            }
            if (R.IsReady() && Target.IsValidTarget() && R.GetDamage(Target) > Target.Health + Target.HPRegenRate && menu.SubMenu("Combo").Item("useR").GetValue<bool>() == true)
            {
            R.Cast(Target);
            }

        }

        public static void Harass()
        {
            if (Orbwalker.ActiveMode != Orbwalking.OrbwalkingMode.Mixed) return;

            var Target = TargetSelector.GetTarget(165, TargetSelector.DamageType.Physical);
            if (Target == null) return;

            if (Target.IsValidTarget() && Q.IsReady() && menu.SubMenu("Harass").Item("useQ").GetValue<bool>() == true)
            {
                Q.Cast(Target);
            }

            if (Target.IsValidTarget() && E.IsReady() && menu.SubMenu("Harass").Item("useE").GetValue<bool>() == true)
            {
                E.Cast();
            }

        }

        public static void autoHarass()
        {
            var Target = TargetSelector.GetTarget(165, TargetSelector.DamageType.Physical);
            if (Target == null) return;

            if (Target.IsValidTarget() && Q.IsReady() && menu.SubMenu("Harass").Item("useQ").GetValue<bool>() == true) 
            {
                Q.Cast(Target);
            }

            if (Target.IsValidTarget(E.Range) && E.IsReady() && Player.Health > Target.Health && menu.SubMenu("Harass").Item("useE").GetValue<bool>() == true)
            {
                E.Cast();
            }

        }

        public static void LaneClear()
        {

            Obj_AI_Base minion = MinionManager.GetMinions(165).FirstOrDefault();
            if (minion == null) return;

            if (minion.IsValidTarget() && Q.IsReady() && menu.SubMenu("LaneClear").Item("useQ").GetValue<bool>() == true)
            {
                Q.Cast(minion.Health < Q.GetDamage(minion));
            }

            if (minion.IsValidTarget() && E.IsReady() && menu.SubMenu("LaneClear").Item("useE").GetValue<bool>() == true)
            {
                E.Cast();
            }

        }

        public static void LastHit()
        {
            Obj_AI_Base minion = MinionManager.GetMinions(165).FirstOrDefault();
            if (minion == null) return; 

            if (minion.IsValidTarget() && Q.GetDamage(minion) > minion.Health && Q.IsReady() && menu.SubMenu("LastHit").Item("useQ").GetValue<bool>() == true)
            {
                Q.Cast(minion.Health < Q.GetDamage(minion));
            }

        }



    }
}

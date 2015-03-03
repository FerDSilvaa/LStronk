using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;

namespace StronkVladi_The_Blood_Sucker
{
    class Program
    {
        private static Obj_AI_Hero Player;
        public static Menu menu;
        public static String championName = "Vladimir";
        public static Orbwalking.Orbwalker Orbwalker;
        public static string ver = "1.0.0.0";
        public static Spell Q, W, E, R;
        public static CHLL check;
 


        public static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;


        }

        public static void Game_OnGameLoad(EventArgs args)
        {
            check = new CHLL();
            Player = ObjectManager.Player;
            //if (Player.ChampionName != championName) {Game.PrintChat("This Stronk Assemblie does NOT Support Dat Champ Mannn"); return;}
            if (Player.ChampionName != championName) return;

            var checkPlayer = ObjectManager.Player.ChampionName.ToLowerInvariant();
            switch(checkPlayer)
            {
                case "vladimir":
                    check = new CHLL();
                    break;
            }



            Drawing.OnDraw += Drawing_OnDraw;
            Game.OnGameUpdate += check.Game_OnGameUpdate;

            Q = new Spell(SpellSlot.Q, 450);
            W = new Spell(SpellSlot.W, 450);
            E = new Spell(SpellSlot.E);
            R = new Spell(SpellSlot.R, 450);

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

            menu.AddSubMenu(new Menu("LaneClear", "LaneClear"));
            menu.SubMenu("LaneClear").AddItem(new MenuItem("useQ", "Use Q").SetValue(true));
            menu.SubMenu("LaneClear").AddItem(new MenuItem("useE", "Use E").SetValue(true));
            menu.SubMenu("LaneClear").AddItem(new MenuItem("LC", "LaneClear").SetValue(new KeyBind(86, KeyBindType.Press)));

            menu.AddSubMenu(new Menu("LastHit", "LastHit"));
            menu.SubMenu("LastHit").AddItem(new MenuItem("useQ", "Use Q").SetValue(true));
            menu.SubMenu("LastHit").AddItem(new MenuItem("LH", "LastHit").SetValue(new KeyBind(88, KeyBindType.Press)));

            menu.AddToMainMenu();

            Game.PrintChat("<font color='#77e20d'>Stronk" + championName + " TheBloodSucker" + "</font> # " + ver);
        }

        public virtual void Game_OnGameUpdate(EventArgs args)
        {
        }

        static void Drawing_OnDraw(EventArgs args)
        {
        }
    }
}

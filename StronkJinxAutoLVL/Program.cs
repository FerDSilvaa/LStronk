using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;

namespace ConsoleApplication2
{
    class Program
    {
        //Geral Settings
        private static String championName = "Jinx";
        private static Obj_AI_Hero Player;
        public static Menu menu;
        public static string ver = "1.0.0.0";
        

        static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        static void Game_OnGameLoad(EventArgs args)
        {

            Player = ObjectManager.Player;
            if (Player.ChampionName != championName) return;

            Drawing.OnDraw += Drawing_OnDraw;
            Game.OnGameUpdate += Game_OnGameUpdate;

            menu = new Menu("StronkAutoLvl" + ObjectManager.Player.ChampionName, ObjectManager.Player.ChampionName, true);

            menu.AddSubMenu(new Menu("AutoLeveler", "AutoLeveler"));
            menu.SubMenu("AutoLevel").AddItem(new MenuItem("AutLvlActive", "AutoLevel").SetValue(true));
            menu.AddToMainMenu();

            Game.PrintChat("<font color='#77e20d'>Stronk" + championName + "AutoLevel" + "</font> # " + ver);
        }

                static void Game_OnGameUpdate(EventArgs args)
        {
            if (menu.Item("AutLvlActive").IsActive())
                AutLevel();
        }

        static void Drawing_OnDraw(EventArgs args)
        {
        }

        public static void AutLevel()
        {
            var AutLevel = new AutoLevel(new[] { 1, 2, 3, 1, 2, 4, 3, 1, 2, 3, 4, 2, 1, 2, 3, 1, 3, 4 });
        }
    }
}

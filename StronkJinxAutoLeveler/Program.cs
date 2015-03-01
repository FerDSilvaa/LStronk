using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;

namespace StronkJinxAutoLeveler
{
    class Program
    {
        //Geral Settings
        private static String championName = "Jinx";
        private static Obj_AI_Hero Player;
        public static Menu menu;

        //Calling Cookies From CookieCutter
        public static Slider slider;
        public static Slider slider2;
        public static Slider slider3;
        public static Slider slider4;
        public static Slider slider5;
        public static Slider slider6;
        public static Slider slider7;
        public static Slider slider8;
        public static Slider slider9;
        public static Slider slider10;
        public static Slider slider11;
        public static Slider slider12;
        public static Slider slider13;
        public static Slider slider14;
        public static Slider slider15;
        public static Slider slider16;
        public static Slider slider17;
        public static Slider slider18;

        public static string ver = "1.0.1.0";

        //Calling Cookies Values
        public static int sliderValue;
        public static int sliderValue2;
        public static int sliderValue3;
        public static int sliderValue4;
        public static int sliderValue5;
        public static int sliderValue6;
        public static int sliderValue7;
        public static int sliderValue8;
        public static int sliderValue9;
        public static int sliderValue10;
        public static int sliderValue11;
        public static int sliderValue12;
        public static int sliderValue13;
        public static int sliderValue14;
        public static int sliderValue15;
        public static int sliderValue16;
        public static int sliderValue17;
        public static int sliderValue18;


        static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += Game_OnGameLoad;
        }

        public static void Game_OnGameLoad(EventArgs args)
        {

            Player = ObjectManager.Player;
            if (Player.ChampionName != championName) return;

            Drawing.OnDraw += Drawing_OnDraw;
            Game.OnGameUpdate += Game_OnGameUpdate;

            //Cookies From CookieCutter
            slider = new Slider(1, 1, 4);
            slider2 = new Slider(2, 1, 4);
            slider3 = new Slider(3, 1, 4);
            slider4 = new Slider(1, 1, 4);
            slider5 = new Slider(2, 1, 4);
            slider6 = new Slider(4, 1, 4);
            slider7 = new Slider(3, 1, 4);
            slider8 = new Slider(1, 1, 4);
            slider9 = new Slider(2, 1, 4);
            slider10 = new Slider(1, 1, 4);
            slider11 = new Slider(4, 1, 4);
            slider12 = new Slider(2, 1, 4);
            slider13 = new Slider(1, 1, 4);
            slider14 = new Slider(2, 1, 4);
            slider15 = new Slider(3, 1, 4);
            slider16 = new Slider(4, 1, 4);
            slider17 = new Slider(3, 1, 4);
            slider18 = new Slider(3, 1, 4);

            menu = new Menu("StronkAutoLvl" + ObjectManager.Player.ChampionName, ObjectManager.Player.ChampionName, true);

            menu.SubMenu("AutoLevel").AddItem(new MenuItem("AutLvlActive", "AutoLevel").SetValue(true));
            menu.SubMenu("AutoLevel").AddItem(new MenuItem("LVL", "Levels"));
            menu.SubMenu("AutoLevel").AddItem(new MenuItem("a1", "1").SetValue(slider));
            menu.SubMenu("AutoLevel").AddItem(new MenuItem("a2", "2").SetValue(slider2));
            menu.SubMenu("AutoLevel").AddItem(new MenuItem("a3", "3").SetValue(slider3));
            menu.SubMenu("AutoLevel").AddItem(new MenuItem("a4", "4").SetValue(slider4));
            menu.SubMenu("AutoLevel").AddItem(new MenuItem("a5", "5").SetValue(slider5));
            menu.SubMenu("AutoLevel").AddItem(new MenuItem("a6", "6").SetValue(slider6));
            menu.SubMenu("AutoLevel").AddItem(new MenuItem("a7", "7").SetValue(slider7));
            menu.SubMenu("AutoLevel").AddItem(new MenuItem("a8", "8").SetValue(slider8));
            menu.SubMenu("AutoLevel").AddItem(new MenuItem("a9", "9").SetValue(slider9));
            menu.SubMenu("AutoLevel").AddItem(new MenuItem("a10", "10").SetValue(slider10));
            menu.SubMenu("AutoLevel").AddItem(new MenuItem("a11", "11").SetValue(slider11));
            menu.SubMenu("AutoLevel").AddItem(new MenuItem("a12", "12").SetValue(slider12));
            menu.SubMenu("AutoLevel").AddItem(new MenuItem("a13", "13").SetValue(slider13));
            menu.SubMenu("AutoLevel").AddItem(new MenuItem("a14", "14").SetValue(slider14));
            menu.SubMenu("AutoLevel").AddItem(new MenuItem("a15", "15").SetValue(slider15));
            menu.SubMenu("AutoLevel").AddItem(new MenuItem("a16", "16").SetValue(slider16));
            menu.SubMenu("AutoLevel").AddItem(new MenuItem("a17", "17").SetValue(slider17));
            menu.SubMenu("AutoLevel").AddItem(new MenuItem("a18", "18").SetValue(slider18));

            menu.AddToMainMenu();

            Game.PrintChat("<font color='#77e20d'>Stronk" + championName + "AutoLevel" + "</font> # " + ver);
        }

        static void Game_OnGameUpdate(EventArgs args)
        {
            if (menu.Item("AutLvlActive").IsActive())
                AutLevel();
            else
            {
                return;
            }

        }

        static void Drawing_OnDraw(EventArgs args)
        {
        }

        public static void AutLevel()
        {
            //Cookies Values
            sliderValue = slider.Value;
            sliderValue2 = slider2.Value;
            sliderValue3 = slider3.Value;
            sliderValue4 = slider4.Value;
            sliderValue5 = slider5.Value;
            sliderValue6 = slider6.Value;
            sliderValue7 = slider7.Value;
            sliderValue8 = slider8.Value;
            sliderValue9 = slider9.Value;
            sliderValue10 = slider10.Value;
            sliderValue11 = slider11.Value;
            sliderValue12 = slider12.Value;
            sliderValue13 = slider13.Value;
            sliderValue14 = slider14.Value;
            sliderValue15 = slider15.Value;
            sliderValue16 = slider16.Value;
            sliderValue17 = slider17.Value;
            sliderValue18 = slider18.Value;

            var AutLevel = new AutoLevel(new[] 
            { 
                sliderValue, 
                sliderValue2, 
                sliderValue3, 
                sliderValue4, 
                sliderValue5, 
                sliderValue6, 
                sliderValue7, 
                sliderValue8, 
                sliderValue9, 
                sliderValue10, 
                sliderValue11, 
                sliderValue12, 
                sliderValue13, 
                sliderValue14, 
                sliderValue15, 
                sliderValue16, 
                sliderValue17, 
                sliderValue18

            });

        }
    }
}

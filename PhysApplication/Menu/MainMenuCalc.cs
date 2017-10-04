﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhysApplication.Menu {
    public class MainMenuCalc {
        public static MenuList menuItems = new MenuList(new string[] { "new item" }); // passes null for the parameter when instantiating class as an object
        public static List<menuObject> menuCategories = menuItems.categories;
        public void CreateMenu() {  // TODO Think about splitting to new file
            Console.Clear();
            Console.Write("Please Select One Object:\n\n");
            foreach (menuObject a in menuCategories) {
                Console.WriteLine(a.Marked?$"{a.Name} <":a.Name);
            }
        }
        private void KeyAnalyze(string key) {
            if (key == null) return;
            if (key.ToUpper() == "UPARROW") Move(true);
            if (key.ToUpper() == "DOWNARROW") Move(false);
            if (key.ToUpper() == "ENTER") EnterPress();
        }
        private void Move(bool upMove) {
            int j = 1;
            for(int i = 0; i < menuCategories.Count(); i++) {
                if (menuItems.categories[i].Marked) {
                    j = i;
                    menuCategories[i] = new menuObject(menuCategories[i].Name, false);
                }
            }
            if (j == 0 && upMove) menuCategories[menuCategories.Count() - 1] = new menuObject(menuCategories[menuCategories.Count() - 1].Name, true);
            else if (j == menuCategories.Count - 1 && !upMove) menuCategories[0] = new menuObject(menuCategories[0].Name, true);
            else if (upMove) menuCategories[j - 1] = new menuObject(menuCategories[j - 1].Name, true);
            else if (!upMove) menuCategories[j + 1] = new menuObject(menuCategories[j + 1].Name, true);
        }
        private void DownMove() {

        }
        private void EnterPress() {

        }
        public void MenuNav() {
            string key = null;
            do {
                KeyAnalyze(key = Console.ReadKey().Key.ToString());
                CreateMenu();
            } while (key.ToUpper() != "ESCAPE");
        }
    }
}

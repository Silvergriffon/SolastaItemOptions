using System;
using System.Collections.Generic;
using UnityModManagerNet;
using ModKit;
using SolastaItemOptions.Models;

namespace SolastaItemOptions.Menus.Viewers
{
    public class ReskinsMenu : IMenuSelectablePage
    {
        public string Name => "Re-Skin Options";

        public int Priority => 0;

        public void OnGUI(UnityModManager.ModEntry modEntry)
        {
            bool toggle;

            var skins = new List<string> { "Normal", "Plain Shirt", "Elven Chain", "Sylvan Armor", "Studded Leather", "Druid Leather", "Barbarian Clothes", "Wizard Clothes", "Sorcerer's Armor" };
            var skinChoice = Math.Max(skins.FindIndex(x => x == Main.Settings.EmpressGarbSkin), 0);

            UI.Label("");
            UI.Label("Empress Garb Appearance Settings".yellow().bold());

            UI.HStack("", 10, () => {
                if (UI.SelectionGrid(ref skinChoice, skins.ToArray(), skins.Count, UI.AutoWidth()))
                {
                    Main.Settings.EmpressGarbSkin = skins[skinChoice];
                }
            });
            UI.Label("");

            UI.Label("");
            UI.Label("Other Apperance Settings".yellow().bold());

            UI.Label("");
            toggle = Main.Settings.InvisibleCrown;
            if (UI.Toggle("Invisible Crown of the Magister", ref toggle, 0, UI.AutoWidth()))
            {
                Main.Settings.InvisibleCrown = toggle;
            }
            UI.Label("");
        }
    }
}


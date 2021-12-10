using System;
using System.Collections.Generic;
using UnityModManagerNet;
using ModKit;
using SolastaItemOptions.Models;

namespace SolastaItemOptions.Menus.Viewers
{
    public class OtherOptionsMenu : IMenuSelectablePage
    {
        public string Name => "Other Options";

        public int Priority => 3;

        public void OnGUI(UnityModManager.ModEntry modEntry)
        {
            bool toggle;

            var gloriousBeard = new List<string> { "Standard", "Always", "Never" };
            var beardChance = Math.Max(gloriousBeard.FindIndex(x => x == Main.Settings.DwarvenBeltBeard), 0);

            UI.Label("");
            UI.Label("Belt of Dwarvenkind Beard".yellow().bold());

            UI.HStack("", 10, () => {
                if (UI.SelectionGrid(ref beardChance, gloriousBeard.ToArray(), gloriousBeard.Count, UI.AutoWidth()))
                {
                    Main.Settings.DwarvenBeltBeard = gloriousBeard[beardChance];
                }
            });

            UI.Label("");
            UI.Label("Other Settings:".yellow().bold());
            UI.Label("");

            toggle = Main.Settings.UniversalSylvanArmor;
            if (UI.Toggle("Sylvan Armor wearable by all characters", ref toggle, 0, UI.AutoWidth()))
            {
                Main.Settings.UniversalSylvanArmor = toggle;
            }

            UI.Label("");
            UI.Label("Fixes:".yellow().bold());
            UI.Label("");

            toggle = Main.Settings.FixUniversalFoci;
            if (UI.Toggle("Fix: Make Component Pouch Belt and Bracers Universal (should have been in 1.2.15)", ref toggle, 0, UI.AutoWidth()))
            {
                Main.Settings.FixUniversalFoci = toggle;
            }

            UI.Label("");

        }
    }
}


using UnityModManagerNet;
using ModKit;
using SolastaItemOptions.Models;

namespace SolastaItemOptions.Menus.Viewers
{
    public class AdditionalFociMenu : IMenuSelectablePage
    {
        public string Name => "Additional Foci Menu";

        public int Priority => 1;

        public void OnGUI(UnityModManager.ModEntry modEntry)
        {
            bool toggle;
                        			
		    UI.Label("");
            UI.Label("Foci Settings:".yellow().bold());
            UI.Label("");
           
            toggle = Main.Settings.AdditionalFoci;
            if (UI.Toggle("Create new Arcane(Staff) and Druid(Neck, Staff, Club) Foci available from Hugo ", ref toggle, 0, UI.AutoWidth()))
            {
                Main.Settings.AdditionalFoci = toggle;
            }

            toggle = Main.Settings.DMFoci;
            if (UI.Toggle("Make new Foci available in Dungeon Maker ", ref toggle, 0, UI.AutoWidth()))
            {
                Main.Settings.DMFoci = toggle;
            }

            toggle = Main.Settings.AllMagicStavesFoci;
            if (UI.Toggle("Make all magic staves Arcane Foci (Staff of Healing is Divine instead) ", ref toggle, 0, UI.AutoWidth()))
            {
                Main.Settings.AllMagicStavesFoci = toggle;
            }

            UI.Label("");
        }
    }
}


using UnityModManagerNet;
using ModKit;
using SolastaItemOptions.Models;

namespace SolastaItemOptions.Menus.Viewers
{
    public class MerchantOptionsMenu : IMenuSelectablePage
    {
        public string Name => "Merchant Options";

        public int Priority => 2;

        public void OnGUI(UnityModManager.ModEntry modEntry)
        {
            bool toggle;

            UI.Label("");
            UI.Label("Merchant Settings:".yellow().bold());
            UI.Label("");

            toggle = Main.Settings.ClothingGorimStock;
            if (UI.Toggle("Stock Gorim's store with all non-magical clothing", ref toggle, 0, UI.AutoWidth()))
            {
                Main.Settings.ClothingGorimStock = toggle;
            }

            UI.Label("");
            UI.Label("Options below will enable all of the merchant's stock to restock over time, except Manuals/Tomes. Note that some items take up to 7 game days to restock".yellow());
            UI.Label("");

            toggle = Main.Settings.RestockAntiquarians;
            if (UI.Toggle("Restock Antiquarians (Halman Summer)", ref toggle, 0, UI.AutoWidth()))
            {
                Main.Settings.RestockAntiquarians = toggle;
            }

            toggle = Main.Settings.RestockArcaneum;
            if (UI.Toggle("Restock Arcaneum (Heddlon_Surespell)", ref toggle, 0, UI.AutoWidth()))
            {
                Main.Settings.RestockArcaneum = toggle;
            }

            toggle = Main.Settings.RestockCircleOfDanantar;
            if (UI.Toggle("Restock Circle Of Danantar (Joriel_Foxeye)", ref toggle, 0, UI.AutoWidth()))
            {
                Main.Settings.RestockCircleOfDanantar = toggle;
            }

            toggle = Main.Settings.RestockTowerOfKnowledge;
            if (UI.Toggle("Restock Tower OF Knowledge (Maddy_Greenisle)", ref toggle, 0, UI.AutoWidth()))
            {
                Main.Settings.RestockTowerOfKnowledge = toggle;
            }
        }
    }
}


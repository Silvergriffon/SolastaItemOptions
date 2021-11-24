using SolastaModApi;
using SolastaModApi.Extensions;

namespace SolastaItemOptions.Models
{
    internal static class ItemReskinContext
    {
        internal static void Load()
        {
            ItemDefinition reskin_empress_garb = DatabaseHelper.ItemDefinitions.Enchanted_ChainShirt_Empress_war_garb;

            if (Main.Settings.EmpressGarbSkin == "Plain Shirt")
            {
                reskin_empress_garb.ItemPresentation.SetUseCustomArmorMaterial(false);
            }

            if (Main.Settings.EmpressGarbSkin == "Elven Chain")
            {
                reskin_empress_garb.SetItemPresentation(DatabaseHelper.ItemDefinitions.ElvenChain.ItemPresentation);
            }

            if (Main.Settings.EmpressGarbSkin == "Sylvan Armor")
            {
                reskin_empress_garb.SetItemPresentation(DatabaseHelper.ItemDefinitions.GreenmageArmor.ItemPresentation);
            }

            if (Main.Settings.EmpressGarbSkin == "Studded Leather")
            {
                reskin_empress_garb.SetItemPresentation(DatabaseHelper.ItemDefinitions.StuddedLeather.ItemPresentation);
            }

            if (Main.Settings.EmpressGarbSkin == "Druid Leather")
            {
                reskin_empress_garb.SetItemPresentation(DatabaseHelper.ItemDefinitions.LeatherDruid.ItemPresentation);
            }

            if (Main.Settings.EmpressGarbSkin == "Barbarian Clothes")
            {
                reskin_empress_garb.SetItemPresentation(DatabaseHelper.ItemDefinitions.BarbarianClothes.ItemPresentation);
            }

            if (Main.Settings.EmpressGarbSkin == "Wizard Clothes")
            {
                reskin_empress_garb.SetItemPresentation(DatabaseHelper.ItemDefinitions.WizardClothes_Alternate.ItemPresentation);
            }

            if (Main.Settings.EmpressGarbSkin == "Sorcerer's Armor")
            {
                reskin_empress_garb.SetItemPresentation(DatabaseHelper.ItemDefinitions.SorcererArmor.ItemPresentation);
            }
        }
    }

}
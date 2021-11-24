using SolastaModApi;
using SolastaModApi.Extensions;
using SolastaItemOptions.Features;

namespace SolastaItemOptions.Models
{
    internal static class AdditionalFociContext
    {
        internal static void Load()
        {
			if (Main.Settings.AdditionalFoci)
            {
				ItemDefinition DruidicAmulet = ItemBuilder.FocusDefinitionBuilder.CreateCopyFrom(DatabaseHelper.ItemDefinitions.ComponentPouch_ArcaneAmulet,
					"DruidicAmulet", "3487d3b2-1058-4c0f-8009-9e4f525cb0e0", "Equipment/&DruidicAmuletTitle", "Equipment/&DruidicAmuletDescription", EquipmentDefinitions.FocusType.Druidic);
				DruidicAmulet.GuiPresentation.SetSpriteReference(DatabaseHelper.ItemDefinitions.BeltOfGiantHillStrength.GuiPresentation.SpriteReference);
				
				ItemDefinition LivewoodStaff = ItemBuilder.FocusDefinitionBuilder.CreateCopyFrom(DatabaseHelper.ItemDefinitions.Quarterstaff,
					"LivewoodStaff", "ff3ec29c-734f-4ef6-8d6e-ceb961d9a8a0", "Equipment/&LivewoodStaffTitle", "Equipment/&LivewoodStaffDescription", EquipmentDefinitions.FocusType.Druidic);
				LivewoodStaff.SetCosts(DatabaseHelper.ItemDefinitions.ComponentPouch.Costs);
				LivewoodStaff.GuiPresentation.SetSpriteReference(DatabaseHelper.ItemDefinitions.StaffOfHealing.GuiPresentation.SpriteReference);

				ItemDefinition LivewoodClub = ItemBuilder.FocusDefinitionBuilder.CreateCopyFrom(DatabaseHelper.ItemDefinitions.Club,
					"LivewoodClub", "dd27119b-01e0-4a47-a043-98b89dc930a1", "Equipment/&LivewoodClubTitle", "Equipment/&LivewoodClubDescription", EquipmentDefinitions.FocusType.Druidic);
				LivewoodClub.SetCosts(DatabaseHelper.ItemDefinitions.ComponentPouch.Costs);

				ItemDefinition ArcaneStaff = ItemBuilder.FocusDefinitionBuilder.CreateCopyFrom(DatabaseHelper.ItemDefinitions.Quarterstaff,
					"ArcaneStaff", "991e1fec-9777-4635-948f-5bedcb96147d", "Equipment/&ArcaneStaffTitle", "Equipment/&ArcaneStaffDescription", EquipmentDefinitions.FocusType.Arcane);
				ArcaneStaff.SetCosts(DatabaseHelper.ItemDefinitions.ComponentPouch.Costs);
				ArcaneStaff.GuiPresentation.SetSpriteReference(DatabaseHelper.ItemDefinitions.QuarterstaffPlus1.GuiPresentation.SpriteReference);
			}

		}
    }
}
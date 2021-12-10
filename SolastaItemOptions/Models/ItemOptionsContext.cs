using SolastaModApi;
using SolastaModApi.Extensions;
using System.Linq;
using static SolastaModApi.DatabaseHelper.ItemDefinitions;
using SolastaItemOptions.Features;

namespace SolastaItemOptions.Models
{
    internal static class ItemOptionsContext
    {
        internal static void Load()
        {
			var dbItemDefinition = DatabaseRepository.GetDatabase<ItemDefinition>();

			GraphicsCharacterDefinitions.BodyPartBehaviour[] invisible_crown = new GraphicsCharacterDefinitions.BodyPartBehaviour[]
			{
				GraphicsCharacterDefinitions.BodyPartBehaviour.Shape, GraphicsCharacterDefinitions.BodyPartBehaviour.Shape,
				GraphicsCharacterDefinitions.BodyPartBehaviour.Keep, GraphicsCharacterDefinitions.BodyPartBehaviour.Keep,
				GraphicsCharacterDefinitions.BodyPartBehaviour.Keep, GraphicsCharacterDefinitions.BodyPartBehaviour.Keep,
				GraphicsCharacterDefinitions.BodyPartBehaviour.Keep, GraphicsCharacterDefinitions.BodyPartBehaviour.Keep,
				GraphicsCharacterDefinitions.BodyPartBehaviour.Keep, GraphicsCharacterDefinitions.BodyPartBehaviour.Keep
			};

			if (Main.Settings.InvisibleCrown)
			{
				foreach (var item in dbItemDefinition.Where(
					x => x.Name.Contains("CrownOfTheMagister")))
				{
					item.ItemPresentation.SetMaleBodyPartBehaviours(invisible_crown);
				}
			}

			if (Main.Settings.AllMagicStavesFoci)
			{
				foreach (var item in dbItemDefinition.Where(
					x => x.WeaponDescription.WeaponType == EquipmentDefinitions.WeaponTypeQuarterstaff && x.Magical && x != StaffOfHealing))
				{
					item.SetIsFocusItem(true);
					item.FocusItemDescription.SetFocusType(EquipmentDefinitions.FocusType.Arcane);
				}
			}

			if (Main.Settings.ClothingGorimStock)
			{
				foreach (var item in dbItemDefinition.Where(
					x => x.ArmorDescription.ArmorType == "ClothesType" && !x.Magical && !x.SlotsWhereActive.Contains("TabardSlot") && x != ClothesCommon_Tattoo && x != ClothesWizard_B))
				{
					ItemBuilder.StockClothing(DatabaseHelper.MerchantDefinitions.Store_Merchant_Gorim_Ironsoot_Cyflen_GeneralStore, item);
				}
			}

			if (Main.Settings.UniversalSylvanArmor)
			{
				foreach (var item in dbItemDefinition.Where(
					x => x == GreenmageArmor))
				{
					item.RequiredAttunementClasses.Clear();
				}
			}

			if (Main.Settings.FixUniversalFoci)
			{
				foreach (var item in dbItemDefinition.Where(
					x => x == ComponentPouch_Belt || x == ComponentPouch_Bracers))
				{
					item.FocusItemDescription.SetFocusType(EquipmentDefinitions.FocusType.Universal);
				}
			}
		}
    }
}
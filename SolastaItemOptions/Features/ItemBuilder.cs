using SolastaModApi;
using SolastaModApi.Extensions;

namespace SolastaItemOptions.Features
{
	class ItemBuilder
    {
		public class FocusDefinitionBuilder : BaseDefinitionBuilder<ItemDefinition>
        {
			public FocusDefinitionBuilder(ItemDefinition original, string name, string guid, string title_string, string description_string, EquipmentDefinitions.FocusType type) : base(original, name, guid)
            {
				Definition.GuiPresentation.Title = title_string;
				Definition.GuiPresentation.Description = description_string;
				Definition.SetIsFocusItem(true);
                Definition.FocusItemDescription.SetFocusType(type);
                StockFocus(DatabaseHelper.MerchantDefinitions.Store_Merchant_Hugo_Requer_Cyflen_Potions, Definition);
                if (Main.Settings.DMFoci)
                {
                    Definition.SetInDungeonEditor(true);
                }
            }

			public static ItemDefinition CreateCopyFrom(ItemDefinition original, string name, string guid, string new_title_string, string new_description_string, EquipmentDefinitions.FocusType type)
            {
				return new FocusDefinitionBuilder(original, name, guid, new_title_string, new_description_string, type).AddToDB();
            }
		}
        public static void StockFocus(MerchantDefinition merchant, ItemDefinition item)
        {
            StockUnitDescription stock_Focus = new StockUnitDescription();
            stock_Focus.SetItemDefinition(item);
            stock_Focus.SetInitialAmount(1);
            stock_Focus.SetInitialized(true);
            stock_Focus.SetFactionStatus("Indifference");
            stock_Focus.SetMaxAmount(2);
            stock_Focus.SetMinAmount(1);
            stock_Focus.SetStackCount(1);
            stock_Focus.SetReassortAmount(1);
            stock_Focus.SetReassortRateValue(1);
            stock_Focus.SetReassortRateType(RuleDefinitions.DurationType.Day);
            merchant.StockUnitDescriptions.Add(stock_Focus);
        }
        public static void StockClothing(MerchantDefinition merchant, ItemDefinition item)
        {
            StockUnitDescription stock_Clothing = new StockUnitDescription();
            stock_Clothing.SetItemDefinition(item);
            stock_Clothing.SetInitialAmount(2);
            stock_Clothing.SetInitialized(true);
            stock_Clothing.SetFactionStatus("Indifference");
            stock_Clothing.SetMaxAmount(4);
            stock_Clothing.SetMinAmount(2);
            stock_Clothing.SetStackCount(1);
            stock_Clothing.SetReassortAmount(1);
            stock_Clothing.SetReassortRateValue(1);
            stock_Clothing.SetReassortRateType(RuleDefinitions.DurationType.Day);
            merchant.StockUnitDescriptions.Add(stock_Clothing);
        }
    }


}		

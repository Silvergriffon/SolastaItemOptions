using SolastaModApi;
using SolastaModApi.Extensions;
using SolastaItemOptions.Features;

namespace SolastaItemOptions.Models
{
    internal static class MerchantRestockOptionsContext
    {
        internal static void Load()
        {
            if (Main.Settings.RestockAntiquarians)
            {
                foreach (StockUnitDescription stock in DatabaseHelper.MerchantDefinitions.Store_Merchant_Antiquarians_Halman_Summer.StockUnitDescriptions)
                {
                    if (!stock.ItemDefinition.Name.Contains("Manual"))
                    {
                        if (!stock.ItemDefinition.Name.Contains("Tome"))
                        {
                            stock.SetReassortAmount(1);
                            if (stock.ReassortRateValue.Equals(21))
                            {
                                stock.SetReassortRateValue(7);
                            }
                        }
                    }
                }
            }

            if(Main.Settings.RestockArcaneum)
            {
                foreach (StockUnitDescription stock in DatabaseHelper.MerchantDefinitions.Store_Merchant_Arcaneum_Heddlon_Surespell.StockUnitDescriptions)
                {
                    stock.SetReassortAmount(1);
                }
            }

            if (Main.Settings.RestockCircleOfDanantar)
            {
                foreach (StockUnitDescription stock in DatabaseHelper.MerchantDefinitions.Store_Merchant_CircleOfDanantar_Joriel_Foxeye.StockUnitDescriptions)
                {
                    stock.SetReassortAmount(1);
                }
            }

            if (Main.Settings.RestockTowerOfKnowledge)
            {
                foreach (StockUnitDescription stock in DatabaseHelper.MerchantDefinitions.Store_Merchant_TowerOfKnowledge_Maddy_Greenisle.StockUnitDescriptions)
                {
                    stock.SetReassortAmount(1);
                }
            }

        }
    }
}
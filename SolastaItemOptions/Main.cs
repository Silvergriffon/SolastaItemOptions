using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using UnityModManagerNet;
using ModKit;
using SolastaModApi;
using SolastaModApi.Extensions;
using SolastaItemOptions.Features;
using SolastaItemOptions.Models;


namespace SolastaItemOptions
{
    public class Main
    {
        public static readonly string MOD_FOLDER = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        [Conditional("DEBUG")]
        internal static void Log(string msg) => Logger.Log(msg);
        internal static void Error(Exception ex) => Logger?.Error(ex.ToString());
        internal static void Error(string msg) => Logger?.Error(msg);
        internal static void Warning(string msg) => Logger?.Warning(msg);
        internal static UnityModManager.ModEntry.ModLogger Logger { get; private set; }
        internal static ModManager<Core, Settings> Mod;
        internal static MenuManager Menu;
        internal static Settings Settings { get { return Mod.Settings; } }

        internal static bool Load(UnityModManager.ModEntry modEntry)
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();

                Logger = modEntry.Logger;
                Mod = new ModManager<Core, Settings>();
                Mod.Enable(modEntry, assembly);
                
                Menu = new MenuManager();
                Menu.Enable(modEntry, assembly);
                
                Translations.Load(MOD_FOLDER);
            }
            catch (Exception ex)
            {
                Error(ex);
                throw;
            }

            return true;
        }

        internal static void OnGameReady()
        {
			GraphicsCharacterDefinitions.BodyPartBehaviour[] invisible_crown = new GraphicsCharacterDefinitions.BodyPartBehaviour[]
			{
				GraphicsCharacterDefinitions.BodyPartBehaviour.Shape, GraphicsCharacterDefinitions.BodyPartBehaviour.Shape,
				GraphicsCharacterDefinitions.BodyPartBehaviour.Keep, GraphicsCharacterDefinitions.BodyPartBehaviour.Keep,
				GraphicsCharacterDefinitions.BodyPartBehaviour.Keep, GraphicsCharacterDefinitions.BodyPartBehaviour.Keep,
				GraphicsCharacterDefinitions.BodyPartBehaviour.Keep, GraphicsCharacterDefinitions.BodyPartBehaviour.Keep,
				GraphicsCharacterDefinitions.BodyPartBehaviour.Keep, GraphicsCharacterDefinitions.BodyPartBehaviour.Keep
			};
			
			ItemOptionsContext.Load();
			ItemReskinContext.Load();
			AdditionalFociContext.Load();
			MerchantRestockOptionsContext.Load();

			foreach (ItemDefinition item in DatabaseRepository.GetDatabase<ItemDefinition>())
			{
				if (Main.Settings.InvisibleCrown)
				{
                    if (item.Name.Contains("CrownOfTheMagister"))
                    {
                        item.ItemPresentation.SetMaleBodyPartBehaviours(invisible_crown);
                    }
                }
				
				if (Main.Settings.AllMagicStavesFoci)
				{
					if (item.WeaponDescription.WeaponType == EquipmentDefinitions.WeaponTypeQuarterstaff)
                    {
                        if (item.Magical)
                        {
                            if (!item.Name.Contains("OfHealing"))
							{
								item.SetIsFocusItem(true);
								item.FocusItemDescription.SetFocusType(EquipmentDefinitions.FocusType.Arcane);
							}
							
                            
                        }
                    }	
				}
				
				if (Main.Settings.ClothingGorimStock)
				{
					if (item.ArmorDescription.ArmorType == "ClothesType")
					{
						if (!item.Magical)
						{
							if (!item.Name.Contains("_Tattoo"))
							{
								if (!item.SlotsWhereActive.Contains("TabardSlot"))
								{
									ItemBuilder.StockClothing(DatabaseHelper.MerchantDefinitions.Store_Merchant_Gorim_Ironsoot_Cyflen_GeneralStore, item);
								}
							}
						}
					}
				}
				
				if (Main.Settings.UniversalSylvanArmor)
				{
					if (item.IsArmor)
					{
						if (item.Name.Contains("Greenmage"))
						{
							item.RequiredAttunementClasses.Clear();
						}
					}
				}
            }
		}
    }
}

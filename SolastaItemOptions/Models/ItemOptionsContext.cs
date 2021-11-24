using SolastaModApi;
using SolastaModApi.Extensions;

namespace SolastaItemOptions.Models
{
    internal static class ItemOptionsContext
    {
        internal static void Load()
        {
            FeatureDefinitionCharacterPresentation dwarven_belt_beard = DatabaseHelper.FeatureDefinitionCharacterPresentations.CharacterPresentationBeltOfDwarvenKind;

            if (Main.Settings.DwarvenBeltBeard == "Always")
            {
                dwarven_belt_beard.SetOccurencePercentage(100);
                dwarven_belt_beard.GuiPresentation.SetDescription("Feature/&AlwaysBeardDescription");
            }

            if (Main.Settings.DwarvenBeltBeard == "Never")
            {
                ItemDefinition beardlessBelt = DatabaseHelper.ItemDefinitions.BeltOfDwarvenKind;
                for (int i = 0; i < beardlessBelt.StaticProperties.Count; i++)
                {
                    if (beardlessBelt.StaticProperties[i].FeatureDefinition.GUID == DatabaseHelper.FeatureDefinitionCharacterPresentations.CharacterPresentationBeltOfDwarvenKind.GUID)
                    {
                        beardlessBelt.StaticProperties.RemoveAt(i);
                        break;
                    }
                }
            }
        }
    }
}
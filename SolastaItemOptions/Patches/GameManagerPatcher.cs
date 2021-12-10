using HarmonyLib;
using SolastaItemOptions.Models;

namespace SolastaItemOptions.Patches
{
    internal static class GameManagerPatcher
    {
        [HarmonyPatch(typeof(GameManager), "BindPostDatabase")]
        internal static class GameManager_BindPostDatabase_Patch
        {
            internal static void Postfix()
            {
                ItemOptionsContext.Load();
                ItemReskinContext.Load();
                AdditionalFociContext.Load();
                MerchantRestockOptionsContext.Load(); ;
            }
        }
    }
}

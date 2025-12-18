using HarmonyLib;

namespace MalignantSplashes.Splash.Patches
{
    [HarmonyPatch(typeof(GridUI))]
    public static class Splash_Patch
    {
        [HarmonyPrefix]
        [HarmonyPatch("CreateObject")]
        public static void CreateObjectPrefix(GridUI __instance, SpatialItemInstance entry)
        {
            /// Getting Dark Splash Item
            if (entry.id == "dark-splash")
            {
                /// Setting the item data to a variable for easier use
                SpatialItemData dark_splash = entry.GetItemData<SpatialItemData>();
                if (dark_splash != null)
                {
                    /// Changing item properties
                    dark_splash.canBeDiscardedByPlayer = false;                    
                    dark_splash.canBeSoldByPlayer = true;
                    dark_splash.value = 0;
                    dark_splash.itemSubtype = ItemSubtype.MATERIAL;
                }
            }
        }
    }
}
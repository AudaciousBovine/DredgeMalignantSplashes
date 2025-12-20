using HarmonyLib;

namespace MalignantSplashes.Splash.Patches
{
    /// Harmony Patch that changes properties of an item when it is created in the grid UI
    [HarmonyPatch(typeof(GridUI))]
    public static class Splash_Patch
    {
        [HarmonyPrefix] /// patch to run code before the original CreateObject method
        ///[HarmonyPostfix] /// patch to run code after the original CreateObject method
        [HarmonyPatch("CreateObject")]
        public static void CreateObjectPrefix(GridUI __instance, SpatialItemInstance entry)
        ///public static void CreateObjectPostfix(GridUI __instance, SpatialItemInstance entry)
        {
            /// check if created item is Dark Splash
            if (entry.id == "dark-splash")
            {
                /// Setting the item data to a variable for easier use
                SpatialItemData dark_splash = entry.GetItemData<SpatialItemData>();
                /// Makes sure the item data isnt empty
                if (dark_splash != null)
                {
                    /// Changing item properties
                    dark_splash.canBeDiscardedByPlayer = false; 
                    dark_splash.itemType = ItemType.EQUIPMENT;
                    dark_splash.itemSubtype = ItemSubtype.MATERIAL;
                    dark_splash.canBeSoldByPlayer = true;

                    /// Making Dark Splash Unmovable if the config option is enabled
                    if (Main.Config.GetProperty<string>("malignance") == "NONE")
                    {
                        dark_splash.moveMode = MoveMode.NONE;
                    }
                    /// Making the Dark Splash take an hour to move if the config option is enabled
                    else if (Main.Config.GetProperty<string>("malignance") == "INSTALL")
                    {
                        dark_splash.moveMode = MoveMode.INSTALL;
                    } 
                    /// Making the Dark Splash freely movable if the config option is enabled
                    else if (Main.Config.GetProperty<string>("malignance") == "FREE")
                    {
                        dark_splash.moveMode = MoveMode.FREE;
                    }
                    
                }
            }
        }
    }
}
using UnityEngine;
using Winch.Core;
using HarmonyLib;

namespace MalignantSplashes.Splash.Patches
{
    [HarmonyPatch(typeof(ItemManager), "GetItemValue")]
    public static class ItemManager_Patch
    {
        
        [HarmonyPostfix]
        public static void GetItemValue(ref decimal __result, SpatialItemInstance itemInstance, ItemManager.BuySellMode mode, float sellValueModifier = 1f)
        {
            SpatialItemData itemData = itemInstance.GetItemData<SpatialItemData>();

            if (itemData.id == "dark-splash") 
            { 
                itemData.value = Main.Config.GetProperty<decimal>("splashRemoveCost"); 
                __result *= -1;
            }

        }
    }
}
﻿﻿using System.Linq;
using Winch.Util;
using HarmonyLib;
using System.Reflection;
using Winch.Config;
/// lines above are using statements to include necessary libraries and namespaces that allow use of many methods and classes

/// Name of the mod, each mod requires a unique namespace
/// All .cs files of this mod will use the same namespace
namespace MalignantSplashes
{
    /// The first class/script that is run by Winch to initialize the mod
    /// Setting this class as the "entry point" is done in the mod's manifest.json file
    public class Main
    {
        /// Makes it easy to access config file using Main.Config
        public static ModConfig Config => ModConfig.GetConfig();

        /// This method is run by Winch to initialize your mod
        public static void Initialize()
        {
            /// RUNS HARMONY PATCHES
            /// Any classes with Harmony patches will be applied
            new Harmony("com.AudaciousBovine.MalignantSplashes").PatchAll(Assembly.GetExecutingAssembly());
            /// Allows to run code when the game is loaded
            ApplicationEvents.Instance.OnGameLoaded += OnGameLoaded;
        }
        
            // This method is called when the game has finished loading
        private static void OnGameLoaded()
        {
            /// makes a variable to hold the long line of code that gets the shipwright destination at Greater Marrow
            var shipwrightDestination = DockUtil.GetAllShipyardDestinations().FirstOrDefault(shipyard => shipyard.Id == "destination.gm-shipwright");
            /// allows the little marrow shipwright to buy materials
            shipwrightDestination.itemSubtypesBought |= ItemSubtype.MATERIAL;   
        }
    }
}
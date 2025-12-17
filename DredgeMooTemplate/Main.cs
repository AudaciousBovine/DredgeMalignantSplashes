﻿using HarmonyLib;
using System.Reflection;

namespace DredgeMooTemplate
{
    public class Loader
    {
        /// <summary>
        /// This method is run by Winch to initialize your mod
        /// </summary>
        public static void Initialize()
        {
            /// RUNS HARMONY PATCHES
            new Harmony("com.AudaciousBovine.DredgeMooTemplate").PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
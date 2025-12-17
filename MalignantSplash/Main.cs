﻿using HarmonyLib;
using System.Reflection;

namespace MalignantSplash
{
    public class Loader
    {
        /// <summary>
        /// This method is run by Winch to initialize your mod
        /// </summary>
        public static void Initialize()
        {
            /// RUNS HARMONY PATCHES
            new Harmony("com.AudaciousBovine.MalignantSplash").PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
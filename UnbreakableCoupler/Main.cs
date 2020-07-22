using System;

using HarmonyLib;
using UnityModManagerNet;
using UnityEngine;

namespace UnbreakableCoupler
{
	class Main
	{
		static void Load(UnityModManager.ModEntry modEntry)
		{
			var harmony = new Harmony(modEntry.Info.Id);
			harmony.PatchAll();
		}
	}

	[HarmonyPatch(typeof(CouplingJoint), MethodType.Constructor)]
	class Coupler_Constructor_Patch
	{
		static void Postfix(ref float __BREAK_FORCE, ref float __BREAK_TORQUE)
		{
			Debug.Log("Strengthening coupler...");
			__BREAK_FORCE = Single.MaxValue;
			__BREAK_TORQUE = Single.MaxValue;
			Debug.Log("Coupler strengthened!");
		}
	}
}

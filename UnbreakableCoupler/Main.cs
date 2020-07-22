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

	[HarmonyPatch(typeof(Coupler), MethodType.Constructor)]
	class Coupler_Constructor_Patch
	{
		static void Postfix(Coupler __instance)
		{
			Debug.Log("Strengthening coupler...");
			Coupler_Constructor_Patch.StrengthenCoupler(__instance);
			Debug.Log("Coupler strengthened!");
		}

		static void StrengthenCoupler(Coupler __instance)
		{
			var breakForce = Traverse.Create(__instance).Field("BREAK_FORCE");
			var breakTorque = Traverse.Create(__instance).Field("BREAK_TORQUE");

			breakForce.SetValue(Single.MaxValue);
			breakTorque.SetValue(Single.MaxValue);
		}
	}
}

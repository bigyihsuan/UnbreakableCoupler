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

	[HarmonyPatch(typeof(CouplingJoint), "CreateJoint")]
	class CouplingJoint_CreateJoint_Patch
	{
		static void Postfix(ref ConfigurableJoint ___cj)
		{
			Debug.Log("Strengthening coupler...");

			___cj.breakForce = Single.MaxValue;
			___cj.breakTorque = Single.MaxValue;

			Debug.Log("Coupler strengthened!");
		}
	}
}

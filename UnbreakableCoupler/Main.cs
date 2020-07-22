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

	[HarmonyPatch(typeof(Coupler), "CreateSpringyJoint")]
	class Coupler_CreateSpringyJoint_Patch
	{
		static void Postfix(Coupler __instance)
		{
			Debug.Log("Strengthening springy coupler...");

			__instance.springyCJ.breakForce = Single.PositiveInfinity;
			__instance.springyCJ.breakTorque = Single.PositiveInfinity;

			Debug.Log("Springy coupler strengthened!");
		}
	}

	[HarmonyPatch(typeof(Coupler), "CreateRigidJoint")]
	class Coupler_CreateRigidJoint_Patch
	{
		static void Postfix(Coupler __instance)
		{
			Debug.Log("Strengthening rigid coupler...");

			__instance.rigidCJ.breakForce = Single.PositiveInfinity;
			__instance.rigidCJ.breakTorque = Single.PositiveInfinity;

			Debug.Log("Rigid coupler strengthened!");
		}
	}
}

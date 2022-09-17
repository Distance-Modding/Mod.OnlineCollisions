using HarmonyLib;
using System;

namespace Distance.OnlineCollisions.Harmony
{
    [HarmonyPatch(typeof(PlayerDataNet), "LateUpdate")]
    internal class PlayerDataNet__LateUpdate
    {
        /// <summary>
        /// The goal of this was to display the collider of the car with a LineRenderer. Unfortunately, this line will never show up on top of the location of the car
        /// and instead will show itself at Vector3.zero at all times. The only way to fix this would be to make an object that has a line renderer component and make
        /// that object the child of the car, but I don't know how to make a prefab in the code itself. I only know how to spawn objects through Instanstiate.
        /// If you know of a way, fix this code for me lmao.
        /// </summary>
        /// <param name="__instance"></param>
        [HarmonyPostfix]
        internal static void DrawColliderPostFix(PlayerDataNet __instance)
        {
            if (Mod.Instance.Config.EnableCollision)
            {
                if (__instance.Car_ != null)
                {
                    if (__instance.Car_.GetChild(0).GetComponent<UnityEngine.LineRenderer>() != null)
                    {
                        Mod.Instance.DisplayCollider(__instance.Car_.GetComponent<UnityEngine.MeshCollider>(), __instance.Car_.GetChild(0).GetComponent<UnityEngine.LineRenderer>());
                    }
                    else
                    {
                        Mod.Instance.Logger.Debug("ADDING LINE RENDERER TO OBJECT");
                        __instance.Car_.GetChild(0).AddComponent<UnityEngine.LineRenderer>();
                    }
                }
                else
                {
                    Mod.Instance.Logger.Debug("NETWORK CAR DOES NOT EXIST!");
                }
            }
        }
    }
}
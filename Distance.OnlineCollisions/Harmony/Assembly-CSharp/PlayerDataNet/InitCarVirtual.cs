using HarmonyLib;
using System;

namespace Distance.OnlineCollisions.Harmony
{
    //Enable to collider on network cars
    [HarmonyPatch(typeof(PlayerDataNet), "InitCarVirtual")]
    internal class PlayerDataNet__InitCarVirtual
    {
        [HarmonyPostfix]
        internal static void CollisionPostFix(PlayerDataNet __instance)
        {
            if (Mod.Instance.Config.EnableCollision)
            {
                try
                {
                    __instance.Car_.SetLayerRecursively(Layers.CollidesWithCars);
                }
                catch (Exception e)
                {
                    Mod.Instance.Logger.Debug(e);
                    Mod.Instance.Logger.Debug("Failed to set layers to collides with cars");
                }
            }
        }
    }
}

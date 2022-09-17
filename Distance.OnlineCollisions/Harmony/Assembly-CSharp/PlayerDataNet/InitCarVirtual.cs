using HarmonyLib;

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
                __instance.SetAllColliderLayers(Layers.Default);
                
            }
        }
    }
}

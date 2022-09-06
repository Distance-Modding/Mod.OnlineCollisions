using HarmonyLib;

namespace Distance.OnlineCollisions.Harmony
{
    [HarmonyPatch(typeof(GameMode), "UploadScoreAndReplay")]
    internal class GameMode__UploadScoreAndReplay
    {
        [HarmonyPrefix]
        internal static bool DoISkipMethod()
        {
            //False skips the method, true does not.
            if(Mod.Instance.Config.EnableCollision)
            {
                Mod.Instance.Logger.Debug("Skipping leaderboard upload because online collisions were enabled");
                return false;
            }
            return true;
        }
    }
}

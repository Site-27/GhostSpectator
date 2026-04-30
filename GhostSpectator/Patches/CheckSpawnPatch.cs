using Achievements.Handlers;
using HarmonyLib;
using Respawning;

namespace GhostSpectator.Patches;




    /// <summary>
    /// Allows respawn wave to start when all spectators are ghosts.
    /// </summary>
    [HarmonyPatch(typeof(RespawnHandler), nameof(RespawnHandler.OnInitialize))]
    public class CheckSpawnPatch
    {
        public static bool Prefix(RespawnHandler __instance, ReferenceHub ply, ref bool __result)
        {
            if (API.IsGhost(ply))
            {
                __result = true;
                return false;
            }

            return true;
        }
    }



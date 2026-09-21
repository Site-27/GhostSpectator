using InventorySystem.Items.Scp1509;

namespace GhostSpectator.Patches;

using HarmonyLib;
using PlayerRoles.RoleAssign;

/// <summary>
/// Allows respawn wave to start when all spectators are ghosts.
/// </summary>
[HarmonyPatch(typeof(RoleAssigner), nameof(RoleAssigner.CheckPlayer))]
public static class CheckSpawnPatch
{
    public static bool Prefix(ref bool __result, ReferenceHub hub)
    {
        if (!API.IsGhost(hub))
            return true;
        
        __result = true;
        return false;
    }
}

/// <summary>
/// Allows ghosts to spawn under 1509 !.
/// </summary>
[HarmonyPatch(typeof(Scp1509RespawnEligibility), nameof(Scp1509RespawnEligibility.IsEligible))]
public class CheckSpawn1509Patch
{
    public static bool Prefix(ref bool __result, ReferenceHub player)
    {
        if (!API.IsGhost(player))
            return true;
        
        __result = true;
        return false;
    }
}
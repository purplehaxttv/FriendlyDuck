using HarmonyLib;
using System.Reflection;
using UnityEngine;

[HarmonyPatch(typeof(EnemyDuck), "OnGrabbed")]
public class Patch_EnemyDuck_OnGrabbed
{
    static bool Prefix(object __instance)
    {
        if (__instance == null)
        {
            FriendlyDuckPlugin.Logger.LogWarning("OnGrabbed: __instance is null.");
            return true;
        }

        MethodInfo jumpMethod = __instance.GetType().GetMethod("AnnoyingJump", BindingFlags.NonPublic | BindingFlags.Instance);
        if (jumpMethod == null)
        {
            FriendlyDuckPlugin.Logger.LogError("AnnoyingJump method not found.");
            return true;
        }

        jumpMethod.Invoke(__instance, null);
        FriendlyDuckPlugin.Logger.LogInfo("AnnoyingJump triggered via OnGrabbed.");
        return false; // Skip default attack behavior
    }
}

[HarmonyPatch(typeof(EnemyDuck), "OnSpawn")]
public class Patch_EnemyDuck_OnSpawn
{
    static void Postfix(EnemyDuck __instance)
    {
        if (__instance != null)
        {
            FriendlyDuckPlugin.Logger.LogInfo($">>> Our little guy spawned at position: {__instance.transform.position}");
        }
    }
}

[HarmonyPatch(typeof(EnemyDuck), "Update")]
public class Patch_EnemyDuck_Update
{
    static void Postfix(EnemyDuck __instance)
    {
        // Directly check playerTarget field
        FieldInfo playerTargetField = typeof(EnemyDuck).GetField("playerTarget", BindingFlags.Instance | BindingFlags.NonPublic);
        var playerTarget = playerTargetField?.GetValue(__instance);
        if (playerTarget == null) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            FriendlyDuckPlugin.Logger.LogInfo("E key pressed while duck is grabbed — spawning hearts!");

            GameObject heartFX = Object.Instantiate(
                ModAssets.HeartParticlesPrefab,
                __instance.transform.position + Vector3.up * 1.5f,
                Quaternion.identity
            );

            heartFX.transform.SetParent(__instance.transform);
        }
    }
}

[HarmonyPatch(typeof(EnemyDuck), "StateAttackStart")]
public class Patch_EnemyDuck_StateAttackStart
{
    static bool Prefix()
    {
        FriendlyDuckPlugin.Logger.LogInfo("Blocked StateAttackStart.");
        return false; // Skip attack behavior
    }
}

[HarmonyPatch(typeof(EnemyDuck), "OnHurt")]
public class Patch_EnemyDuck_OnHurt
{
    static bool Prefix()
    {
        FriendlyDuckPlugin.Logger.LogInfo("Blocked OnHurt reaction.");
        return false; // Prevent hurt reaction
    }
}

[HarmonyPatch(typeof(EnemyDuck), "OnObjectHurt")]
public class Patch_EnemyDuck_OnObjectHurt
{
    static bool Prefix()
    {
        FriendlyDuckPlugin.Logger.LogInfo("Blocked OnObjectHurt reaction.");
        return false;
    }
}

[HarmonyPatch(typeof(EnemyDuck), "StateDespawn")]
public class Patch_EnemyDuck_StateDespawn
{
    static bool Prefix()
    {
        FriendlyDuckPlugin.Logger.LogInfo("Blocked StateDespawn.");
        return false; // Prevent despawning
    }
}

[HarmonyPatch(typeof(EnemyDuck), "StateStun")]
public class Patch_EnemyDuck_StateStun
{
    static bool Prefix()
    {
        FriendlyDuckPlugin.Logger.LogInfo("Blocked StateStun.");
        return false; // Prevent stun
    }
}

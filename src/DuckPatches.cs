// DuckPatches.cs
using HarmonyLib;
using System;
using System.Reflection;

[HarmonyPatch(typeof(EnemyDuck), "OnGrabbed")]
public class Patch_EnemyDuck_OnGrabbed
{
    static bool Prefix(object __instance)
    {
        if (__instance == null) return true;

        var stateType = __instance.GetType().GetNestedType("State", BindingFlags.NonPublic);
        var annoyingJump = Enum.Parse(stateType, "AnnoyingJump");

        var method = __instance.GetType().GetMethod("UpdateState", BindingFlags.NonPublic | BindingFlags.Instance);
        method?.Invoke(__instance, new object[] { annoyingJump });

        return false; // Skip original attack behavior
    }
}

[HarmonyPatch(typeof(EnemyDuck), "StateAttackStart")]
public class Patch_EnemyDuck_StateAttackStart
{
    static bool Prefix()
    {
        return false; // Prevent attack from executing
    }
}

[HarmonyPatch(typeof(EnemyDuck), "OnHurt")]
public class Patch_EnemyDuck_OnHurt
{
    static bool Prefix()
    {
        return false; // Prevent reacting to hurt
    }
}

[HarmonyPatch(typeof(EnemyDuck), "OnObjectHurt")]
public class Patch_EnemyDuck_OnObjectHurt
{
    static bool Prefix()
    {
        return false; // Prevent reacting to object collisions
    }
}

[HarmonyPatch(typeof(EnemyDuck), "StateStun")]
public class Patch_EnemyDuck_StateStun
{
    static bool Prefix()
    {
        return false; // Prevent stun state
    }
}

[HarmonyPatch(typeof(EnemyDuck), "StateDespawn")]
public class Patch_EnemyDuck_StateDespawn
{
    static bool Prefix()
    {
        return false; // Prevent despawning
    }
}

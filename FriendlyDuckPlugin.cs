using BepInEx;
using HarmonyLib;

[BepInPlugin("com.purplehaxttv.friendlyduck", "Friendly Duck", "1.0.0")]
public class FriendlyDuckPlugin : BaseUnityPlugin
{
    private void Awake()
    {
        Logger.LogInfo("Friendly Duck plugin loaded.");
        Harmony harmony = new Harmony("com.purplehaxttv.friendlyduck");
        harmony.PatchAll();
    }
}

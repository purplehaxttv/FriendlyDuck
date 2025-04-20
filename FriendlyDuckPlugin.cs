using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using System.IO;
using System.Reflection;

[BepInPlugin("com.purplehaxttv.friendlyduck", "Friendly Duck", "2.1.0")]
public class FriendlyDuckPlugin : BaseUnityPlugin
{
    public static ManualLogSource Logger;

    private void Awake()
    {
        Logger = BepInEx.Logging.Logger.CreateLogSource("Friendly Duck");
        Logger.LogInfo("Friendly Duck plugin loaded.");

        // Dynamically determine the asset bundle path next to the plugin DLL
        string pluginDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string bundlePath = Path.Combine(pluginDir, "friendlyduckassets");

        if (File.Exists(bundlePath))
        {
            AssetBundle bundle = AssetBundle.LoadFromFile(bundlePath);
            ModAssets.LoadAssets(bundle);
            Logger.LogInfo("Asset bundle loaded from: " + bundlePath);
        }
        else
        {
            Logger.LogWarning("Asset bundle NOT found at: " + bundlePath);
        }

        // Apply Harmony patches
        new Harmony("com.purplehaxttv.friendlyduck").PatchAll();
    }
}

using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using System.IO;

[BepInPlugin("com.purplehaxttv.friendlyduck", "Friendly Duck", "2.0.0")]
public class FriendlyDuckPlugin : BaseUnityPlugin
{
    public static ManualLogSource Logger;
    private void Awake()
    {
        Logger = BepInEx.Logging.Logger.CreateLogSource("Friendly Duck");
        Logger.LogInfo("Friendly Duck plugin loaded.");
        
        // === Load heart particle prefab from asset bundle ===
        string bundlePath = Path.Combine(Paths.PluginPath, "FriendlyDuck", "friendlyduckassets");
        ;
        if (File.Exists(bundlePath))
        {
            AssetBundle bundle = AssetBundle.LoadFromFile(bundlePath);
            ModAssets.LoadAssets(bundle);
        }
        else
        {
            Logger.LogWarning("AssetBundle not found: " + bundlePath);
        }

        // === Apply Harmony patches ===
        new Harmony("com.purplehaxttv.friendlyduck").PatchAll();

        // === Inject the right-click handler ===
        GameObject petSpawner = new GameObject("DuckRightClickPet");
        petSpawner.AddComponent<DuckRightClickPet>();
        DontDestroyOnLoad(petSpawner);
    }
}

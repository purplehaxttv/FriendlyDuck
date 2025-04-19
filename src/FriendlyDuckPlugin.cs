using BepInEx;
using UnityEngine;
using System.IO;

[BepInPlugin("com.yourname.friendlyduck", "Friendly Duck", "2.0.0")]
public class FriendlyDuckPlugin : BaseUnityPlugin
{
    private void Awake()
    {
        Logger.LogInfo("Friendly Duck v2.0 loaded.");

        // Load AssetBundle
        string bundlePath = Path.Combine(Paths.PluginPath, "friendlyduckassets");
        if (File.Exists(bundlePath))
        {
            AssetBundle bundle = AssetBundle.LoadFromFile(bundlePath);
            ModAssets.LoadAssets(bundle);
        }
        else
        {
            Logger.LogWarning("friendlyduckassets bundle not found!");
        }

        // Load Harmony patches
        new HarmonyLib.Harmony("com.yourname.friendlyduck").PatchAll();

        // Inject petting controller
        GameObject obj = new GameObject("DuckRightClickPet");
        obj.AddComponent<DuckRightClickPet>();
        GameObject.DontDestroyOnLoad(obj);
    }
}

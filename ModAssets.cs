using UnityEngine;

public static class ModAssets
{
    public static GameObject HeartParticlesPrefab;

    public static void LoadAssets(AssetBundle bundle)
    {
        if (bundle == null)
        {
            Debug.LogError("[FriendlyDuck] AssetBundle was null when passed to LoadAssets.");
            return;
        }

        HeartParticlesPrefab = bundle.LoadAsset<GameObject>("HeartParticles");

        if (HeartParticlesPrefab == null)
        {
            Debug.LogWarning("[FriendlyDuck] HeartParticles prefab not found in asset bundle.");
        }
        else
        {
            Debug.Log("[FriendlyDuck] HeartParticles prefab loaded successfully.");
        }
    }
}

using UnityEngine;

public static class ModAssets
{
    public static GameObject HeartParticlesPrefab;

    public static void LoadAssets(AssetBundle bundle)
    {
        HeartParticlesPrefab = bundle.LoadAsset<GameObject>("HeartParticles");

        if (HeartParticlesPrefab == null)
        {
            Debug.LogWarning("HeartParticles prefab not found in asset bundle.");
        }
        else
        {
            Debug.Log("HeartParticles prefab loaded successfully.");
        }
    }
}

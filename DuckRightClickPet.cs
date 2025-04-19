using UnityEngine;

public class DuckRightClickPet : MonoBehaviour
{
    private float cooldown = 1.0f;
    private float lastPetTime = -999f;

    void Update()
    {
        if (Time.time - lastPetTime < cooldown) return;

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 5f))
            {
                var duck = hit.collider.GetComponentInParent<MonoBehaviour>();
                if (duck != null && duck.GetType().Name == "EnemyDuck")
                {
                    PetTheDuck(duck.transform.position);
                    lastPetTime = Time.time;
                }
            }
        }
    }

    void PetTheDuck(Vector3 position)
    {
        if (ModAssets.HeartParticlesPrefab != null)
        {
            Vector3 spawnPos = position + new Vector3(0, 1.5f, 0);
            GameObject hearts = GameObject.Instantiate(ModAssets.HeartParticlesPrefab, spawnPos, Quaternion.identity);
            hearts.GetComponent<ParticleSystem>()?.Play();
        }
    }
}

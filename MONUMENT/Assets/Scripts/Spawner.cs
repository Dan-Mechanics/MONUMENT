using UnityEngine;

namespace MONUMENT
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject prefab = default;
        [SerializeField] private Transform[] spawnPoints = default;

        [SerializeField] private bool spawnWithRandomRotation = default;
        [SerializeField] private bool flatten = default;
        [SerializeField] [Min(0f)] private float randomPositionMagnitude = default;
        [SerializeField] private bool normalizeRandomPosition = default;
        [SerializeField] private int count = default;

        private void Start()
        {
            if (prefab == null) 
            {
                Debug.LogError("Prefab is not assigned in the inspector.");
                Destroy(gameObject);

                return;
            }

            for (int i = 0; i < count; i++)
            {
                Spawn();
            }
        }

        public void Spawn() 
        {
            Transform spawnPoint = GetRandomSpawnPoint();

            Vector3 pos = spawnPoint.position;
            Quaternion rot = spawnWithRandomRotation ? Random.rotationUniform : spawnPoint.rotation;

            if (randomPositionMagnitude > 0f) 
            {
                Vector3 rand = Random.insideUnitSphere;

                if (flatten) { rand.y = 0f; }
                if (normalizeRandomPosition) { rand.Normalize(); }

                pos += rand * randomPositionMagnitude;
            }

            GameObject spawned = Instantiate(prefab, pos, rot);
            spawned.name = prefab.name;
        }

        private Transform GetRandomSpawnPoint() 
        {
            return spawnPoints[Random.Range(0, spawnPoints.Length)];
        }
    }
}
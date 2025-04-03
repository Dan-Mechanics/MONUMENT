using UnityEngine;

namespace MONUMENT
{
    public class GridMaker : MonoBehaviour
    {
        [SerializeField] private GameObject cubePrefab = default;

        [SerializeField] private float height = default;
        [SerializeField] private float width = default;
        [SerializeField] private float spacing = default;
        [SerializeField] private int sideCount = default;
        [SerializeField] private float heightVariance = default;

        private void Start()
        {
            float totalLength = spacing * (sideCount - 1);

            transform.position = new Vector3(-totalLength / 2f, transform.position.y, -totalLength / 2f);
            
            GameObject cube;
            
            for (int x = 0; x < sideCount; x++)
            {
                for (int z = 0; z < sideCount; z++)
                {
                    cube = Instantiate(cubePrefab, new Vector3(x * spacing, Random.Range(-heightVariance, 0f), z * spacing) + transform.position, Quaternion.identity);
                    // cube.transform.localScale = new Vector3(width, height + Random.Range(-heightVariance, heightVariance), width);

                    cube.transform.localScale = new Vector3(width, height, width);
                }
            }
        }
    }
}
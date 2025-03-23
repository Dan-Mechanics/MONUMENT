using UnityEngine;

namespace MONUMENT
{
    public class Billboard : MonoBehaviour
    {
        [SerializeField] private Transform cam = default;

        private void Awake()
        {
            if (cam == null) 
                cam = GameObject.FindWithTag("MainCamera").transform;
        }

        private void Update()
        {
            transform.LookAt(cam.position, Vector3.up);
        }
    }
}
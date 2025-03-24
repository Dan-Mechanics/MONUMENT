using UnityEngine;

namespace MONUMENT
{
    public class Billboard : MonoBehaviour
    {
        [SerializeField] private Transform cam = default;
        [SerializeField] private bool onlyY = default;

        private void Awake()
        {
            if (cam == null) 
                cam = GameObject.FindWithTag("MainCamera").transform;
        }

        private void Update()
        {
            transform.LookAt(cam.position, Vector3.up);

            if (onlyY) 
            {
                float y = transform.localEulerAngles.y;
                transform.localEulerAngles = Vector3.up * y;

                /*transform.localRotation = Quaternion.identity;
                transform.Rotate(Vector3.up * y, Space.World);*/
            }
        }
    }
}
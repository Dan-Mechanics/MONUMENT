using UnityEngine;

namespace MONUMENT
{
    public class RandonForce : MonoBehaviour
    {
        [SerializeField] private float speed = default;
        [SerializeField] private Rigidbody rb = default;
        [SerializeField] private bool flatten = default;

        public void Push() 
        {
            Vector3 force = Random.insideUnitSphere * speed;
            if (flatten)
                force.y = 0f;

            rb.AddForce(force, ForceMode.VelocityChange);
        }
    }
}
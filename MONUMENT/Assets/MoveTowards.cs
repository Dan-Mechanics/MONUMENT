using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MONUMENT
{
    public class MoveTowards : MonoBehaviour
    {
        [SerializeField] private float acceleration = default;
        [SerializeField] private float closeDistance = default;
        [SerializeField] private Rigidbody rb = default;
        [SerializeField] private Transform target = default;

        private void FixedUpdate()
        {
            if (Vector3.Distance(transform.position, target.position) <= closeDistance)
                return;

            rb.AddForce((target.position - transform.position).normalized * acceleration, ForceMode.Acceleration);
        }
    }
}
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

        private void Awake()
        {
            if (target != null)
                return;

            target = GameObject.FindWithTag("Player").transform;
        }

        private void FixedUpdate()
        {
            if (Vector3.Distance(transform.position, target.position) <= closeDistance)
                return;

            float mod = 1f;

            if (Vector3.Distance(transform.position, target.position) > 30f)
                mod = 12.5f;

            rb.AddForce(acceleration * mod * (target.position - transform.position).normalized, ForceMode.Acceleration);
        }
    }
}
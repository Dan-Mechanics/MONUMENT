using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MONUMENT
{
    public class RandonForce : MonoBehaviour
    {
        [SerializeField] private float speed = default;
        [SerializeField] private Rigidbody rb = default;


        public void Push() 
        {
            rb.AddForce(Random.insideUnitSphere * speed, ForceMode.VelocityChange);
        }
    }
}
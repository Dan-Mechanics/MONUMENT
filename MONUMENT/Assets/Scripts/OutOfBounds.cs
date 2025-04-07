using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MONUMENT
{
    public class OutOfBounds : MonoBehaviour
    {
        [SerializeField] private float magnitude = default;
        [SerializeField] private SceneSwitcher sceneSwitcher = default;

        private void FixedUpdate()
        {
            if (Vector3.Distance(Vector3.zero, transform.position) > magnitude) 
            {
                sceneSwitcher.Reload();
            }
        }
    }
}
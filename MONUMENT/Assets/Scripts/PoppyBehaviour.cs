using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MONUMENT
{
    public class PoppyBehaviour : MonoBehaviour
    {
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Cube")) 
            {
                Destroy(gameObject);
            }
        }
    }
}
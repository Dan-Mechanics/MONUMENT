using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MONUMENT
{
    public class PoppyBehaviour : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            Destroy(gameObject);
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Cube")) 
            {
                Destroy(gameObject);
            }
        }
    }
}
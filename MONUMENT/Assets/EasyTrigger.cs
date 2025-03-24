using UnityEngine;
using UnityEngine.Events;

namespace MONUMENT
{
    [RequireComponent(typeof(Collider))]
    public class EasyTrigger : MonoBehaviour
    {
        [SerializeField] private string targetTag = default;
        [SerializeField] private UnityEvent onTrigger = default;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(targetTag))
                return;

            onTrigger?.Invoke();
        }
    }
}
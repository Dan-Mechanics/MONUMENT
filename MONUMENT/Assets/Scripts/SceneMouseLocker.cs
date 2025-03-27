using UnityEngine;

namespace MONUMENT
{
    public class SceneMouseLocker : MonoBehaviour
    {
        [SerializeField] private bool locked = default;
        
        private void Start()
        {
            Cursor.visible = !locked;
            Cursor.lockState = locked ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }
}
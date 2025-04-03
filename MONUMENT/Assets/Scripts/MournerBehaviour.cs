using UnityEngine;
using UnityEngine.UI;

namespace MONUMENT
{
    public class MournerBehaviour : MonoBehaviour, IInteractable
    {
        [SerializeField] private Image image = default;
        [SerializeField] private Sprite withPoppySprite = default;

        public void Interact() 
        {
            image.sprite = withPoppySprite;

            // so that we can't give them another one.
            Destroy(this);
        }
    }
}
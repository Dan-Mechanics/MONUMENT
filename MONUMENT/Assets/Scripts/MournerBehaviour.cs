using UnityEngine;
using UnityEngine.UI;

namespace MONUMENT
{
    public class MournerBehaviour : MonoBehaviour, IInteractable
    {
        /*[SerializeField] private Image image = default;
        [SerializeField] private Sprite withPoppySprite = default;*/
        [SerializeField] private GameObject poppy = default;
        [SerializeField] private AudioSource source = default;
        [SerializeField] private AudioClip clip = default;

        public void Interact() 
        {
            poppy.SetActive(true);
            source.PlayOneShot(clip);

            Destroy(this);
        }
    }
}
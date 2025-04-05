using UnityEngine;
using UnityEngine.UI;

namespace MONUMENT
{
    public class RandomSprite : MonoBehaviour
    {
        [SerializeField] private Image image = default;
        [SerializeField] private Sprite[] sprites = default;
        [SerializeField] private Rigidbody rb = default;
        [SerializeField] private Object[] toDeleteWhenSittingDown = default;

        private void Start()
        {
            int index = Random.Range(0, sprites.Length);

            if(index >= sprites.Length - 1) 
            {
                for (int i = 0; i < toDeleteWhenSittingDown.Length; i++)
                {
                    Destroy(toDeleteWhenSittingDown[i]);
                }

                rb.mass = 70f;
            }

            image.sprite = sprites[index];

            Destroy(this);
        }
    }
}
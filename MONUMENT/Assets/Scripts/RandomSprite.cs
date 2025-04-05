using UnityEngine;
using UnityEngine.UI;

namespace MONUMENT
{
    public class RandomSprite : MonoBehaviour
    {
        [SerializeField] private Image image = default;
        [SerializeField] private Sprite[] sprites = default;

        private void Start()
        {
            image.sprite = sprites[Random.Range(0, sprites.Length)];
        }
    }
}
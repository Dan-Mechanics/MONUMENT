using UnityEngine;
using UnityEngine.UI;

namespace MONUMENT
{
    [RequireComponent(typeof(Image))]
    public class BarFloat : MonoBehaviour
    {
        private Image image;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        public void Refresh(float a, float b) 
        {
            image.fillAmount = a / b;
        }
    }
}
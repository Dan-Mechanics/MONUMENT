using UnityEngine;
using UnityEngine.UI;

namespace MONUMENT
{
    public class SpiritTrail : MonoBehaviour
    {
        [SerializeField] private Image image = default;
        [SerializeField] private TrailRenderer trail = default;

        private void FixedUpdate()
        {
            trail.startColor = image.color;
            trail.endColor = Color.clear;
        }
    }
}
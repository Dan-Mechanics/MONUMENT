using UnityEngine;
using UnityEngine.UI;

namespace MONUMENT
{
    public class SpiritTrail : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer rend = default;
        [SerializeField] private TrailRenderer trail = default;

        private void FixedUpdate()
        {
            trail.startColor = rend.color;
            trail.endColor = Color.clear;
        }
    }
}
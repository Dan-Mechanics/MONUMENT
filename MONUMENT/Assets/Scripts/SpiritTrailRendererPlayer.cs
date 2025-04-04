using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MONUMENT
{
    public class SpiritTrailRendererPlayer : MonoBehaviour
    {
        [SerializeField] private Color color = Color.white;
        //[SerializeField] private Color endColor = Color.white;
        [SerializeField] private float fullyVisibleHeight = default;

        private TrailRenderer trailRenderer;
        private Color colorClear;

        private void Awake()
        {
            trailRenderer = GetComponent<TrailRenderer>();

            colorClear = color;
            colorClear.a = 0f;
        }

        private void Update()
        {
            float y = transform.position.y - 15f;
            y = Mathf.Clamp(y, 0f, fullyVisibleHeight) / fullyVisibleHeight;

            trailRenderer.startColor = Color.Lerp(colorClear, color, y);
            trailRenderer.endColor = colorClear;
        }
    }
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MONUMENT
{
    public class RandomOrientation : MonoBehaviour
    {
        [SerializeField] private RectTransform rect = default;

        private void Start()
        {
            Vector3 scale = rect.localScale;

            scale.x *= Random.value >= 0.5f ? 1f : -1f;

            rect.localScale = scale;
        }
    }
}
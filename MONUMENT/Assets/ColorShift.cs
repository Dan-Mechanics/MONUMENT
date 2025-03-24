using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace MONUMENT
{
    [RequireComponent(typeof(Image))]
    public class ColorShift : MonoBehaviour
    {
        [SerializeField] private Color[] colors = default;
        [SerializeField] private float speed = default;

        private Image image;

        int index1;
        int index2 = 1;
        float time;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        private void Start()
        {
            index1 = 0;
            index2 = 1;
        }

        private void FixedUpdate()
        {
            time += Time.fixedDeltaTime * speed;

            if (time > 1f) 
            {
                index1++;
                index2++;

                if (index1 >= colors.Length) { index1 = 0; }
                if (index2 >= colors.Length) { index2 = 0; }

                time = 0f;
            }

            image.color = Color.Lerp(colors[index1], colors[index2], time);
        }
    }
}
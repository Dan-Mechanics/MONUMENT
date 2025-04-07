using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace MONUMENT
{
    public class ColorShift : MonoBehaviour
    {
        [SerializeField] private Color[] colors = default;
        [SerializeField] private float speed = default;
        [SerializeField] private bool randomStart = default;

        //private Image image;

        [SerializeField] private SpriteRenderer rend = null;

        int index1;
        int index2;
        float time;

        /*private void Awake()
        {
            image = GetComponent<Image>();
        }*/

        private void Start()
        {
            if (randomStart) 
            {
                time = Random.Range(0f, 1f);
                index1 = Random.Range(0, colors.Length);
            }

            index2 = index1 + 1;
            if (index2 >= colors.Length) { index2 = 0; }
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

            rend.color = Color.Lerp(colors[index1], colors[index2], time);
        }
    }
}
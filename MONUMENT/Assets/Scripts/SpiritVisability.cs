using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MONUMENT
{
    public class SpiritVisability : MonoBehaviour
    {
        [SerializeField] private GameObject graphics = default;
        [SerializeField] private float fullyVisibleHeight = default;

        private Transform player;

        private void Awake()
        {
            player = GameObject.FindWithTag("Player").transform;
        }

        public void Roll() 
        {
            float y = player.position.y + 10f;
            y = Mathf.Clamp(y, 0f, fullyVisibleHeight) / fullyVisibleHeight;

            graphics.SetActive(Random.value < y);
        }
    }
}
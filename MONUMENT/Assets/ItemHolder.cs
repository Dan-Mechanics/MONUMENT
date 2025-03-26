using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MONUMENT 
{
    class ItemHolder : MonoBehaviour
    {
        [SerializeField] private Image[] images = default;

        [SerializeField] private Item heldItem = default;

        private void Start()
        {
            SetItem(heldItem);
        }

        public void SetItem(Item item)
        {
            for (int i = 0; i < images.Length; i++)
            {
                images[i].sprite = item.sprite;
                images[i].SetNativeSize();
                images[i].GetComponent<RectTransform>().localPosition = item.pos;
            }
        }
    }
}
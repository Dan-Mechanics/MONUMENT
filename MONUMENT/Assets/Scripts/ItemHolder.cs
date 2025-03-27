using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MONUMENT 
{
    class ItemHolder : MonoBehaviour
    {
        public Item HeldItem => heldItem;
        
        [SerializeField] private Image[] images = default;
        [SerializeField] private Item heldItem = default;
        [SerializeField] private Vector2 itemPosUI = default;
        [SerializeField] private Vector2 shadowOffset = default;
        
        private void Start()
        {
            SetItem(heldItem);
        }

        public void SetItem(Item item)
        {
            heldItem = item;
            
            for (int i = 0; i < images.Length; i++)
            {
                images[i].enabled = item != null;

                if (item == null)
                    continue;

                images[i].sprite = item.sprite;
                images[i].SetNativeSize();

                Vector2 currShadowOffset = i > 0 ? this.shadowOffset : Vector2.zero;
                RectTransform rect = images[i].GetComponent<RectTransform>();

                rect.localPosition = itemPosUI + item.offset + currShadowOffset;
                rect.localScale = Vector3.one * item.scale;
            }
        }
    }
}
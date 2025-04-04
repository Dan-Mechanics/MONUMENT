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
        [SerializeField] private float scale = default;

        [SerializeField] private Color gray = Color.white;
        [SerializeField] private Image poppyHotbar = default;
        [SerializeField] private Image shearsHotbar = default;
        [SerializeField] private Image[] hotbars = default;
        [SerializeField] private Item poppy = default;
        [SerializeField] private Item shears = default;

        private void Start()
        {
            SetItem(heldItem);
        }

        private void FixedUpdate()
        {
            SetItem(heldItem);
        }

        public void SetItem(Item item)
        {
            heldItem = item;

            for (int i = 0; i < hotbars.Length; i++)
            {
                hotbars[i].color = gray;
            }

            // Could make this better but this is first iteration EYY ??
            if (heldItem == poppy) 
            {
                poppyHotbar.color = Color.white;
            }
            else if (heldItem == shears)
            {
                shearsHotbar.color = Color.white;
            }

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
                rect.localScale = item.scale * scale * Vector3.one;
            }
        }
    }
}
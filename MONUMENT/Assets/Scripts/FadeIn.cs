using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

namespace MONUMENT
{
    [RequireComponent(typeof(CanvasGroup))]
    public class FadeIn : MonoBehaviour
    {
        private CanvasGroup canvasGroup;
        private bool isFading;
        private float speed;

        [SerializeField] private SceneSwitcher sceneSwitcher = default;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();

            sceneSwitcher.OnSwitchDelayed += Fade;
        }

        private void Update()
        {
            if (!isFading)
                return;
            
            canvasGroup.alpha += Time.deltaTime * speed;

            if (canvasGroup.alpha >= 1f) 
            {
                Done();
            }
        }

        private void Done() 
        {
            isFading = false;
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }

        public void Fade(float time) 
        {
            if (isFading)
                return;

            speed = 1f / time;
            canvasGroup.blocksRaycasts = false;
            isFading = true;
            canvasGroup.alpha = 0f;
        }
    }
}
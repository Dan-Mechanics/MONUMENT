using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

namespace MONUMENT
{
    [RequireComponent(typeof(CanvasGroup))]
    public class FadeOut : MonoBehaviour
    {
        [SerializeField] private bool onStart = default;

        [SerializeField] private UnityEvent onDone = default;
        [SerializeField] private float speed = 1f;

        private CanvasGroup canvasGroup;
        private bool isFading;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Start()
        {
            if (onStart)
                Fade();
        }

        private void Update()
        {
            if (!isFading)
                return;
            
            canvasGroup.alpha -= Time.deltaTime * speed;

            if (canvasGroup.alpha <= 0f) 
            {
                onDone?.Invoke();
                isFading = false;
                canvasGroup.alpha = 0f;
                canvasGroup.blocksRaycasts = false;
            }
        }

        public void Fade() 
        {
            if (isFading)
                return;

            canvasGroup.blocksRaycasts = true;
            isFading = true;
            canvasGroup.alpha = 1f;
        }
    }
}
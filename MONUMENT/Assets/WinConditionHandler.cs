using System;
using UnityEngine;
using UnityEngine.Events;

namespace MONUMENT
{
    /// <summary>
    /// Is there a timer?
    /// </summary>
    public class WinConditionHandler : MonoBehaviour
    {
        public Action<float, float> OnPointsChanged;

        [SerializeField] [Min(0f)] private float pointsToWin = default;
        [SerializeField] private UnityEvent onComplete = default;

        //private float points;

        private float Points 
        { 
            get => Points;
            set 
            {
                Points = value;
                OnPointsChanged?.Invoke(value, pointsToWin);
            }
        }

        private void Start()
        {
            Points = 0f;
        }

        public void GainPoints(float points)
        {
            if (points <= 0f)
                return;

            this.Points += points;

            if (this.Points > pointsToWin) 
            { 
                this.Points = pointsToWin;
                onComplete?.Invoke();
            }
        }
    }
}
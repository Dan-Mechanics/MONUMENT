using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace MONUMENT
{
    /// <summary>
    /// Inhertience with spiriti and poppy similarities?
    /// </summary>
    public class PoppyCollectionHandler : MonoBehaviour
    {
        public Action<float> OnGainPoppyPoints;

        [SerializeField] private ItemHolder itemHolder = default;

        [SerializeField] private float pointsGainedPerPoppy = default;
        [SerializeField] private Item poppy = default;
        [SerializeField] private Item shears = default;

        [SerializeField] private AudioSource source = default;
        [SerializeField] private AudioClip shearsSound = default;

        [Header("Raycast")]

        [SerializeField] private LayerMask mask = default;
        [SerializeField] private float range = default;
        [SerializeField] private Transform eyes = default;

        private void FixedUpdate()
        {
            RaycastHit hit;

            if (!Physics.Raycast(eyes.position, eyes.forward, out hit, range, mask, QueryTriggerInteraction.Collide))
                return;

            ProcessHit(hit);
        }

        /// <summary>
        /// GOOD CODING HERE !!!
        /// </summary>
        private void ProcessHit(RaycastHit hit) 
        {
            MournerBehaviour mourner = hit.transform.GetComponent<MournerBehaviour>();

            if (mourner != null && itemHolder.HeldItem == poppy) 
            {
                itemHolder.SetItem(shears);
                mourner.Interact();

                OnGainPoppyPoints?.Invoke(pointsGainedPerPoppy);

                return;
            }

            PoppyBehaviour poppyBehaviour = hit.transform.GetComponent<PoppyBehaviour>();

            if (poppyBehaviour != null && itemHolder.HeldItem == shears)
            {
                itemHolder.SetItem(poppy);
                source.PlayOneShot(shearsSound);
                poppyBehaviour.Interact();

                return;
            }
        }
    }
}
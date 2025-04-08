using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MONUMENT
{
    public class PlayerAudioSourceHandler : MonoBehaviour
    {
        private AudioSource audioSource;

        private float defaultVolume = 1f;
        private float defaultPitch = 1f;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();

            defaultVolume = audioSource.volume;
            defaultPitch = audioSource.pitch;
        }

        void Update()
        {
            if (!audioSource.isPlaying)
            {
                audioSource.volume = defaultVolume;
                audioSource.pitch = defaultPitch;
            }
        }
    }
}

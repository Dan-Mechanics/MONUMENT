using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MONUMENT
{
    /// <summary>
    /// Changes update rates.
    /// Also does quit() but cant rename yet.
    /// </summary>
    public class SceneSwitcher : MonoBehaviour
    {
        public Action<float> OnSwitchDelayed;

        [SerializeField] private float switchTime = 0.75f;
        private bool isSwitching;

        /// <summary>
        /// We do this here because the SceneSwitcher is present in each scene.
        /// </summary>
        private void Start()
        {
            Application.targetFrameRate = 300;
            //Time.fixedDeltaTime = 1f / 64f;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
                Reload();

            if (Input.GetKeyDown(KeyCode.Escape))
                Quit();
        }

        public void Reload()
        {
            Switch(SceneManager.GetActiveScene().name);
        }

        public void Quit() 
        {
            print("QUIT !!");
            Application.Quit();
        }

        public void Switch(string name)
        {
            if (name == "Quit")
            {
                Quit();
                return;
            }
            
            SceneManager.LoadScene(name);
        }

        public void SwitchDelayed(string name) 
        {
            if (isSwitching)
                return;
            
            isSwitching = true;

            OnSwitchDelayed?.Invoke(switchTime);

            StartCoroutine(SwitchDelayedCoroutine(name));
        }

        private IEnumerator SwitchDelayedCoroutine(string name) 
        {
            yield return new WaitForSeconds(switchTime);

            Switch(name);
        }
    }
}
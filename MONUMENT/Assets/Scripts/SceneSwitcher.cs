using UnityEngine;
using UnityEngine.SceneManagement;

namespace AppleAvalanche
{
    /// <summary>
    /// Changes update rates.
    /// </summary>
    public class SceneSwitcher : MonoBehaviour
    {
        /// <summary>
        /// We do this here because the SceneSwitcher is present in each scene.
        /// </summary>
        private void Start()
        {
            Application.targetFrameRate = 300;
            //Time.fixedDeltaTime = 1f / 64f;
        }

        public void Switch(string name)
        {
            SceneManager.LoadScene(name);
        }
    }
}
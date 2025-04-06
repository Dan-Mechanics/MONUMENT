using UnityEngine;
using UnityEngine.SceneManagement;

namespace AppleAvalanche
{
    /// <summary>
    /// Changes update rates.
    /// Also does quit() but cant rename yet.
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

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.R))
                Switch(SceneManager.GetActiveScene().name);

            if (Input.GetKeyDown(KeyCode.Escape))
                Quit();
        }

        public void Quit() => Application.Quit();

        public void Switch(string name)
        {
            SceneManager.LoadScene(name);
        }
    }
}
using UnityEngine;

namespace MONUMENT
{
    public class QuitHandler : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) 
            {
                Quit();
            }
        }

        public void Quit() 
        {
            Application.Quit();
        }
    }
}
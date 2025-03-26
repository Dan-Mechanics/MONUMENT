using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MONUMENT
{
    public class InitScreen : MonoBehaviour
    {
        public const float TWO_THIRDS = 2f / 3f;

        private void Awake()
        {
            int height = 240;

            Screen.SetResolution(height * (int)(2f + TWO_THIRDS), height, true);
        }
    }
}

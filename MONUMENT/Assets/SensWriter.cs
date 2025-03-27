using UnityEngine;
using UnityEngine.UI;

namespace MONUMENT
{
    public class SensWriter : MonoBehaviour
    {
        public const float DEFAULT_SENS = 0.66f;
        
        [SerializeField] private InputField field = default;

        private float sens = DEFAULT_SENS;

        private void Start()
        {
            field.text = SaveSystem.Load()?.sens.ToString();
        }

        public void Write() 
        {
            float.TryParse(field.text, out sens);
        }

        public void OnDestroy()
        {
            SaveSystem.Save(sens);
        }
    }
}
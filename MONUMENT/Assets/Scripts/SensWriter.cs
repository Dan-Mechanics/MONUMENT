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

            Write();
            field.text = sens.ToString();
        }

        public void Write() 
        {
            field.text = field.text.Replace(".", ",");

            if (!float.TryParse(field.text, out sens) || sens <= 0f)
                sens = DEFAULT_SENS;
        }

        public void OnDestroy()
        {
            Write();
            field.text = sens.ToString();

            print(sens);

            SaveSystem.Save(sens);
        }
    }
}
using System;

namespace MONUMENT
{
    [Serializable]
    public class SaveData 
    {
        public float sens;

        public SaveData(float sens)
        {
            this.sens = sens;
        }
    }
}
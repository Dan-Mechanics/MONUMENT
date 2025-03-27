using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MONUMENT
{
    public static class SaveSystem
    {
        private static readonly string Path = Application.persistentDataPath + "/savedata";

        public static void Save(float sens) 
        {
            Debug.Log($"saving {Path} ... ");

            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(Path, FileMode.Create);

            SaveData saveData = new SaveData(sens);

            formatter.Serialize(stream, saveData);
            stream.Close();
        }

        public static SaveData Load() 
        {
            if (!File.Exists(Path))
            {
                Debug.LogWarning($"save file not found in {Path} ... ");
                return null;
            }

            Debug.Log($"loading {Path} ... ");

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(Path, FileMode.Open);

            SaveData saveData = (SaveData)formatter.Deserialize(stream);

            stream.Close();

            return saveData;
        }
    }
}

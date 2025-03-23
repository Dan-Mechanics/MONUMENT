using UnityEngine;

namespace MONUMENT
{
    [CreateAssetMenu(fileName = "Sens", menuName = "ScriptableObjects/Sens", order = 1)]
    public class SensSave : ScriptableObject
    {
        public float sens = 0.33f;
    }
}
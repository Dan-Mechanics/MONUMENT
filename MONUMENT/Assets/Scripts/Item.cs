using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MONUMENT
{
    [CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
    public class Item : ScriptableObject
    {
        public Sprite sprite;
        public Vector2 offset;
        public float scale;
    }
}
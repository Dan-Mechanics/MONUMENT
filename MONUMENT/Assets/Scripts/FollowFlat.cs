using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace PROJECTNAME
{
    public class FollowFlat : MonoBehaviour
    {
        [SerializeField] private Transform target = null;

        private Vector3 pos;

        private void FixedUpdate()
        {
            pos = target.position;
            pos.y = 0f;
            transform.position = pos;
        }
    }
}
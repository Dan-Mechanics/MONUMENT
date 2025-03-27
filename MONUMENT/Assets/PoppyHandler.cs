using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace MONUMENT
{
    public class PoppyHandler : MonoBehaviour
    {
        public Action<float> OnGainPoppyPoints;

        [SerializeField] private Item poppy = default;
        [SerializeField] private Item shears = default;

        [SerializeField] private ItemHolder itemHolder = default;


    }
}
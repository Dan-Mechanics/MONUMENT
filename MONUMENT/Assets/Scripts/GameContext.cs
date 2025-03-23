using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MONUMENT
{
    public class GameContext : MonoBehaviour
    {
        [SerializeField] private WinConditionHandler spritWin = default;
        [SerializeField] private WinConditionHandler poppyWin = default;
        [SerializeField] private BarFloat spiritBar = default;
        [SerializeField] private BarFloat poppyBar = default;

        private void Awake()
        {
            spritWin.OnPointsChanged += spiritBar.Refresh;
            poppyWin.OnPointsChanged += poppyBar.Refresh;
        }

        private void OnDestroy()
        {
            spritWin.OnPointsChanged -= spiritBar.Refresh;
            poppyWin.OnPointsChanged -= poppyBar.Refresh;
        }
    }
}
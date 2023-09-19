using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Events;

namespace SVS.PlayerAgent
{
    public class PlayerPoints : MonoBehaviour
    {
        public UnityEvent<int> OnPointsValueChange;
        public UnityEvent OnPickUpPoints;
        private int points;
        public int Points
        {
            get { return points; }
            private set { points = value; }
        }

        private void Start()
        {
            OnPointsValueChange?.Invoke(Points);
        }

        public void Add(int amount)
        {
            Points += amount;
            OnPickUpPoints?.Invoke();
            OnPointsValueChange?.Invoke(Points);
        }
    }
}


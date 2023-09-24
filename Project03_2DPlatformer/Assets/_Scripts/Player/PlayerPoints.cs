using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using SVS.Levels;
using UnityEngine;
using UnityEngine.Events;

namespace SVS.PlayerAgent
{
    public class PlayerPoints : MonoBehaviour, ISaveData
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

        public void SaveData()
        {
            SaveSystem.SavePoints(Points);   
        }

        public void LoadData()
        {
            Points = SaveSystem.LoadPoints();
            OnPointsValueChange?.Invoke(Points);
        }
    }
}


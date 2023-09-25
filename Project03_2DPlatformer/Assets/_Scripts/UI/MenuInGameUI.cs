using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using SVS.Levels;
using UnityEngine;

namespace SVS.UI
{
    public class MenuInGameUI : MonoBehaviour
    {
        private LevelManagement levelManagement;
        public GameObject menuPanel;

        private void Awake()
        {
            levelManagement = FindObjectOfType<LevelManagement>();
            if (levelManagement == null)
            {
                Debug.LogError("No Level Manager Found");
            }
        }

        public void ToggleMenu()
        {
            menuPanel.SetActive(!menuPanel.activeSelf);
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        }

        public void ResetTimeScale()
        {
            Time.timeScale = 1;
        }

        public void LoadMenu()
        {
            levelManagement.LoadMenu();
        }
        
        public void RestartLevel()
        {
            levelManagement.RestartCurrentLevel();
        }
    }
}


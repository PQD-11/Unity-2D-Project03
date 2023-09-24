using System.Collections;
using System.Collections.Generic;
using SVS.Levels;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SVS.UI
{
    public class ContinueButton : MonoBehaviour
    {
        public LevelManagement levelManagement;
        public Button continueButton;
        private int levelIndex = -1;
        public UnityEvent OnLevelLoaded;

        private void Awake()
        {
            if (levelManagement == null)
            {
                levelManagement = FindObjectOfType<LevelManagement>();
            }
            continueButton = GetComponent<Button>();
        }

        private void Start()
        {
            levelIndex = SaveSystem.LoadLevelIndex();
            if (levelIndex > -1)
            {
                continueButton.onClick.AddListener(() => levelManagement.LoadSceneWithIndex(levelIndex));
                continueButton.interactable = true;
                OnLevelLoaded?.Invoke();    
            }
        }
    }
}

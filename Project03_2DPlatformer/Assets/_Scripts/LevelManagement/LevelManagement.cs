using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SVS.Levels
{
    public class LevelManagement : MonoBehaviour
    {
        [SerializeField] private int level_1SceneBuildIndex, menuSceneBuildIndex, winSceneBuildIndex;

        public void RestartCurrentLevel()
        {
            LoadSceneWithIndex(SceneManager.GetActiveScene().buildIndex);
        }

        public void LoadStartLevel()
        {
            LoadSceneWithIndex(level_1SceneBuildIndex);
        }

        public void LoadNextLevel()
        {
            LoadSceneWithIndex(GetNextLevelIndex());
        }

        public void LoadMenu()
        {
            LoadSceneWithIndex(menuSceneBuildIndex);
        }

        public void LoadWinScreen()
        {
            LoadSceneWithIndex(winSceneBuildIndex);
        }

        public void LoadSceneWithIndex(int index)
        {
            SceneManager.LoadScene(index);
        }

        public int GetNextLevelIndex()
        {
            if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
            {
                return SceneManager.GetActiveScene().buildIndex + 1;
            }
            else
            {
                return winSceneBuildIndex;
            }
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}


using Assets.GameScripts.Models;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.GameScripts.Views
{
    public class HandleInputs : MonoBehaviour
    {
        public void SetDifficultyHard()
        {
            Debug.Log("easy click");
            GameVars.Difficulty = Difficulty.Hard;
            GameVars.ResetSpeed();
            SceneManager.LoadScene(1);
        }

        public void SetDifficultyEasy()
        {
            Debug.Log("hard click");
            GameVars.Difficulty = Difficulty.Easy;
            GameVars.ResetSpeed();
            SceneManager.LoadScene(1);
        }

        public void ReturnToLoadingScreen()
        {
            Debug.Log("hard click");
            GameVars.ResetSpeed();
            SceneManager.LoadScene(0);
        }

        public class SceneChanger : MonoBehaviour
        {
            // Method to change the scene
            public void LoadScene(string sceneName)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}

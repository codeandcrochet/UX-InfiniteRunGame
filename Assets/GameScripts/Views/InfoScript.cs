using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InfoScript : MonoBehaviour
{

    public void LoadSceneByName()
    {
        SceneManager.LoadScene("Scenes/InfoScene");
    }

    public void LoadNextInBuild()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}

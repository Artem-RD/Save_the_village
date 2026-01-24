using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        //SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
       
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
    }
}

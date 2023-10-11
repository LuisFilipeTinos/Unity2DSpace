using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    [SerializeField]
    LevelLoader levelLoaderScript;

    public void RestartGame()
    {
        //SceneManager.LoadScene(1);
        levelLoaderScript.LoadLevel(1);
    }

    public void QuitGamne()
    {
        Application.Quit();
    }
}

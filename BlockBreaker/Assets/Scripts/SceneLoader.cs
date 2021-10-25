using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartMenu()
    {
        FindObjectOfType<GameStatus>().resetGame();
        SceneManager.LoadScene(0);
    }

    public void LoadWinScreen()
    {
        SceneManager.LoadScene("You Won");
    }

    public void LoadLoseScreen()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void GameOver(){
        gameOverPanel.SetActive(true);
    }

    // Update is called once per frame
    public void RestartGame()
    {
        // Reload the current scene to restart the game.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

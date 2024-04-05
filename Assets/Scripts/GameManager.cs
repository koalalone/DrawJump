using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameOver = false;
    public GameObject player;
    public GameObject gameOverMenu;

    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Restart();
            }
        }
    }

    public void Restart()
    {
        gameOver = false;
        gameOverMenu.SetActive(false);
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    public void EndGame()
    {
        gameOver = true;
        Destroy(player.gameObject);
        Time.timeScale = 0;
        gameOverMenu.SetActive(true);
    }
}

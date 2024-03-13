using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameOver = false;
    public GameObject player;

    void Update()
    {
        // Oyun bitti mi kontrol�
        if (gameOver)
        {
            // Yeniden ba�latma tu�una bas�ld� m� kontrol�
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Oyunu yeniden ba�lat
                Restart();
            }
        }
    }

    private void Restart()
    {
        gameOver = false;
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        gameOver = true;
        Destroy(player.gameObject);
        Time.timeScale = 0;
    }
}

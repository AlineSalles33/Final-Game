using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverScreen;

    private void OnEnable()
    {
        Health.OnPlayerDied += GameOver;
    }

    private void OnDisable()
    {
        Health.OnPlayerDied -= GameOver;
    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
        Time.timeScale = 0f; // optional: pauses the game
    }

    public void Retry()
    {
        Time.timeScale = 1f; // resume time if it was paused
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Die()
    {
        // Do any death logic here (animation, sounds, etc.)
        FindObjectOfType<GameManager>().GameOver();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI liveText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    public GameObject titleScreen;
    public GameObject pauseScreen;

    private int score;
    public int lives = 3;

    private float spawnRate = 1.0f;

    public bool isGameActive;
    private bool isGamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   
        if (isGameActive)
        {
            liveText.text = "Lives: " + lives;

            if (lives <= 0)
            {
                GameOver();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isGameActive)
        {
            if (!isGamePaused)
            {
                Time.timeScale = 0;
                isGamePaused = true;
                pauseScreen.SetActive(true);
            } 
            else
            {
                Time.timeScale = 1;
                isGamePaused = false;
                pauseScreen.SetActive(false);
            }
        }
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);

            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        UpdateScore(0);
        spawnRate /= difficulty;

        StartCoroutine(SpawnTarget());
        titleScreen.SetActive(false);
    }
}
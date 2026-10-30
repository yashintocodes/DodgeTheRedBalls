using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI & Scoring")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText; // Drag HighScoreText here
    public GameObject pauseMenuPanel;
    public GameObject resumeButton;
    public GameObject quitButton;

    public float score = 0f;
    public float scoreMultiplier = 1f;

    [Header("Power-up States")]
    public bool isInvulnerable = false;
    private float invulnerabilityTimer = 0f;

    private bool isPaused = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) ResumeGame();
            else PauseGame();
        }

        if (!isPaused)
        {
            score += Time.deltaTime * 10f * scoreMultiplier;
            if (scoreText != null)
            {
                scoreText.text = "Score: " + Mathf.FloorToInt(score);
            }

            if (isInvulnerable)
            {
                invulnerabilityTimer -= Time.deltaTime;
                if (invulnerabilityTimer <= 0f)
                {
                    isInvulnerable = false;
                    scoreMultiplier = 1f;
                }
            }
        }
    }

    private void UpdateHighScoreDisplay()
    {
        int currentScore = Mathf.FloorToInt(score);
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore;
        }
    }

    public void TriggerBlueBallPowerUp()
    {
        scoreMultiplier = 3f;
        isInvulnerable = true;
        invulnerabilityTimer = 3f;

        StopAllCoroutines();
        StartCoroutine(BlinkScoreRoutine(5f));
    }

    public void TriggerGameOver()
    {
        UpdateHighScoreDisplay();

        if (pauseMenuPanel != null)
        {
            pauseMenuPanel.SetActive(true);
        }

        if (resumeButton != null) resumeButton.SetActive(false);
        if (quitButton != null) quitButton.SetActive(false);

        Time.timeScale = 0f;
        isPaused = true;
    }

    public void PauseGame()
    {
        UpdateHighScoreDisplay();

        if (pauseMenuPanel != null)
        {
            pauseMenuPanel.SetActive(true);
        }

        if (resumeButton != null) resumeButton.SetActive(true);
        if (quitButton != null) quitButton.SetActive(true);

        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        if (pauseMenuPanel != null)
        {
            pauseMenuPanel.SetActive(false);
        }
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    IEnumerator BlinkScoreRoutine(float duration)
    {
        float elapsed = 0f;
        Color originalColor = scoreText != null ? scoreText.color : Color.white;

        while (elapsed < duration)
        {
            if (scoreText != null)
            {
                scoreText.color = (scoreText.color == Color.blue) ? originalColor : Color.blue;
            }
            yield return new WaitForSeconds(0.2f);
            elapsed += 0.2f;
        }

        if (scoreText != null)
        {
            scoreText.color = originalColor;
        }
    }
}
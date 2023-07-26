using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TimerScript : MonoBehaviour
{
    public float levelTime = 5f;
    public UnityEngine.UI.Text timerText;
    private float currentTime;
    private bool isGameOver = false;

    private void Start()
    {
        currentTime = levelTime;
        UpdateTimerText();
    }

    private void Update()
    {
        if (!isGameOver)
        {
            if (currentTime > 0f)
            {
                currentTime -= Time.deltaTime;
                UpdateTimerText();
            }
            else
            {
                GameOver();
            }
        }
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void GameOver()
    {
        isGameOver = true;
        timerText.text = "GameOver";

        // Czekamy przez 2 sekundy przed za³adowaniem sceny, aby gracz móg³ zobaczyæ napis "GameOver"
        StartCoroutine(LoadLevelAfterDelay(2f));
    }

    private IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(4);
    }
}

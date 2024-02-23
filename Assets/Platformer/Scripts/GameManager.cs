using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;

    private int score = 0;
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    Debug.LogError("GameManager instance not found in the scene. Make sure GameManager is added to a GameObject in the scene.");
                }
            }
            return instance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int intTime = 400 - (int)Time.realtimeSinceStartup;
        string timeStr = $"TIME \n {intTime}";
        timerText.text = timeStr;
    }

    // Method to increment the player's score
    public void IncrementScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    // Method to update the score text
    private void UpdateScoreText()
    {
        scoreText.text = $"SCORE \n {score}";
    }
}
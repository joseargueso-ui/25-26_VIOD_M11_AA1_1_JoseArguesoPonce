using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;

    int score;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateText();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateText();
    }

    void UpdateText()
    {
        scoreText.text = score.ToString();
    }
}
    
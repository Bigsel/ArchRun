using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;

    public Text scoreText;

    float score = 0f;
    float pointIncreasePerSecond;

    public void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        scoreText.text = score.ToString();
        pointIncreasePerSecond = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        score += pointIncreasePerSecond * Time.deltaTime;
        if(scoreText != null)
        {
            scoreText.text = score.ToString("0");
            if(score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetFloat("HighScore", score);
            }
            
        }
    }

    public void AddPoint()
    {
        score += 100;
    }
}

using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int point)
    {
        score += point;
        scoreText.text = score.ToString();
    }
}

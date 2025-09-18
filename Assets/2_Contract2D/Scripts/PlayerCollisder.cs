using UnityEngine;
using TMPro;
public class PlayerCollisder : MonoBehaviour
{
    public GameManager GameManager;
    private void Awake()
    {
        GameManager = GameObject.FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("coin"))
        {
            GameManager.AddScore(1);
            Destroy(other.gameObject);
        }
    }
}


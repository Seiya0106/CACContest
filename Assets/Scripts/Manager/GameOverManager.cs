using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameoverText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameoverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameoverText.gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}

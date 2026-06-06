using UnityEngine;
using TMPro;

public class GameClearManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameClearText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameClearText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameClearText.gameObject.SetActive(true);
        }
    }
}

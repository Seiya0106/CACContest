using UnityEngine;
using TMPro;

public class GameClearManager : MonoBehaviour
{
    [SerializeField] private PlayerMove playerMove;
    [SerializeField] private TextMeshProUGUI gameClearText;
    private bool isGameCleared = false;
    public bool IsGameCleared => isGameCleared;
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
            playerMove.enabled = false;   // プレイヤーの移動を無効にする
            isGameCleared = true;
            gameClearText.gameObject.SetActive(true);
        }
    }
}

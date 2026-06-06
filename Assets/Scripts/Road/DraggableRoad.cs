using UnityEngine;

public class DraggableRoad : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private BoxCollider2D boxCollider;
    private Vector3 screenPoint;    // オブジェクトのスクリーン座標を保存する変数
    private Vector3 offset;         // オブジェクトの位置とマウスの位置の差分を保存する変数
    private Vector3 minScreenBounds;   // カメラの左下のワールド座標を保存する変数
    private Vector3 maxScreenBounds;   // カメラの右上のワールド座標を保存する変数
    private bool wasDragged = false;   // ドラッグされたかどうかを保存する変数
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
        if (boxCollider != null)
        {
            boxCollider.isTrigger = true;   // ドラッグ中は他のオブジェクトと干渉しないように当たり判定を無効にする
        }
    }

    // Update is called once per frame
    void Update()
    {
        HitJudgementActiveAfterDrag();
    }

    /// <summary>
    /// オブジェクトがドラッグされた後の当たり判定を有効にする処理
    /// </summary>
    private void HitJudgementActiveAfterDrag()
    {
        if (wasDragged)
        {
            boxCollider.isTrigger = false;   // ドラッグされた後はPlayerが足場にできるように当たり判定を有効にする
            ChangeToGray();
        }
    }

    /// <summary>
    /// オブジェクトの色を灰色に変更する処理
    /// </summary>
    private void ChangeToGray()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    /// <summary>
    /// オブジェクトがクリックされたときの処理
    /// </summary>
    private void OnMouseDown()
    {
        if (wasDragged) return; // 2回目以降は処理しない
        
        screenPoint = mainCamera.WorldToScreenPoint(transform.position);  // オブジェクトのワールド座標をスクリーン座標に変換して保存
        offset = transform.position - mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));  // オブジェクトの位置とマウスの位置の差分を計算して保存 
    }

    /// <summary>
    /// オブジェクトがドラッグされているときの処理
    /// </summary>
    private void OnMouseDrag()
    {
        if (wasDragged) return; // 2回目以降は処理しない

        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);  // マウスの現在の位置をスクリーン座標で取得
        Vector3 currentPosition = mainCamera.ScreenToWorldPoint(currentScreenPoint) + offset;   // スクリーン座標をワールド座標に変換し、オフセットを加算して新しい位置を計算

        // カメラの左下（0, 0）と右上（1, 1）のワールド座標を取得
        minScreenBounds = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, screenPoint.z));
        maxScreenBounds = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, screenPoint.z));

        // 計算した位置が画面の外に出ないように制限
        currentPosition.x = Mathf.Clamp(currentPosition.x, minScreenBounds.x, maxScreenBounds.x);
        currentPosition.y = Mathf.Clamp(currentPosition.y, minScreenBounds.y, maxScreenBounds.y);

        transform.position = currentPosition;
    }

    /// <summary>
    /// オブジェクトがドラッグされた後の処理
    /// </summary>
    private void OnMouseUp()
    {
        wasDragged = true;
    }
}

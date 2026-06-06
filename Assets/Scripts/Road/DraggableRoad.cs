using UnityEngine;

public class DraggableRoad : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 screenPoint;    // オブジェクトのスクリーン座標を保存する変数
    private Vector3 offset;         // オブジェクトの位置とマウスの位置の差分を保存する変数
    private bool wasDragged = false;   // ドラッグされたかどうかを保存する変数
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// オブジェクトがクリックされたときの処理
    /// </summary>
    private void OnMouseDown()
    {
        if (wasDragged) return;
        screenPoint = mainCamera.WorldToScreenPoint(transform.position);  // オブジェクトのワールド座標をスクリーン座標に変換して保存
        offset = transform.position - mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));  // オブジェクトの位置とマウスの位置の差分を計算して保存 
    }

    /// <summary>
    /// オブジェクトがドラッグされているときの処理
    /// </summary>
    private void OnMouseDrag()
    {
        if (wasDragged) return;
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);  // マウスの現在の位置をスクリーン座標で取得
        Vector3 currentPosition = mainCamera.ScreenToWorldPoint(currentScreenPoint) + offset;   // スクリーン座標をワールド座標に変換し、オフセットを加算して新しい位置を計算
        transform.position = currentPosition;
    }

    /// <summary>
    /// オブジェクトがドラッグされた後の処理
    /// </summary>
    private void OnMouseUp()
    {
        wasDragged = true;   // ドラッグされたことを記録
    }
}

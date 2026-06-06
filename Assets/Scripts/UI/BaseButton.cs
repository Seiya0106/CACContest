using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseButton : MonoBehaviour,
IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, 
IPointerEnterHandler, IPointerExitHandler
{
    [Header("共通アニメーション設定")]
    public CanvasGroup canvasGroup;
    public Vector3 originalScale;
    protected virtual void Awake()
    {
        originalScale = transform.localScale;   // ボタンの元の大きさを保存する処理
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnExcute();
    }

    protected abstract void OnExcute();   // ボタンがクリックされたときの処理を定義する抽象メソッド

    // ボタンにカーソルが乗ったときの処理
    public virtual void OnPointerEnter(PointerEventData eventData) 
    {
        Highlight();
        Debug.Log("Pointer Entered: " + gameObject.name);
    }

    // ボタンから離れたときの処理
    public virtual void OnPointerExit(PointerEventData eventData) 
    {
        ResetVisual();
        Debug.Log("Pointer Exited: " + gameObject.name);
    }

    // ボタンが押されたときの演出
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        transform.DOScale(originalScale * 0.9f, 0.12f).SetEase(Ease.OutCubic);
        if(canvasGroup != null) canvasGroup.DOFade(0.8f, 0.12f);
    }

    // ボタンから離れた時の演出
    public virtual void OnPointerUp(PointerEventData eventData)
    {
        transform.DOScale(originalScale * 1.1f, 0.12f).SetEase(Ease.OutCubic);
        if(canvasGroup != null) canvasGroup.DOFade(1f, 0.12f);
    }

    // ボタンが少し大きくする演出
    protected virtual void Highlight()
    {
        transform.DOScale(originalScale * 1.1f, 0.12f).SetEase(Ease.OutCubic);   // ボタンを少し大きくする処理
    }

    // ボタンを元の大きさに戻す演出
    protected virtual void ResetVisual()
    {
        transform.DOScale(originalScale, 0.12f).SetEase(Ease.OutCubic);   // ボタンを元の大きさに戻す処理
    }
}

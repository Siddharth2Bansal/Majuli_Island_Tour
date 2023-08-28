using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;
public class video_progressBar : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    // Start is called before the first frame update
    [SerializeField]
    private VideoPlayer videoPlayer;
    private Image progress;
    private void Awake()
    {
        progress = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.frameCount > 0)
        {
            progress.fillAmount = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        TrySkip(eventData);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        TrySkip(eventData);
    }
    private void TrySkip(PointerEventData eventData)
    {
        Vector2 localPoint;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(progress.rectTransform, eventData.position, Camera.main, out localPoint))
        {
            float pct = Mathf.InverseLerp(progress.rectTransform.rect.xMin, progress.rectTransform.rect.xMax, localPoint.x);
            var frame = videoPlayer.frameCount * pct;
            videoPlayer.frame = (long)frame;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableImage : MonoBehaviour
{
    [System.Serializable]
    public class ClickablePoint
    {
        public Vector2 position; // Position of the clickable point
        public GameObject scriptObject; // Object with the C# script to run for this point
    }

    public Texture2D image; // Image to display
    public List<ClickablePoint> clickablePoints; // List of clickable points

    void Start()
    {
        // Set the image as a background sprite
        Sprite sprite = Sprite.Create(image, new Rect(0, 0, image.width, image.height), Vector2.one * 0.5f);
        GetComponent<Image>().sprite = sprite;

        // Generate clickable points
        foreach (ClickablePoint point in clickablePoints)
        {
            // Create a new button at the specified position
            GameObject buttonObj = new GameObject("Button");
            buttonObj.transform.SetParent(transform);
            RectTransform rectTransform = buttonObj.AddComponent<RectTransform>();
            rectTransform.anchorMin = rectTransform.anchorMax = Vector2.zero;
            rectTransform.anchoredPosition = point.position;
            Button button = buttonObj.AddComponent<Button>();
            button.onClick.AddListener(() => OnPointClick(point.scriptObject));
        }
    }

    void OnPointClick(GameObject scriptObject)
    {
        // Run the specified C# script for the clicked point
        scriptObject.GetComponent<MonoBehaviour>().SendMessage("YourScriptMethodName");

    }
}

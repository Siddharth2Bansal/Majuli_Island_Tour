using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;
using UnityEngine.Video;


public class ToggleVideo : MonoBehaviour
{
    public Button changeClipButton;
    public string newClipPath;

    public GameObject videoRenderer;
    private VideoPlayer vp;

    private void Start()
    {
        vp = videoRenderer.GetComponent<VideoPlayer>();
        changeClipButton.onClick.AddListener(OnChangeClipButtonClick);
    }

    private void OnChangeClipButtonClick()
    {
        VideoClip newClip = AssetDatabase.LoadAssetAtPath<VideoClip>(newClipPath);
        vp.clip = newClip;
    }
}

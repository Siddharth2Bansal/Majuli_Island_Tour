using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;
using UnityEngine.InputSystem;
using UnityEngine.Video;

public class startVideo_script : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer;
    public GameObject videoPlayer3d;
    public InputActionProperty tab_trigger;
    public GameObject[] hide_child;
    public string newClipPath;
    public Vector3 offset;
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float i = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
        if (i > 0.95) { 
            button.SetActive(true);
            Debug.Log("complete");
            tab_trigger.action.Enable();
            render_video();
            foreach (GameObject child in hide_child)
            {
                child.SetActive(false);
            }
        }

    }
    void render_video()
    {
        videoPlayer3d.GetComponent<VideoPlayer>().clip = AssetDatabase.LoadAssetAtPath<VideoClip>(newClipPath);

        GameObject.Find("CameraOffset").transform.rotation = Quaternion.Euler(offset);
        videoPlayer3d.SetActive(true);
        string folder_path = "Assets/Images/3DVideos/";
        string mat_path = folder_path + "video_mat" + ".mat";
        Material mater = AssetDatabase.LoadAssetAtPath<Material>(mat_path);
        RenderSettings.skybox = mater;
    }
}

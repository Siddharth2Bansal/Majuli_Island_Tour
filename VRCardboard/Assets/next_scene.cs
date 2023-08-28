using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using UnityEngine.InputSystem;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class next_scene : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer;
    public GameObject videoPlayer3d;
    public InputActionProperty tab_trigger;
    public GameObject[] hide_child;
    public string newClipPath;
    public Vector3 offset;
    public string sceneName;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(signfunc);
    }
   

    // Update is called once per frame
    void signfunc()
    {
        button.SetActive(true);

        Debug.Log("complete");
        tab_trigger.action.Enable();
        render_video();
        foreach (GameObject child in hide_child)
        {
            child.SetActive(false);
        }
        //SceneManager.LoadScene(sceneName);
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

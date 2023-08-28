using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Video;

public class video_360_button : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject video_player;
    public cur_skybox sky;
    public string newClipPath;
    public Vector3 offset;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(render_video);
    }

    // Update is called once per frame
    void render_video()
    {
        video_player.GetComponent<VideoPlayer>().clip = AssetDatabase.LoadAssetAtPath<VideoClip>(newClipPath);
        Debug.Log(newClipPath);
        int len = newClipPath.Length;
        int last_index = newClipPath.LastIndexOf('/');
        int last_index_dot = newClipPath.LastIndexOf('.');
        last_index = last_index + 1;
        string video_mp4 = newClipPath.Substring(last_index);
        string video_name = video_mp4.Substring(0,(video_mp4.Length -4) );
        Debug.Log("videoname is " + video_name);
        string t_id = newClipPath.Substring(len - 5, 1);
        Debug.Log(t_id);
/*        switch (t_id)
        {
            case "1":
                cameraRotation = new Vector3(42, 98, 100);
                break;
            case "2":
                cameraRotation = new Vector3(319, 264, 272);
                break;
            case "3":
                cameraRotation = new Vector3(349, 271, 268);
                break;
            case "4":
                cameraRotation = new Vector3(358, 270, 270);
                break;
            case "5":
                cameraRotation = new Vector3(344, 266, 268);
                break;
            case "6":
                cameraRotation = new Vector3(339, 278, 269);
                break;
            case "7":
                cameraRotation = new Vector3(273, 343, 189);
                break;
            case "8":
                cameraRotation = new Vector3(325, 95, 85);
                break;
            default:
                cameraRotation = new Vector3(0, 0, 0);
                break;
        }
        */
        GameObject.Find("CameraOffset").transform.rotation = Quaternion.Euler(offset);
        //T1   Vector3(41.5964928,98.0890961,100.460678)
        //T2   Vector3(319.270752,264.226044,272.590149)    
        //T3   Vector3(349.188232,271.440399,268.136017)
        //T4   Vector3(358.515839,270.27948,270.709778)
        //T5   Vector3(344.064758,266.95993,268.864868)
        //T6   Vector3(339.188507,278.03183,269.404236)
        //T7   Vector3(273.328125,343.079895,189.943329)
        //T8   Vector3(325.709137,95.8270798,85.9500809)
        video_player.SetActive(true);
        sky.value = RenderSettings.skybox;
        string folder_path = "Assets/Images/Transportation/";
        string mat_path = folder_path + "transport_mat" + ".mat";
        Material mater = AssetDatabase.LoadAssetAtPath<Material>(mat_path);
        RenderSettings.skybox = mater;
    }
}

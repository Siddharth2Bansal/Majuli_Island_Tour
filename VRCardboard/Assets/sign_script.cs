using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class sign_script : MonoBehaviour
{
    // Start is cal int
    public string sceneName;
    public float destroyTime = 15f;
    public GameObject video_test;

    public GameObject[] to_hide;
    public string newClipPath;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void loadVideo()
    {
        foreach(GameObject i in to_hide)
        {
            i.SetActive(false);
        }
        //signfunc();
        video_test.GetComponent<VideoPlayer>().clip = AssetDatabase.LoadAssetAtPath<VideoClip>(newClipPath);

        video_test.SetActive(true);
        int len = newClipPath.Length;
        string t_id = newClipPath.Substring(len - 5, 1);
        Debug.Log(t_id);
        Vector3 cameraRotation;
        switch (t_id)
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
        GameObject.Find("Main Camera").transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        GameObject.Find("CameraOffset").transform.rotation = Quaternion.Euler(cameraRotation);
        string folder_path = "Assets/Images/Transportation/";
        string mat_path = folder_path + "transport_mat" + ".mat";
        Material mater = AssetDatabase.LoadAssetAtPath<Material>(mat_path);
        RenderSettings.skybox = mater;
        Invoke("signfunc", destroyTime);
    }

    public void signfunc()
    {
        SceneManager.LoadScene(sceneName);
    }
}

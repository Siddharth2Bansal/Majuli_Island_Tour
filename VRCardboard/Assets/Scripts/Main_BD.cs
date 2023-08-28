using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Main_BD : MonoBehaviour
{
    // Start is called before the first frame update
    private Dictionary<int, Material> sky;
    //public Material[] sky;

    // change the image of one material rather creating all materials
    private Dictionary<int, int[]> path;
    public string id;
    private int cur, move; // for current video id
    public int starting_vid_id;
    public GameObject child; // FOR TABLET
    public GameObject[] Videos;
    public Vector3[] RotationArray;
    private int vis;
    public InputActionProperty X;
    public InputActionProperty Y;
    public InputActionProperty tab_trigger;

    public void Start()
    {


        // test part next
        path = new Dictionary<int, int[]>();
        sky = new Dictionary<int, Material>();
        string folder_path = "Assets/Images/Images_" + id;
        

        path.Add(6, new int[] {7, 7});
        path.Add(7, new int[] {8, 6});
        path.Add(8, new int[] {9, 7});
        path.Add(9, new int[] {10, 8});
        path.Add(10, new int[] {9, 9});
        for(int i = 0; i < 5; i++)
        {
            string mat_path = folder_path + "/" + id + (i+6).ToString() + ".mat";
            Material mater = AssetDatabase.LoadAssetAtPath<Material>(mat_path);
            sky.Add(i + 6, mater);
        }
        for(int i = 6; i <= 10; i++)
        {
            Videos[i- 6].SetActive(false);
        }
        cur = starting_vid_id;
        RenderSettings.skybox = sky[cur];
        Videos[cur - 6].SetActive(true);
        GameObject.Find("CameraOffset").transform.rotation = Quaternion.Euler(RotationArray[cur - 6]);
        //SetArrow();
    }
    /*
     *  move = 0 means forward
     *  move = 1 means backward
     */
    // Update is called once per frame

    void Update()
    {
        if(X.action.triggered)
        {
            cur = path[cur][0];
            Vector3 cameraRotation = RotationArray[cur - 6];
            Videos[cur - 6].SetActive(true);
            GameObject.Find("CameraOffset").transform.rotation = Quaternion.Euler(cameraRotation);
            for (int i = 6; i <= 10; i++)
            {
                if (i != cur)
                {
                    Videos[i - 6].SetActive(false);

                }
            }

            Debug.Log(cur);
            RenderSettings.skybox = sky[cur];
        }
        else if(Y.action.triggered)
        {
            cur = path[cur][1];
            Vector3 cameraRotation = RotationArray[cur - 6];
            Videos[cur - 6].SetActive(true);
            GameObject.Find("CameraOffset").transform.rotation = Quaternion.Euler(cameraRotation);
            for (int i = 6; i <= 10; i++)
            {
                if (i != cur)
                {
                    Videos[i - 6].SetActive(false);

                }
            }
            RenderSettings.skybox = sky[cur];
        }
        else if (tab_trigger.action.WasPressedThisFrame())
        {
            if (vis == 1)
            {
                child.SetActive(false);
                vis = 0;
            }
            else
            {
                child.SetActive(true);
                vis = 1;
            }
        }


    }

}
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;

public class Main : MonoBehaviour
{
    public InputActionProperty joystick;
    public InputActionProperty tab_trigger;
    public GameObject MiniMap;
    public GameObject overlay_MiniMap;
    public GameObject[] opp_child;
    public GameObject[] hide_child;
    public GameObject video_player;

    public GameObject[] signposts;
    public int where_post;

    private bool isTriggered;
    // Start is called before the first frame update
    private Dictionary<int, Material> sky;
    //public Material[] sky;

    // change the image of one material rather creating all materials
    private Dictionary<int, int[]> path;
    public string id;
    private int cur, angle, move;
    public int starting_img_id;
    public GameObject child;

    private int vis;
    public GameObject[] arrows;
    public GameObject popup;
    public float destroyTime = 5f;
    void SetArrow()
    {

        for (int i = 0; i < arrows.Length; i++) 
        {
            Debug.Log(cur);
            if (path[cur][i] == -1)
            {
                arrows[i].GetComponent<Renderer>().enabled = false;
            }
            else
            {
                arrows[i].GetComponent<Renderer>().enabled = true;
            }
        }


    }

    public void Destroy_Popup()
    {
        Destroy(popup);
    }
    public void Start()
    { 
        isTriggered = false;
        

        // test part next
        path = new Dictionary<int, int[]>();
        sky = new Dictionary<int, Material>();

        string[] lines = File.ReadAllLines("Assets/Path_Matrix/" + id + ".txt");
        foreach (string line in lines)
        {
            string text = line;
            string[] bits = text.Split(',');
            path.Add(int.Parse(bits[0]), new int[] { int.Parse(bits[1]), int.Parse(bits[2]), int.Parse(bits[3]), int.Parse(bits[4]) });
            string folder_path = "Assets/Images/Images_" + id;
            string img_path = folder_path + "/" + id + bits[0] + ".jpg";
            Debug.Log(img_path);
            TextureImporter importer = (TextureImporter)AssetImporter.GetAtPath(img_path);
            string mat_path = folder_path + "/" + id + bits[0] + ".mat";
            if (importer.textureShape != TextureImporterShape.TextureCube)
            {
                importer.textureShape = TextureImporterShape.TextureCube;
                importer.SaveAndReimport();
                Texture texture = AssetDatabase.LoadAssetAtPath<Texture>(img_path);
                Material savedMaterial = new Material(Shader.Find("Skybox/Cubemap")); // Create a copy of the material
                savedMaterial.SetTexture("_Tex", texture);
                AssetDatabase.CreateAsset(savedMaterial, mat_path); // Save the material as an asset
                AssetDatabase.Refresh(); // Refresh the asset database
            }

            Material mater = AssetDatabase.LoadAssetAtPath<Material>(mat_path);
            if (mater == null)
            {
                Texture texture = AssetDatabase.LoadAssetAtPath<Texture>(img_path);
                Material savedMaterial = new Material(Shader.Find("Skybox/Cubemap")); // Create a copy of the material
                savedMaterial.SetTexture("_Tex", texture);
                AssetDatabase.CreateAsset(savedMaterial, mat_path); // Save the material as an asset
                AssetDatabase.Refresh(); // Refresh the asset database
                mater = AssetDatabase.LoadAssetAtPath<Material>(mat_path);
            }
            sky.Add(int.Parse(bits[0]), mater);
        }


        vis = 0;
        /* GameObject video_test = GameObject.Find("360_video_player");
         video_test.SetActive(false);*/

        video_player.SetActive(false);

        cur = starting_img_id;
        RenderSettings.skybox = sky[cur];
        SetArrow();
        Image new_img = MiniMap.transform.Find(id + cur.ToString()).GetComponent<Image>();
        new_img.color = new Color32(255, 0, 0, 255);

        new_img = overlay_MiniMap.transform.Find(id + cur.ToString()).GetComponent<Image>();
        new_img.color = new Color32(255, 0, 0, 255);

        if (cur == where_post)
        {
            foreach (GameObject signpost in signposts)
            {
                signpost.SetActive(true);
            }
        }
        else
        {

            foreach (GameObject signpost in signposts)
            {
                signpost.SetActive(false);
            }
        }


        popup.SetActive(true);
        Invoke("Destroy_Popup", destroyTime);
    }
    /*
     *  move = 0 means forward
     *  move = 1 means right
     *  move = 2 means back
     *  move = 3 means left
     */
    // Update is called once per frame



    void changeCur(int new_cur)
    {
        Image old_img = MiniMap.transform.Find(id + cur.ToString()).GetComponent<Image>();
        old_img.color = new Color32(255, 255, 225, 255);
        old_img = overlay_MiniMap.transform.Find(id + cur.ToString()).GetComponent<Image>();
        old_img.color = new Color32(255, 255, 225, 255);
        cur = new_cur;
        RenderSettings.skybox = sky[cur];
        SetArrow();
        Image new_img = MiniMap.transform.Find(id + cur.ToString()).GetComponent<Image>();
        new_img.color = new Color32(255, 0, 0, 255);
        new_img = overlay_MiniMap.transform.Find(id + cur.ToString()).GetComponent<Image>();
        new_img.color = new Color32(255, 0, 0, 255);
        if (cur == where_post)
        {
            foreach(GameObject signpost in signposts)
            {
                signpost.SetActive(true);
            }
        }
        else
        {

            foreach (GameObject signpost in signposts)
            {
                signpost.SetActive(false);
            }
        }
    }


    void Update()
    {
        angle = (int)gameObject.transform.rotation.eulerAngles.y;
        //Debug.Log(rotation); 
        //Debug.Log(angle);
        /*
         *
                Debug.Log(cur);*/
        var js = joystick.action.ReadValue<Vector2>();
        if (joystick.action.triggered)
            Debug.Log(js);

        float x = Math.Abs(js.x);
        float y = Math.Abs(js.y);

        bool up = false, down = false, right = false, left = false;

        if (x + y < 0.1)
        {
            isTriggered = false;
        }

        if (isTriggered) { return; }

        if (x > y && x > 0.3)
        {
            if (js.x > 0)
            {
                right = true;
                Debug.Log("right");

            }
            else
            {
                left = true;
                Debug.Log("left");

            }
        }
        else if (y > x && y > 0.3)
        {
            if (js.y > 0)
            {
                up = true;
                Debug.Log("up");

            }
            else
            {
                down = true;
                Debug.Log("down");

            }
        }

        if (up || down || left || right)
        {
            isTriggered = true;
        }

        if (up)
        {

            if (angle >= 315 || angle < 45)
                move = 0;
            else if (angle >= 45 && angle < 135)
                move = 1;
            else if (angle >= 135 && angle < 225)
                move = 2;
            else if (angle >= 225 && angle < 315)
                move = 3;
            if (path[cur][move] != -1)
            {
                changeCur(path[cur][move]);
            }
            else
            {
                Debug.Log("Obstacle!");
            }
        }
        else if (right)
        {
            if (angle >= 315 || angle < 45)
                move = 1;
            else if (angle >= 45 && angle < 135)
                move = 2;
            else if (angle >= 135 && angle < 225)
                move = 3;
            else if (angle >= 225 && angle < 315)
                move = 0;
            if (path[cur][move] != -1)
            {
                changeCur(path[cur][move]);
            }
            else
            {
                Debug.Log("Obstacle!");
            }
        }
        else if (down)
        {
            if (angle >= 315 || angle < 45)
                move = 2;
            else if (angle >= 45 && angle < 135)
                move = 3;
            else if (angle >= 135 && angle < 225)
                move = 0;
            else if (angle >= 225 && angle < 315)
                move = 1;
            if (path[cur][move] != -1)
            {
                changeCur(path[cur][move]);
            }
            else
            {
                Debug.Log("Obstacle!");
            }
        }
        else if (left)
        {
            if (angle >= 315 || angle < 45)
                move = 3;
            else if (angle >= 45 && angle < 135)
                move = 0;
            else if (angle >= 135 && angle < 225)
                move = 1;
            else if (angle >= 225 && angle < 315)
                move = 2;
            if (path[cur][move] != -1)
            {
                changeCur(path[cur][move]);
            }
            else
            {
                Debug.Log("Obstacle!");
            }
        }
        else if (tab_trigger.action.WasPressedThisFrame())
        {
            if (vis == 1)
            {
                child.SetActive(false);
                foreach(GameObject i in opp_child)
                {
                    i.SetActive(true);
                }
                vis = 0;
            }
            else
            {
                child.SetActive(true);
                foreach(GameObject i in opp_child)
                {
                    i.SetActive(false);
                }
                foreach(GameObject i in hide_child)
                {
                    i.SetActive(false);
                }
                vis = 1;
            }
        }


    }

}
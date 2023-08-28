using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    //private Dictionary<int, Material> sky;
    public Material [] sky;

    // change the image of one material rather creating all materials
    private Dictionary<int, int[]> path;
    private int[] temp;
    private int cur, angle, move;
    public Texture2D skyTexture;
    public Cubemap texture;
    public GameObject child;
    private int vis;
    public void Start()
    {


        // test part next
        path = new Dictionary<int, int[]>();

        string[] lines = File.ReadAllLines("Assets/K.txt");
        foreach (string line in lines)
        {
            string text = line;
            string[] bits = text.Split(',');
            path.Add(int.Parse(bits[0]), new int[] { int.Parse(bits[1]), int.Parse(bits[2]), int.Parse(bits[3]), int.Parse(bits[4]) });


        }

        vis = 1;






        var textures = Selection.GetFiltered(typeof(Texture), SelectionMode.Assets).Cast<Texture>();
        foreach (var tex in textures)
        {
            //Debug.Log(tex.dimension);
            //  Texture path
            string path = AssetDatabase.GetAssetPath(tex);


            // If the texture dimensions is not "Cube", we convert it
            TextureImporter importer = (TextureImporter)AssetImporter.GetAtPath(path);
            if (tex.dimension != UnityEngine.Rendering.TextureDimension.Cube)
            {
                importer.textureShape = TextureImporterShape.TextureCube;
                importer.SaveAndReimport();



            }
        }


        cur = 1;
        RenderSettings.skybox = sky[cur - 1];
    }
    /*
     *  move = 0 means forward
     *  move = 1 means right
     *  move = 2 means back
     *  move = 3 means left
     */
    // Update is called once per frame
    void Update()
    {
        angle = (int)gameObject.transform.rotation.eulerAngles.y;
        //Debug.Log(rotation); 
        //Debug.Log(angle);
/*
        Debug.Log(cur);*/
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {

            if (angle >= 315 || angle < 45)
                move = 0;
            else if (angle >= 45 && angle < 135)
                move = 1;
            else if(angle >= 135 && angle < 225)
                move = 2;
            else if(angle >= 225 && angle < 315)
                move = 3; 
            if (path[cur][move] != -1)
            {
                cur = path[cur][move];
                Debug.Log(cur);
                RenderSettings.skybox = sky[cur-1];
            }
            else
            {
                Debug.Log("Obstacle!");
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (angle >= 315     || angle < 45)
                move = 1;
            else if (angle >= 45 && angle < 135)
                move = 2;
            else if (angle >= 135 && angle < 225)
                move = 3;
            else if (angle >= 225 && angle < 315)
                move = 0; 
            if (path[cur][move] != -1)
            {
                cur = path[cur][move];
                Debug.Log(cur);
                RenderSettings.skybox = sky[cur-1];
            }
            else
            {
                Debug.Log("Obstacle!");
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
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
                cur = path[cur][move];
                Debug.Log(move);
                RenderSettings.skybox = sky[cur-1];
            }
            else
            {
                Debug.Log("Obstacle!");
            }
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
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
                cur = path[cur][move];
                Debug.Log(move);
                RenderSettings.skybox = sky[cur-1];
            }
            else
            {
                Debug.Log("Obstacle!");
            }
        } else if(Input.GetKeyDown(KeyCode.A))
        {
            if(vis == 1)
            {
                child.GetComponent<Renderer>().enabled = false;
                vis = 0;
            }
            else
            {
                child.GetComponent<Renderer>().enabled = true;
                vis = 1;
            }
         }


    }
}
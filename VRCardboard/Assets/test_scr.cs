using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class test_scr : MonoBehaviour
{
    public string id = "B";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {

            //Debug.Log(tex.dimension);
            //  Texture path

            string m_Path = Application.dataPath;

            //Output the Game data path to the console
            //Debug.Log("dataPath : " + m_Path);
            int len = m_Path.Length;
            foreach (string _file in Directory.GetFiles(m_Path + "/Images/Images_" + id + "/"))
                {
                //Debug.Log(_file);
                    if (_file.Contains("JPG") && !_file.Contains("meta"))
                    {
                    //Debug.Log(_file);
                    // If the texture dimensions is not "Cube", we convert it
                        string t_file = _file.Substring(len - 6);
                    //Debug.Log(t_file); 
                        TextureImporter importer = (TextureImporter)AssetImporter.GetAtPath(t_file);
                    if (importer.textureShape != TextureImporterShape.TextureCube)
                    {
                        importer.textureShape = TextureImporterShape.TextureCube;
                        importer.SaveAndReimport();
                    }
                    Texture texture = AssetDatabase.LoadAssetAtPath<Texture>(t_file);
                    int l = t_file.Length;
                    string mat_path = t_file.Substring(0,l-4) + ".mat"; // Set the save path
                    Material savedMaterial = new Material(Shader.Find("Skybox/Cubemap")); // Create a copy of the material
                    savedMaterial.SetTexture("_Tex", texture);
                    AssetDatabase.CreateAsset(savedMaterial, mat_path); // Save the material as an asset
                    AssetDatabase.Refresh(); // Refresh the asset database
                    Debug.Log("Material saved as: " + mat_path); // Log the save path
                        
                    }
                }
            
        }
    }
}

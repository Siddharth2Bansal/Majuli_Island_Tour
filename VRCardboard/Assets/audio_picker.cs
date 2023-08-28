using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;
using System.Text.RegularExpressions;

public class audio_picker : MonoBehaviour
{
    public string id = "K";
    private Dictionary<int, int> dict;
    private string prev = "";
    private int audioClip = 0; 

    // Start is called before the first frame update
    void Start()
    {
        dict = new Dictionary<int, int>();
        string[] lines = File.ReadAllLines("Assets/Audio/Mapping/" + id + ".txt");
        foreach (string line in lines)
        {
            string text = line;
            string[] bits = text.Split(',');
            dict.Add(int.Parse(bits[0]), int.Parse(bits[1]));
        }

    }

    // Update is called once per frame
    void Update()
    {
        string curr = RenderSettings.skybox.name;


        if (prev != "" && prev != curr)
        {
            string resultString = Regex.Match(curr, @"\d+").Value;
            int a = Int32.Parse(resultString);
            Debug.Log(a);
            int new_audio = dict.TryGetValue(a, out var result) ? result : -1;
            if ((new_audio != -1 && new_audio != audioClip) || audioClip < 1)
            {
                AudioSource audio = gameObject.GetComponent<AudioSource>();
                Debug.Log(audio.clip);

                /*    audio.Play();
                    yield return new WaitForSeconds(audio.clip.length);*/

                string folder_path = "Assets/Audio";
                string a_path = folder_path + "/" + new_audio + ".mp3";
                Debug.Log(a_path);

                AudioClip otherClip = AssetDatabase.LoadAssetAtPath<AudioClip>(a_path);
                audio.clip = otherClip;
                audio.Play();
                audioClip = new_audio;
            }

        }

        prev = curr;
    }
}

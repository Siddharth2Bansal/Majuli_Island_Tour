using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
public class start360Video_script : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void button_func()
    {
        SceneManager.LoadScene("K_Scene");
    }
    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.frameCount > 0)
        {
            float i = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
            if (i > 0.95)
            {
                SceneManager.LoadScene("K_Scene");
            }
        }
    }
}

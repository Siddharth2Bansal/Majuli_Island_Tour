using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class exit_app : MonoBehaviour
{
    public Button button1;

    // Start is called before the first frame update
    void Start()
    {
        button1.onClick.AddListener(QuitGame);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #endif
            Application.Quit();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class tele1 : MonoBehaviour
{
    public Button button1;

    public new string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        button1.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        Debug.Log("Button Clicked!");
        SceneManager.LoadScene(sceneName);
    }

}

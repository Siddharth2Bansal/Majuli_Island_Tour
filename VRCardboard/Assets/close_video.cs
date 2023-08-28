using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class close_video : MonoBehaviour
{
    public Button b;
    public Button play_b;
    public Sprite startS;


    // Start is called before the first frame update
    void Start()
    {
        b.onClick.AddListener(onButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onButtonClick()
    {
            play_b.image.sprite = startS;
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Sprites;
using UnityEngine.UI;

public class startstop : MonoBehaviour
{
    private VideoPlayer player;
    public Button b;
    public Sprite startS;
    public Sprite stopS;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<VideoPlayer>();
        b.onClick.AddListener(ChangeState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeState()
    {
        if(player.isPlaying == false)
        {
            player.Play();
            b.image.sprite = stopS;
        }
        else
        {
            player.Pause();
            b.image.sprite = startS;
        }
    }

}

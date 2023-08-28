using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class close_360 : MonoBehaviour
{
    public cur_skybox sky;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(close_video);
    }

    // Update is called once per frame
    void close_video()
    {
        GameObject.Find("CameraOffset").transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        RenderSettings.skybox = sky.value;

    }
}

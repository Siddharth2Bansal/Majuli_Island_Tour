using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class info_script : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ePanel;
    public GameObject aPanel;
    void Update()
    {
        open_panel();
    }

    public void open_panel()
    {
        aPanel.SetActive(false);
        ePanel.SetActive(true);
    }

/*    // Update is called once per frame
    void Update()
    {
        
    }*/
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;


public class startscene_MC : MonoBehaviour
{
    public InputActionProperty tab_trigger;
    public GameObject child;

    private int vis;
    // Start is called before the first frame update
    void Start()
    {
        vis = 0;
        child.SetActive(false);
        tab_trigger.action.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (tab_trigger.action.WasPressedThisFrame())
        {
            if (vis == 1)
            {
                child.SetActive(false);
                vis = 0;
            }
            else
            {
                child.SetActive(true);
                vis = 1;
            }
        }

    }
}

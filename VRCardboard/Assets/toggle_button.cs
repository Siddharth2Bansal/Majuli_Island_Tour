using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class toggle_button : MonoBehaviour
{
    public Button button1;


    public GameObject[] show_child;
    public GameObject[] hide_child;
    public InputActionProperty[] dis_action;
    public InputActionProperty[] en_action;

    void Start()
    {
        button1.onClick.AddListener(OnButtonClick);
        
    }
    public void OnButtonClick()
    {

        foreach (GameObject child in show_child)
        {
            child.SetActive(true);
        }
        foreach (GameObject child in hide_child)
        {
            child.SetActive(false);
        }
        foreach (InputActionProperty act in dis_action)
        {
            act.action.Disable();
        }
        foreach (InputActionProperty act in en_action)
        {
            act.action.Enable();
        }

    }
}

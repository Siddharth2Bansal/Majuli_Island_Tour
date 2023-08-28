using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    //public Vector3 cameraOffset = new Vector3(0f, 1.5f, -4f); // default camera offset
    public Vector3 cameraRotation = new Vector3(15f, 0f, 0f); // default camera rotation

    void Start()
    {
        // Get the position and rotation of the player GameObject
        // Vector3 playerPosition = GameObject.Find("Player").transform.position;
        GameObject.Find("CameraOffset").transform.rotation = Quaternion.Euler(cameraRotation);
    }
}

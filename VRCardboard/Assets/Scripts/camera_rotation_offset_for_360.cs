using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "360VideoOffset")]
public class camera_rotation_offset_for_360 : MonoBehaviour
{
    // Start is called before the first frame update
    public static Dictionary<string, Vector3> offsets ;

    private void Start()
    {
        offsets = new Dictionary<string, Vector3>();
        offsets["hello"] = new Vector3(0, 0, 0);
    }
}

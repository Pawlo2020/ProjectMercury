using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cam;
    public Transform ship;

    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update()
    {
        cam.position = new Vector3(ship.position.x, ship.position.y + 3, cam.position.z);
    }
}

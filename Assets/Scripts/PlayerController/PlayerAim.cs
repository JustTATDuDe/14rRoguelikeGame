using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    // Define the maine camera on scene
    Camera cam;
    [SerializeField] private GameInput gameInput;

    void Awake()
    {
        cam = Camera.main;
    }
    void Update()
    {
        Vector2 inputMousePos = gameInput.GetMousePosition();

        // Create a ray from the camera through the mouse position on the screen
        Ray ray = cam.ScreenPointToRay(inputMousePos);

        // Define a virtual ground plane at y=0 to project the mouse ray onto the world
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        // Check if the ray intersects the ground plane  
        if (groundPlane.Raycast(ray, out float enter))
        {
            // Get the exact point in the world space where the ray hits the plane
            Vector3 hitPoint = ray.GetPoint(enter);

            Vector3 lookDir = (hitPoint - transform.position).normalized;
            lookDir.y = 0;

            // Only rotate if the diractione vector is valid (not near zero) 
            if (lookDir.magnitude > 0.001f)
            {
                Quaternion target = Quaternion.LookRotation(lookDir);
                float rotateSpeed = 10f;
                transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * rotateSpeed).normalized;

                Debug.DrawLine(transform.position, hitPoint, Color.red);
            }
        }
    }
}

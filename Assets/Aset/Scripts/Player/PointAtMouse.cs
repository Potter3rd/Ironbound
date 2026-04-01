using UnityEngine;
using UnityEngine.InputSystem;

public class PointAtMouse : MonoBehaviour
{
    
    
    void Update()
    {
        // Get the mouse position in world space
        Vector3 mosPos = (Vector3)Mouse.current.position.ReadValue();

        // Gets the z position
        mosPos.z = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);

        //gerts the world coordinates of the mouse position
        mosPos = Camera.main.ScreenToWorldPoint(mosPos);

        // Calculate the direction from the object to the mouse position
        Vector2 direction = (mosPos - transform.position);

        // Calculate the angle in degrees and rotate the object to point at the mouse position
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //roates the sprite to point at the mouse position - 90 adjusting the sprite to the right orientation
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
    }
}
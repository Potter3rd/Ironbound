using UnityEngine;
using UnityEngine.SceneManagement;

//code for the player to follow the player and stay within the bounds of the level
public class CameraFCluade : MonoBehaviour
{
    public Transform player;

    //camera bounds in the map
    public PolygonCollider2D bounds;

    public float followSpeed = 5f;

    //late update so that every other actions take prioty to the camera movement
    void LateUpdate()
    {
        //so there no errors thrown if the player or bounds are not set
        if (player == null || bounds == null)
        {
            return;
        }

        // positions of the player and camera, but the camera's
        Vector3 targetPos = new Vector3(player.position.x, player.position.y, transform.position.z);

        //makes it so that the camera movement is smooth and not jittery
        Vector3 smoothed = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);

        //if the camera is outside the bounds, it will be moved back inside the bounds
        if (!bounds.OverlapPoint(smoothed))
        {
            Vector2 closest = bounds.ClosestPoint(smoothed);
            smoothed = new Vector3(closest.x, closest.y, transform.position.z);
        }

        transform.position = smoothed;
    }
}
using UnityEngine;

public class CameraFCluade : MonoBehaviour
{
    public Transform player;
    public PolygonCollider2D bounds;
    public float followSpeed = 5f; // Adjust in Inspector for smoothness

    void LateUpdate()
    {
        if (player == null || bounds == null) return;

        // Follow the player
        Vector3 targetPos = new Vector3(player.position.x, player.position.y, transform.position.z);

        // Smooth follow
        Vector3 smoothed = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);

        // Clamp to bounds
        if (!bounds.OverlapPoint(smoothed))
        {
            Vector2 closest = bounds.ClosestPoint(smoothed);
            smoothed = new Vector3(closest.x, closest.y, transform.position.z);
        }

        transform.position = smoothed;
    }
}
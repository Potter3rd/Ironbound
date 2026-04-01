using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 10.0f;
    public Transform target;
    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, -10f);

        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}

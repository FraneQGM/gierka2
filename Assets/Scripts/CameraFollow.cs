using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;
    private bool justStarted = true;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPosition = new Vector3(
            target.position.x,
            target.position.y,
            transform.position.z
        );

        // 🔴 pierwszy frame po załadowaniu sceny → teleport
        if (justStarted)
        {
            transform.position = targetPosition;
            justStarted = false;
            return;
        }

        // 🔵 normalny smooth
        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPosition,
            ref velocity,
            smoothTime
        );
    }
}
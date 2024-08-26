using UnityEngine;

public class CameraBoundaries : MonoBehaviour
{
    public Transform target; // The character or object to follow
    public Vector3 offset; // Offset from the target position
    public BoxCollider2D boundary; // Box Collider for boundary

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 clampedPosition = ClampPositionToBounds(desiredPosition);
        transform.position = new Vector3(clampedPosition.x, clampedPosition.y, transform.position.z);
    }

    private Vector3 ClampPositionToBounds(Vector3 position)
    {
        Vector3 min = boundary.bounds.min;
        Vector3 max = boundary.bounds.max;

        float clampedX = Mathf.Clamp(position.x, min.x, max.x);
        float clampedY = Mathf.Clamp(position.y, min.y, max.y);

        return new Vector3(clampedX, clampedY, position.z);
    }
}

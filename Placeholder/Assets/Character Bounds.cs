using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBoundary : MonoBehaviour
{
    public Collider2D boundaryCollider; // Assign the boundary collider in the Inspector

    private void Update()
    {
        Vector3 position = transform.position;

        if (boundaryCollider.bounds.Contains(position))
        {
            // Character is within bounds
        }
        else
        {
            // Character is out of bounds, handle accordingly
            transform.position = new Vector3(
                Mathf.Clamp(position.x, boundaryCollider.bounds.min.x, boundaryCollider.bounds.max.x),
                Mathf.Clamp(position.y, boundaryCollider.bounds.min.y, boundaryCollider.bounds.max.y),
                position.z
            );
        }
    }
}

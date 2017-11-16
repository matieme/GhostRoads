using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float distance = 6f;
    public float height = 5.0f;

    public float heightDamping = 1.0f;

    float wantedHeight;
    float currentHeight;

    float wantedDistance;
    float currentDistance;

    void LateUpdate()
    {
        wantedHeight = target.position.y + height;

        currentHeight = transform.position.y;
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        wantedDistance = target.position.z - distance;

        currentDistance = transform.position.z;
        currentDistance = Mathf.Lerp(currentDistance, wantedDistance, heightDamping * Time.deltaTime);

        transform.position = target.position;

        transform.position = new Vector3(-3.14f, currentHeight, currentDistance);
    }
}
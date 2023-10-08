using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 3f, -4f);
    public float forwardOffset = -2;

    public float smoothSpeed = 5f;
private void LateUpdate() {
    if (target == null){
        return;
    }
    Vector3 desiredPosition = target.position + offset + target.forward * forwardOffset;

    Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

    transform.position = smoothedPosition;

    transform.LookAt(target);
}
}

using UnityEngine;

public class SmoothFollowCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 10f;
    public float height = 5f;
    public float rotationDamping = 3f;
    public float heightDamping = 2f;
    public float zoomSpeed = 10f;
    public float zoomDamping = 5f;
    public float minDistance = 5f;
    public float maxDistance = 20f;

    void FixedUpdate()
    {
        float wantedRotationAngle = target.eulerAngles.y;
        float wantedHeight = target.position.y + height;
        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // Smooth zoom with the mouse wheel
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        float targetDistance = distance - scrollInput * zoomSpeed;
        targetDistance = Mathf.Clamp(targetDistance, minDistance, maxDistance);
        distance = Mathf.Lerp(distance, targetDistance, zoomDamping * Time.deltaTime);

        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        transform.LookAt(target);
    }
}
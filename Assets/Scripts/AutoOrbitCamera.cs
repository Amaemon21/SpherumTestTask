using UnityEngine;

public class AutoOrbitCamera : MonoBehaviour
{
    [SerializeField] private Transform target;           
    [SerializeField] private float rotationSpeed = 2f;    

    private void Update()
    {
        float horizontalRotation = Time.deltaTime * rotationSpeed;

        transform.RotateAround(target.position, Vector3.up, horizontalRotation);
    }
}
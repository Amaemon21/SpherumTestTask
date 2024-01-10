using UnityEngine;

public class RotateTowardsTarget : MonoCache
{
    [SerializeField] private CubeController _targetObject;
    [SerializeField] private float _rotationSpeed = 5f;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;

        if (_targetObject == null)
            Debug.LogError("Целевой объект не установлен!");
    }

    public override void OnTick()
    {
        Vector3 directionToTarget = _targetObject.transform.position - _transform.position;

        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);

        _transform.rotation = Quaternion.Slerp(_transform.rotation, rotationToTarget, _rotationSpeed * Time.deltaTime);
    }
}
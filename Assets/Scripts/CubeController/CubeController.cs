using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] protected float MoveSpeed = 5f;

    private void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
    }
}
using UnityEngine;

public class WASDCubeController : CubeController
{
    [SerializeField] private ArrowsCubeController _ArrowsCubeController;
    [SerializeField] private GameObject _particleSystem;

    protected override void Move()
    {
        float horizontal = Input.GetAxis("HorizontalAD");
        float vertical = Input.GetAxis("VerticalWS");

        Vector3 movement = new Vector3(horizontal, 0f, vertical) * MoveSpeed * Time.deltaTime;

        transform.Translate(movement);
    }
}
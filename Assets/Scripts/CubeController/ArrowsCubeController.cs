using UnityEngine;

public class ArrowsCubeController : CubeController
{
    [SerializeField] private WASDCubeController _WASDCubeController;
    [SerializeField] private GameObject _particleSystem;

    protected override void Move()
    {
        float horizontal = Input.GetAxis("HorizontalArrows");
        float vertical = Input.GetAxis("VerticalArrows");

        Vector3 movement = new Vector3(horizontal, 0f, vertical) * MoveSpeed * Time.deltaTime;

        transform.Translate(movement);
    }
}
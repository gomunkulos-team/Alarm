using UnityEngine;

public class Mover : MonoBehaviour
{
    private float _moveSpeed = 3;

    private void Update()
    {
        Vector3 inputVector = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W))
            inputVector.z = +1;

        if (Input.GetKey(KeyCode.S))
            inputVector.z = -1;

        if (Input.GetKey(KeyCode.A))
            inputVector.x = -1;

        if (Input.GetKey(KeyCode.D))
            inputVector.x = +1;

        inputVector = inputVector.normalized;

        transform.position += inputVector * _moveSpeed * Time.deltaTime;
    }
}

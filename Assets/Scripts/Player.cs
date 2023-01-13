using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody;

    [SerializeField] private float _accelerationForce;
    [SerializeField] private float _jumpForce;

    [SerializeField] private float _maxSpeed;

    [SerializeField]private bool _onGround = false;

    private void Update()
    {
         if(Input.GetKey(KeyCode.D))
            Move(_accelerationForce);

        if(Input.GetKey(KeyCode.A))
            Move(-_accelerationForce);

        if(_onGround && Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void Move(float accelerationForce)
    {
        if (Mathf.Abs(_rigidBody.velocity.x) < _maxSpeed)
            _rigidBody.AddForce(Vector2.right * accelerationForce);
    }

    private void Jump()
    {
        _rigidBody.AddForce(Vector2.up * _jumpForce);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Ground"))
            _onGround = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Ground"))
            _onGround = false;
    }
}

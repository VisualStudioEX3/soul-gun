using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rigidBody;
    Vector2 _initialGravity;
    float _playerGravity;
    float _targetGravity;

    [SerializeField]
    float _horizontalForce = 1f;

    private void Awake()
    {
        this._rigidBody = GetComponent<Rigidbody2D>();
        this._initialGravity = Physics2D.gravity;
    }

    private void Update()
    {
        this._rigidBody.position += ((Vector2.right * Input.GetAxis("Horizontal")) * this._horizontalForce) * Time.deltaTime;

        if (Input.GetButtonDown("Fire1"))
        {
            Physics2D.gravity *= -1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EX3.Framework;
using EX3.Framework.Components;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rigidBody;
    SpriteRenderer _sprite;
    ObjectPool _shootsPool;
    Timer _timer;

    float _horizontalVelocity;

    [SerializeField]
    float _horizontalForce = 1f;
    [Space]
    [Header("Weapon settings:")]
    [SerializeField]
    float _shootCandence = 0.5f;
    [SerializeField]
    float _shootSpeed = 1f;
    [SerializeField]
    int _shootDamage = 1;
    [SerializeField]
    int _maxShoots = 3;
    [SerializeField]
    float _shootLifeTime = 1f;
    [SerializeField]
    Transform _sourceShoot;

    private void Awake()
    {
        this._rigidBody = GetComponent<Rigidbody2D>();
        this._sprite = GetComponent<SpriteRenderer>();
        this._shootsPool = GetComponentInChildren<ObjectPool>();

        this._timer = new Timer();

        this._shootsPool.MaxInstances = this._maxShoots;
    }

    private void Update()
    {
        this.UpdateMovement();
        this.CheckInputShoot();
    }

    private void FixedUpdate()
    {
        Vector2 currentVelocity = this._rigidBody.velocity;
        currentVelocity.x = this._horizontalVelocity;
        this._rigidBody.velocity = currentVelocity;
    }

    void UpdateMovement()
    {
        if (GameManager.Instance.Input.MoveLeft.IsPressed)
        {
            this._horizontalVelocity = -this._horizontalForce;
            this._sprite.flipX = true;
        }
        else if (GameManager.Instance.Input.MoveRight.IsPressed)
        {
            this._horizontalVelocity = this._horizontalForce;
            this._sprite.flipX = false;
        }
        else
        {
            this._horizontalVelocity = 0f;
        }
    }

    void CheckInputShoot()
    {
        if (this._timer.Value >= this._shootCandence && GameManager.Instance.Input.Shoot.IsDown)
        {
            this._timer.Reset();
            Physics2D.gravity *= -1;
            this._sprite.flipY = !this._sprite.flipY;

            var shoot = this._shootsPool.GetNewInstance(this._sourceShoot.position, Quaternion.identity, this._shootLifeTime);
            shoot.GetComponent<Rigidbody2D>().AddForce(this._sourceShoot.right * this._shootSpeed, ForceMode2D.Impulse);
        }
    }
}

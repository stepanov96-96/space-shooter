using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//implementation of player firing
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public float _speed = 300f;
    float _lifeTime = 3f;
    public new Rigidbody2D rigidbody;
    

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
    }


    // calculating the direction of the bullet and its time of destruction
    public void DirectionBullet(Vector2 direction)
    {
        this.rigidbody.AddForce(direction * _speed);

        
        Destroy(this.gameObject, this._lifeTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // the bullet is destroyed on contact with anything
        Destroy(this.gameObject);
    }
}

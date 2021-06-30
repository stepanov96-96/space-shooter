using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//implementation of asteroid motion
[RequireComponent(typeof(Rigidbody2D))]
public class Asteroid : MonoBehaviour
{
    public Sprite[] _spritesAsteroids;
          
    float _movementSpeed = 0.6f;

    float _Lifetime = 10.0f;

    public SpriteRenderer _spriteRenderer;

    public new Rigidbody2D rigidbody;

    Vector2 _direction;

    private void Awake()
    {
        this._spriteRenderer = GetComponent<SpriteRenderer>();
        this.rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
        this._spriteRenderer.sprite = _spritesAsteroids[Random.Range(0, _spritesAsteroids.Length)];
        Destroy(this.gameObject, this._Lifetime);
        _direction = new Vector2(Random.Range(0,3), Random.Range(0, 10));
    }

    public void FixedUpdate()
    {
        transform.Translate(_movementSpeed * _direction * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            RestartPlayer._score+=100;
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            if (RestartPlayer._score!=0)
            {
                RestartPlayer._score -= 50;
            }            
            Destroy(this.gameObject);
        }

    }

    
}

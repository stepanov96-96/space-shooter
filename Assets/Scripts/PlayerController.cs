using System.Collections;
using System.Collections.Generic;
using UnityEngine;

   
//shooting and player movement
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    
    public float _speedPlayer = 1.0f;        
    public float _speedRotation = 0.1f;
    public Rigidbody2D rigidbody;
    bool _movement = false;
    float _direction = 0.0f;
    public Bullet bulletPrefab;
    public GameObject player;

    

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
        
    }
    


    public void Update()
    {
        _movement = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _direction = 1.0f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _direction = -1.0f;
        }
        else
        {
            _direction = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Shoot();
        }
    }

    public void FixedUpdate()
    {
       
        if (_movement)
        {
            this.rigidbody.AddForce(transform.up * _speedPlayer);
        }

        if (_direction != 0.0f)
        {
            this.rigidbody.AddTorque(_speedRotation * _direction);
        }
               
    }

    public void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.DirectionBullet(transform.up);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            StartCoroutine(PlayerSpaw());
            RestartPlayer._playerDead--;    
            Destroy(this.gameObject);
            
        }
    }

    IEnumerator PlayerSpaw()
    {
        
        if (RestartPlayer._playerDead>=0)
        {
            Instantiate(player, new Vector3(0f, 0f, 0f), Quaternion.identity);
        }
        yield return new WaitForSeconds(1f);

    }
}

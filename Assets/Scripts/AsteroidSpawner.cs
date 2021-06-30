using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//random asteroid spawner
public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid _asteroidPrefab;

    public float trajectoryVariance = 15.0f;

    void Start()
    {
        StartCoroutine(Spaw());
    }

   IEnumerator Spaw()
   {     

        for (int i = 0; i < 10; i++)
        {
            Asteroid _asteroid = Instantiate(_asteroidPrefab, new Vector3(Random.Range(10,-10), Random.Range(-10, -6), 0f), Quaternion.identity);            
            yield return new WaitForSeconds(1f);
        }

        Start();

   }


}

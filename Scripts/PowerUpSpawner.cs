using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject biggerPowerUpSize;
    public GameObject smallerPowerUpSize;
    public GameObject hidingBallPowerUp;

    private Vector3 boxSize;
    private Vector2 prefabPosition;


    private int randomNumber;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        randomNumber = Random.Range(0,3);
        if (randomNumber == 0)
        {
           float posX = Random.Range(-boxSize.x, boxSize.x);
            float posY = Random.Range(-boxSize.y, boxSize.y);
            prefabPosition = new Vector2(posX, posY);
            Instantiate(biggerPowerUpSize, prefabPosition, Quaternion.identity);
        }
        else if(randomNumber == 1)
        {
            float posX = Random.Range(-boxSize.x, boxSize.x);
            float posY = Random.Range(-boxSize.y, boxSize.y);
            prefabPosition = new Vector2(posX, posY);
            Instantiate(smallerPowerUpSize, prefabPosition, Quaternion.identity);
        }
        else if(randomNumber == 2)
        {
            float posX = Random.Range(-boxSize.x, boxSize.x);
            float posY = Random.Range(-boxSize.y, boxSize.y);
            prefabPosition = new Vector2(posX, posY);
            Instantiate(hidingBallPowerUp, prefabPosition, Quaternion.identity);
        }
    }
    void Awake()
    {
        boxSize = GetComponent<BoxCollider2D>().bounds.extents;
        
    }

}

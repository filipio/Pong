using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizePowerUp : MonoBehaviour
{
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("ball"))
        {
            if (gameObject.CompareTag("BiggerSize"))
            {
                collision.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                
            }
            else if(gameObject.CompareTag("SmallerSize"))
            {
                collision.gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
            Destroy(this.gameObject);
        }
    }
}

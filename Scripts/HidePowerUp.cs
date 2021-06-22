using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePowerUp : MonoBehaviour
{
    private BlueSliderController blueSlider;

    public void Awake()
    {
        blueSlider = GameObject.FindGameObjectWithTag("BlueSlider").GetComponent<BlueSliderController>();    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("ball"))
        {
            blueSlider.enabled = true;
            Destroy(gameObject);
        }
    }
}

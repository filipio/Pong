using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PongPowerUpMode : MonoBehaviour
{//terribly named script

    public float timeOfBiggerPaddle = 5f;
    public SliderController sliderYellowController;
    public SliderController sliderRedController;

    private Vector3 additionalSize = new Vector3(0f, 0.1f, 0f);
    private Vector3 substractedSize = new Vector3(0f, 0.05f, 0f);
    public void BiggerPaddleSizeUp()
    {
        transform.localScale += additionalSize;

    }
    public void BiggerPaddleSizeDown()
    {
        transform.localScale -= additionalSize;
    }

    public void SmallerPaddleSizeUp()
    {
        transform.localScale += substractedSize;
    }


    public void SmallerPaddleSizeDown()
    {
        transform.localScale -= substractedSize;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ball") && collision.gameObject.GetComponent<Renderer>().material.color != Color.white)
        {
            Renderer ballRenderer = collision.gameObject.GetComponent<Renderer>();
            Color ballColor = ballRenderer.material.color;

            if(ballColor == Color.yellow)
            {
                ballRenderer.material.color = Color.white;
                sliderYellowController.enabled = false;
                sliderYellowController.enabled = true;

                
            }
            else if(ballColor == Color.red)
            {
                ballRenderer.material.color = Color.white;
                sliderRedController.enabled = false;
                sliderRedController.enabled = true;

            }
        }
    }

}

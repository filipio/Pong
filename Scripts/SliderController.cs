using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderController : MonoBehaviour
{
    public Slider slider;
    public GameObject paddleOwner;
   
    private float maximalValue = 100f;
    private Image sliderImage;
    private enum SliderType {sizeUp, sizeDown};
    private SliderType sliderType;  

    [SerializeField] private float speedChangeValue = 0.1f;
    private void OnEnable()
    {if(sliderType == SliderType.sizeUp)
        {
            paddleOwner.GetComponent<PongPowerUpMode>().BiggerPaddleSizeUp();
        }
    else if(sliderType == SliderType.sizeDown)
        {
            paddleOwner.GetComponent<PongPowerUpMode>().SmallerPaddleSizeDown();
        }
        slider.value = maximalValue;
        sliderImage.enabled = true;
    }
    private void OnDisable()
    {

        if (sliderType == SliderType.sizeUp)
        {
            paddleOwner.GetComponent<PongPowerUpMode>().BiggerPaddleSizeDown();
        }
        else if (sliderType == SliderType.sizeDown)
        {
            paddleOwner.GetComponent<PongPowerUpMode>().SmallerPaddleSizeUp();
        }
        slider.value = maximalValue;
        sliderImage.enabled = false;
    }


    private void Awake()
    {   if(gameObject.CompareTag("YellowSlider"))
        {
            sliderType = SliderType.sizeUp;
        }
        else if(gameObject.CompareTag("RedSlider"))
        {
            sliderType = SliderType.sizeDown;
        }
        sliderImage = GetComponentInChildren<Image>();
        sliderImage.enabled = false;
    }

    void Update()
    {if(slider.value>0)
        {
            slider.value -= (speedChangeValue * Time.deltaTime);
        }
        else if(slider.value == 0)
        {//that's definitely not correct way to do this...
            GetComponent<SliderController>().enabled = false;
        }
    }
}

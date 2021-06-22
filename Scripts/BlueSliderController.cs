using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BlueSliderController : MonoBehaviour
{
    public GameObject ball;
    public Slider slider;

    [SerializeField] private float speedChangeValue = 10f;
    [SerializeField] private float hiddenTime = 2f;
    private Image sliderImage;
    private float maximumValue = 100f;
    private bool hidingWasCalled = false;
    private Renderer ballRenderer;
    private WaitForSeconds wait;
    private void OnEnable()
    {
        slider.value = maximumValue;
        sliderImage.enabled = true;
    }



    private void Awake()
    {

        wait = new WaitForSeconds(hiddenTime);
        sliderImage = GetComponentInChildren<Image>();
        sliderImage.enabled = false;
        ballRenderer = ball.GetComponent<Renderer>();
    }

    private void OnDisable()
    {
        slider.value = 0f;
        sliderImage.enabled = false;
        ballRenderer.enabled = true;
        hidingWasCalled = false;

    }

    IEnumerator HideBall()
    {//won't it affect balls bouncing physics?
        ballRenderer.enabled = false;
        yield return wait;
       
    }

    IEnumerator ShowBall()
    {
        ballRenderer.enabled = true;
        yield return wait;
        
    }

    IEnumerator BallHidingAndShowing()
    {
        while(slider.value >0f)
        {
            yield return StartCoroutine(HideBall());
            yield return StartCoroutine(ShowBall());
        }
    }

    private void Update()
    {
        if(slider.value >0f)
        {
            slider.value -= (speedChangeValue * Time.deltaTime);
            if(!hidingWasCalled)
            {
                hidingWasCalled = true;
                StartCoroutine(BallHidingAndShowing());

            }
        }
       else if (slider.value == 0f)
        {
            GetComponent<BlueSliderController>().enabled = false;
        }
    }
}

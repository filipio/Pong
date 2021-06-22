using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [Header("Ball")]
    public GameObject ball;

    [Header("Player1")]
    public GameObject playerOne;
    public GameObject playerOneGoal;

    [Header("Player2")]
    public GameObject playerTwo;
    public GameObject playerTwoGoal;

    [Header("Score")]
    public GameObject scorePlayerOne;
    public GameObject scorePlayerTwo;

    [Header("Sliders")]
    public SliderController sliderYellowPlayerOne;
    public SliderController sliderYellowPlayerTwo;
    public SliderController sliderRedPlayerOne;
    public SliderController sliderRedPlayerTwo;
    public BlueSliderController blueSlider;

    public bool someoneScored = false;
    private int pointsPlayerOne = 0;
    private int pointsPlayerTwo = 0;
    // Update is called once per frame

       public void PlayerOneScored()
    {
        pointsPlayerOne++;
        scorePlayerOne.GetComponent<TextMeshProUGUI>().text = pointsPlayerOne.ToString();
        someoneScored = true;
        Reset();
        
    }
        public void PlayerTwoScored()
    {
        pointsPlayerTwo++;
        scorePlayerTwo.GetComponent<TextMeshProUGUI>().text = pointsPlayerTwo.ToString();
        someoneScored = true;
        Reset();
        
    }
    private void Reset()
    {
        playerOne.GetComponent<Movement>().Reset();
        playerTwo.GetComponent<Movement>().Reset();
        ball.GetComponent<Pong>().Reset();
        sliderYellowPlayerOne.enabled = false;
        sliderYellowPlayerTwo.enabled = false;
        sliderRedPlayerOne.enabled = false;
        sliderRedPlayerTwo.enabled = false;
        blueSlider.enabled = false;
    }
}

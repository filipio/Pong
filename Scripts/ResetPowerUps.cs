using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPowerUps : MonoBehaviour
{
    private GameObject GameMan;
    private GameManager gameManagerScript;

    private void Awake()
    {
        GameMan = GameObject.Find("GameManager");
        gameManagerScript = GameMan.GetComponent<GameManager>();
    }

    IEnumerator Reset()
    {

        GetComponent<Renderer>().enabled = false;
        //destroying time needs to be longer in order to let variable 'someonescored' change
        Destroy(gameObject, 0.3f);
        //waiting becuase all reset fuctions need to be launched
        yield return new WaitForSeconds(0.2f);
        gameManagerScript.someoneScored = false;
    }



    private void Update()
    {
        if (gameManagerScript.someoneScored)
        {
            StartCoroutine(Reset());
        }
    }
}

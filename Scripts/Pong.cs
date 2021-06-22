using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong : MonoBehaviour
{
    public AudioSource paddleHitSound;
    public AudioSource powerUpSound;
    public AudioClip wallHitClip;
    public AudioClip pointClip;
    public AudioClip playerHitClip;
    public GameObject playerOne;
    public GameObject playerTwo;
    public Rigidbody2D rb;
    public BlueSliderController blueSlider;

    private Renderer ballRenderer;
    private float startingSpeedOfPong = 5f;
    private Vector3 startPosition;
    private float maximalAngle = 70f;
    private bool velocityChanged = false;
    private bool hitFromTheBack = false;
    [SerializeField] private float speedOfPongUpgrade = 0f;
    [SerializeField] private float actualSpeedOfPong = 5f;

    float CalculateAngleToRadian(float angle)
    {
        return (angle / 180) * Mathf.PI;
    }
    void Start()
    {
        ballRenderer = GetComponent<Renderer>();
        startPosition = transform.position;
        Launch();

        
    }
    void Launch()
    {
        float randomX;
        float randomY = Random.Range(-1f, 1f);
        int randomInt = Random.Range(0, 2);
        if(randomInt == 1)
        {
            randomX = 1f;
        }
        else
        {
            randomX = -1f;
        }
        rb.velocity = new Vector2(randomX * startingSpeedOfPong, randomY * startingSpeedOfPong);
    }
   public void Reset()
    {
        actualSpeedOfPong = startingSpeedOfPong;
        rb.velocity = Vector3.zero;
        transform.position = startPosition;
        GetComponent<Renderer>().material.color = Color.white;
        Launch();
    }
    IEnumerator ResetVelocityChange()
    {
        yield return new WaitForSeconds(0.2f);
        velocityChanged = false;
    }

   private void OnCollisionEnter2D(Collision2D collision)
    {

       
        if (collision.gameObject.CompareTag("Player") && !velocityChanged && !hitFromTheBack)
        {
            paddleHitSound.clip = playerHitClip;
            paddleHitSound.Play();
            BoxCollider2D boxCollid = collision.gameObject.GetComponent<BoxCollider2D>();
            Vector2 center = Vector2.zero;
            
            if(collision.gameObject.name == "PlayerOne")
            {
                center = boxCollid.bounds.center + new Vector3(boxCollid.bounds.extents.x, 0, 0);
                
            }
            else
            {
                center = boxCollid.bounds.center + new Vector3(-boxCollid.bounds.extents.x, 0, 0);
            }
            ContactPoint2D collisionPoint = collision.GetContact(0);


            Vector2 distanceVector = new Vector2(collisionPoint.point.x - center.x, collisionPoint.point.y - center.y);
            float distance = distanceVector.magnitude;
            float ultimateDistance = boxCollid.bounds.extents.y;
            if (distance >= ultimateDistance) distance = ultimateDistance;
            float percentageDistance = distance / ultimateDistance;
            float angle = percentageDistance * maximalAngle;
            float angleInRadians = CalculateAngleToRadian(angle);
            float tanges = Mathf.Tan(angleInRadians);


            if (collision.gameObject.name == "PlayerOne")
            {
                // bounce up
                if (collisionPoint.point.y > center.y)
                {
                    actualSpeedOfPong += speedOfPongUpgrade;
                    float velocityX = rb.velocity.x;
                    rb.velocity = new Vector2(-velocityX *(actualSpeedOfPong/startingSpeedOfPong), tanges * -velocityX);
                }
                //bounce down
                else
                {
                    actualSpeedOfPong += speedOfPongUpgrade;
                    float velocityX = rb.velocity.x;
                    rb.velocity = new Vector2(-velocityX * (actualSpeedOfPong / startingSpeedOfPong), -tanges * -velocityX);
                }
            }
            else
            { //bounce up
                if (collisionPoint.point.y > center.y)
                {
                    actualSpeedOfPong += speedOfPongUpgrade;
                    float velocityX = rb.velocity.x;
                    rb.velocity = new Vector2(-velocityX * (this.actualSpeedOfPong / startingSpeedOfPong), -tanges * -velocityX);
                }
              //bounce down
                else
                {
                    actualSpeedOfPong += speedOfPongUpgrade;
                    float velocityX = rb.velocity.x;
                    rb.velocity = new Vector2(-velocityX * (this.actualSpeedOfPong / startingSpeedOfPong), tanges * -velocityX);
                }
            }
            
            velocityChanged = true;
            StartCoroutine(ResetVelocityChange());


        }
        else if(collision.gameObject.CompareTag("Walls"))
        {
            paddleHitSound.clip = wallHitClip;
            paddleHitSound.Play();
            ContactPoint2D contactPoint = collision.GetContact(0);
            Vector2 normal = contactPoint.normal;
           rb.velocity = Vector2.Reflect(rb.velocity, normal);
        }
        else if(collision.gameObject.CompareTag("Player") && !velocityChanged && hitFromTheBack)
        {
            paddleHitSound.clip = playerHitClip;
            paddleHitSound.Play();
            ContactPoint2D contactPoint = collision.GetContact(0);
            Vector2 normal = contactPoint.normal;
            rb.velocity = Vector2.Reflect(rb.velocity, normal);
        }
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {if (collision.gameObject.CompareTag("BackOfPlayer"))
        {
            hitFromTheBack = true;
        }
    if(collision.gameObject.CompareTag("SmallerSize") || collision.gameObject.CompareTag("BiggerSize"))
        {
            if (collision.gameObject.CompareTag("BiggerSize"))
            {
                ballRenderer.material.color = Color.yellow;
                Destroy(collision.gameObject);

            }
            else
            {
                ballRenderer.material.color = Color.red;
                Destroy(collision.gameObject);
            }
            powerUpSound.Play();
        }
   
    if(collision.gameObject.CompareTag("HidePowerUp"))
        {
            blueSlider.enabled = false;
            blueSlider.enabled = true;
            powerUpSound.Play();
            Destroy(collision.gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BackOfPlayer"))
        {
            hitFromTheBack = false;
        }
    }

}

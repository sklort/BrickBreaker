using System;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{

    public float Speed = 5.0f;
    
    public KeyCode LeftDirection;
    public KeyCode RightDirection;

    public float XLimit = 3f;

    public float maxBounceAngle = 75f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movement = 0;
        if (GameBehavior.Instance.State == GameBehavior.GameplayState.Play)
        {
            if (Input.GetKey(LeftDirection) && transform.position.x > -XLimit)
            {
                movement -= Speed;
            }

            if (Input.GetKey(RightDirection) && transform.position.x < XLimit)
            {
                movement += Speed;
            }

            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime;
        }
    }

    //Function to calculate angle of ball on paddle hit
    //Found on Zigurous' tutorial "How to Make Bricker in Unity"
    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     BallMovement ball = other.gameObject.GetComponent<BallMovement>();
    //     if (ball != null)
    //     {
    //
    //         Vector3 paddlePosition = this.transform.position;
    //         Vector2 contactPoint = other.GetContact(0).point;
    //
    //         float offset = paddlePosition.x - contactPoint.x;
    //         float width = other.otherCollider.bounds.size.x / 2;
    //
    //         float currentAngle = Vector2.SignedAngle(Vector2.up, ball.GetComponent<Rigidbody2D>().linearVelocity);
    //         float bounceAngle = (offset / width) * this.maxBounceAngle;
    //         float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -this.maxBounceAngle, this.maxBounceAngle);
    //
    //         Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
    //         ball.GetComponent<Rigidbody2D>().linearVelocity = 
    //             rotation * Vector2.up * ball.GetComponent<Rigidbody2D>().linearVelocity.magnitude;
    //     }
    // }
}

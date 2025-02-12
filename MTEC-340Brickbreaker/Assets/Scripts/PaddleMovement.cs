using UnityEngine;

public class PaddleMovement : MonoBehaviour
{

    public float Speed = 5.0f;
    
    public KeyCode LeftDirection;
    public KeyCode RightDirection;

    public float XLimit = 3f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movement = 0;
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

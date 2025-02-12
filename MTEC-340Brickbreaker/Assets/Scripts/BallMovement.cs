using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public float XSpeed;
    public float YSpeed;
    
    private int _xDirection;
    private int _yDirection;

    public float YLimit = 4.79f;
    public float XLimit = 9.3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Random _xDirection, Constant upward _yDirection
        _yDirection = 1;
        if (Random.value > 0.5f)
        {
            _xDirection = 1;
        }
        else
        {
            _xDirection = -1;
        }

    }

    // Update is called once per frame
    void Update()
    {

        // Ball goes past -YLimit
        if (transform.position.y >= YLimit)
        {
            _yDirection *= -1;
        }
        
        //Ball bounces off -YLimit
        // if (transform.position.y >= YLimit)
        // {
        //     _yDirection *= -1;
        // }
        
        //Bounce off XLimit
        if (Mathf.Abs(transform.position.x) >= XLimit)
        {
            _xDirection *= -1;
        }
        
        
        transform.position += new Vector3(XSpeed * _xDirection, YSpeed * _yDirection, 0) * Time.deltaTime;
        
    }
    
}

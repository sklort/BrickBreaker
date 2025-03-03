using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public float XSpeed;
    public float YSpeed;
    
    private int _xDirection;
    private int _yDirection;

    public float YLimit = 4.79f;
    public float XLimit = 9.3f;
    
    private AudioSource _source;
    
    // public new Rigidbody2D rigidbody { get; private set; }
    
    [SerializeField] private AudioClip _wallHit;
    [SerializeField] private AudioClip _paddleHit;
    [SerializeField] private AudioClip _lose;
    [SerializeField] private AudioClip _brickHit;

    // private void Awake()
    // {
    //     this.rigidbody = GetComponent<Rigidbody2D>();
    // }
    
    void ResetBall()
    {
        
        transform.position = Vector3.zero;
        _xDirection = Random.value > 0.5f ? 1 : -1;
        _yDirection = 1;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Brick"))
        {
            _source.clip = _brickHit;
            _source.Play();
            
            
            float _xDistance = other.transform.position.x - this.transform.position.x;
            float _yDistance = other.transform.position.y - this.transform.position.y;
            if (_yDistance > _xDistance)
            {
                if (_yDirection > 0)
                {
                    _yDirection *= -1;
                }
                else
                {
                    _xDirection *= -1;
                }
            }
            else if (_xDistance > _yDistance)
            {
                    _xDirection *= -1;
            }
            GameBehavior.Instance.ScorePoint();
        }
        else if (other.gameObject.CompareTag("Paddle"))
        {
            _yDirection *= -1;
            _source.clip = _paddleHit;
            _source.Play();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _source = GetComponent<AudioSource>();
            //Random _xDirection, Constant upward _yDirection
            _yDirection = 1;
            if (Random.value > 0.51f)
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
            if (GameBehavior.Instance.State == GameBehavior.GameplayState.Play)
            {
                // Ball goes past -YLimit
                if (transform.position.y >= YLimit)
                {
                    _yDirection *= -1;
                    transform.position = new Vector3(
                        transform.position.x,
                        Mathf.Sign(transform.position.y) * YLimit,
                        transform.position.z);

                }

                //Bounce off XLimit
                if (Mathf.Abs(transform.position.x) >= XLimit)
                {
                    _xDirection *= -1;
                    _source.clip = _wallHit;
                    _source.Play();
                    transform.position = new Vector3(
                        Mathf.Sign(transform.position.x) * XLimit,
                        transform.position.y,
                        transform.position.z);
                }

                // Play sound on -YLimit
                if (transform.position.y <= -YLimit)
                {
                    _source.clip = _lose;
                    _source.Play();
                    ResetBall();
                }

                transform.position += new Vector3(XSpeed * _xDirection, YSpeed * _yDirection, 0) * Time.deltaTime;
            }

        }
    }


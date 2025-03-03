using UnityEngine;
using Unity.VisualScripting;
using TMPro;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;
    public GameplayState State;

    private int _score;
    public int Score 
    {
        //=> is shorthand for return
        get => _score;
        set
        {
            //i.e Score = 3; (3 is value)
            _score = value;
            _scoreUI.text = Score.ToString();
        }
    }
    [SerializeField] private TextMeshProUGUI _scoreUI;
    [SerializeField] private TextMeshProUGUI _playAgain;
    [SerializeField] private TextMeshProUGUI _winText;
    [SerializeField] private int _victoryScore;
    [SerializeField] private GameObject _pause;
    [SerializeField] private TextMeshProUGUI _pauseMessage;
    
    public enum GameplayState
    {
        Play, 
        Pause
    }
    void Awake()
    {
        //Singleton pattern
        //When creating an instance, check if one already exists,
        //and if the existing one is the one that is trying to be created
        if (Instance != null && Instance != this)
        {
            //If a different instance already exists,
            //destroy the instance that is currently created
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            ResetGame();
            State = GameplayState.Play;
            _pause.SetActive(false);
            _pauseMessage.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (GameBehavior.Instance.State == GameplayState.Pause)
            {
                _pause.SetActive(true);
                _pauseMessage.enabled = true;
            }

            if (GameBehavior.Instance.State == GameplayState.Play)
            {
                _pause.SetActive(false);
                _pauseMessage.enabled = false;
            }
            if (Score >= _victoryScore)
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    ResetGame();
                }
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                State = State == GameplayState.Play
                    ? GameplayState.Pause
                    : GameplayState.Play;
                _pause.SetActive(false);
            }

            
        }

    private void WinGame()
    {
        _scoreUI.enabled = !_scoreUI.enabled;
        _winText.enabled = true;

    }
    private void CheckWin()
    {
        if (Score >= _victoryScore)
        {
                WinGame();
        }
    }

    private void ResetGame()
    {
        Score = 0;
        _playAgain.enabled = !_playAgain.enabled;
        _winText.enabled = !_winText.enabled;
        _scoreUI.enabled = _scoreUI.enabled;
    }

    public void ScorePoint()
    {
        Score++;
        CheckWin();
    }
    
}


using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private const string highScoreKey = "HighScore";
    private const int defaultHighScore = 0;

    private float _score;
    private int _highScore;
    private GameObject _gameOverText;
    private GameObject _highScoreText;
    private GameObject _bird;
    private bool _isStarted;

    [SerializeField] private Text _scoreText;

    public void Start()
    {
        _isStarted = false;

        _bird = GameObject.Find("Bird");
        _gameOverText = GameObject.Find("GameOverText");
        _highScoreText = GameObject.Find("HighScoreText");
        
        _gameOverText.SetActive(false);
        _highScoreText.SetActive(false);

        _score = 0;
        _scoreText.text = "" + _score;

        _highScore = PlayerPrefs.GetInt(highScoreKey, defaultHighScore);
    }
    public void IncreaseScore()
    {
        _score+= (float)0.5;
        _scoreText.text = "" + _score;
    }

    public void EndGame()
    {
        _gameOverText.SetActive(true);
        if(_score >= _highScore)
        {
            _highScore = (int)_score;
            _highScoreText.GetComponent<Text>().text = "*NEW* Highscore: " + _highScore;
        }
        else
        {
            _highScoreText.GetComponent<Text>().text = "Highscore: " + _highScore;
        }
        _highScoreText.SetActive(true);

        PlayerPrefs.SetInt(highScoreKey, _highScore);
        PlayerPrefs.Save();
    }

    public int GetHighScore()
    {
        return _highScore;
    }

    public void StartGame()
    {
        _isStarted = true;
    }

    public bool IsStarted()
    {
        return _isStarted;
    }

    private void Update()
    {
        if(_bird == null && Input.GetKeyDown(KeyCode.Mouse0) && Time.timeScale == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

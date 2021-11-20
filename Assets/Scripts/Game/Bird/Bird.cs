using UnityEngine;

public class Bird : MonoBehaviour
{
    Vector2 _forceDirection = new Vector2(0, 1);
    private Score _score;
    private SFXPlaying _sfx;

    [SerializeField] int _forcePower = 500;
    [SerializeField] private GameObject _deathParticlePrefab;

    private void Start()
    {
        _score = GameObject.Find("ScoreText").GetComponent<Score>();
        _sfx = GameObject.Find("SFXPlaying").GetComponent<SFXPlaying>();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown("space")) && Time.timeScale == 1)
        {
            if(!_score.IsStarted())
            {
                _score.StartGame();
            }

            Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();

            rigidBody.gravityScale = 1;
            rigidBody.velocity = new Vector2(0,0);
            rigidBody.AddForce(_forceDirection * _forcePower);

            _sfx.PlayFlap();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Instantiate(_deathParticlePrefab, transform.position, Quaternion.identity);
        _score.EndGame();

        _sfx.PlayPoof();
    }
}

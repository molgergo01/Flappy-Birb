using UnityEngine;

public class Pipe : MonoBehaviour
{
    private bool _haveScored = false;

    private Score _score;
    [SerializeField] float _velocity = 1;

    private void Start()
    {
        _score = GameObject.Find("ScoreText").GetComponent<Score>();
    }

    void Update()
    {
        Vector3 newPos = transform.position;
        newPos.x -= _velocity * Time.deltaTime;
        transform.position = newPos;

        if(transform.position.x < (float)-11.5)
        {
            Destroy(gameObject);
        }

        if(GameObject.Find("Bird") != null && transform.position.x < GameObject.Find("Bird").transform.position.x && !_haveScored)
        {
            _score.IncreaseScore();
            _haveScored = true;
        }
    }
}

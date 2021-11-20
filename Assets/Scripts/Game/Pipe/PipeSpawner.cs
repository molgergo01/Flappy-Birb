using UnityEngine;

public class PipeSpawner : MonoBehaviour
{

    float _timePassed;
    private Score _score;

    [SerializeField] private GameObject _pipePrefab;
    [SerializeField] private float _spaceBetweenPipes = 15;

    private void Start()
    {
        _timePassed = 2;
        _score = GameObject.Find("ScoreText").GetComponent<Score>();
    }

    public void setPrefab(GameObject prefab)
    {
        _pipePrefab = prefab;
    }

    void Update()
    {
        if(_score.IsStarted())
        {
            _timePassed += Time.deltaTime;
        }

        if(_timePassed >= 3)
        {
            float randomY = (float)(new System.Random().NextDouble() * (-5 - -8 + 1) + -8);

            Vector3 posBottom = new Vector3((float)11.5, randomY, 0);
            Vector3 posTop = new Vector3((float)11.5, randomY+_spaceBetweenPipes, 0);

            Instantiate(_pipePrefab, posBottom, Quaternion.identity);
            Instantiate(_pipePrefab, posTop, Quaternion.Euler(0, 0, 180f));

            _timePassed = 0;
        }
    }
}

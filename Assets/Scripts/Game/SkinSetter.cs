using UnityEngine;
using UnityEngine.UI;

public class SkinSetter : MonoBehaviour
{
    GameObject background;
    GameObject ground;
    GameObject pipeSpawner;

    GameObject[] scoreUIText;

    AudioSource music;

    private Sprite _backGroundSprite;
    private Sprite _groundSprite;
    private GameObject _pipePrefab;
    private Color _UIColor;

    [SerializeField] Sprite _originalBG;
    [SerializeField] Sprite _originalGround;
    [SerializeField] GameObject _originalPipe;

    [SerializeField] Sprite _spaceBG;
    [SerializeField] Sprite _spaceGround;
    [SerializeField] GameObject _spacePipe;

    [SerializeField] Sprite _candyBG;
    [SerializeField] Sprite _candyGround;
    [SerializeField] GameObject _candyPipe;

    void Start()
    {
        background = GameObject.Find("Background");
        ground = GameObject.Find("Ground");
        pipeSpawner = GameObject.Find("PipeSpawner");

        scoreUIText = GameObject.FindGameObjectsWithTag("scoreUIText");

        music = GameObject.Find("Main Camera").GetComponent<AudioSource>();

        IntToSkin();

        background.GetComponent<SpriteRenderer>().sprite = _backGroundSprite;
        ground.GetComponent<SpriteRenderer>().sprite = _groundSprite;
        pipeSpawner.GetComponent<PipeSpawner>().setPrefab(_pipePrefab);

        foreach(GameObject obj in scoreUIText)
        {
            obj.GetComponent<Text>().color = _UIColor;
        }

        music.volume = PlayerPrefs.GetFloat("Volume", (float)0.2);
    }

    private void IntToSkin()
    {
        int selection = PlayerPrefs.GetInt("SelectedSkin", 0);

        if(selection == 0)
        {
            _backGroundSprite = _originalBG;
            _groundSprite = _originalGround;
            _pipePrefab = _originalPipe;
            _UIColor = Color.white;
        }
        else if (selection == 1)
        {
            _backGroundSprite = _spaceBG;
            _groundSprite = _spaceGround;
            _pipePrefab = _spacePipe;
            _UIColor = Color.white;
        }
        else if (selection == 2)
        {
            _backGroundSprite = _candyBG;
            _groundSprite = _candyGround;
            _pipePrefab = _candyPipe;
            _UIColor = Color.black;
        }
    }

}

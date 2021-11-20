using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    GameObject pausePanel;
    GameObject optionsPanel;
    GameObject menu;

    GameObject scoreUI;


    // Start is called before the first frame update
    void Start()
    {
        pausePanel = GameObject.Find("PausePanel");
        optionsPanel = GameObject.Find("OptionsPanel");
        menu = GameObject.FindGameObjectWithTag("menu");

        scoreUI = GameObject.Find("ScoreUI");

        HideMenu();
    }

    private void HideMenu()
    {
        menu.SetActive(false);
        optionsPanel.SetActive(false);
        pausePanel.SetActive(false);
    }
    
    private void ShowMenu()
    {
        menu.SetActive(true);
    }

    public void OnOptionsClick()
    {
       pausePanel.SetActive(false);
       optionsPanel.SetActive(true);
    }

    public void OnBackClick()
    {
        optionsPanel.SetActive(false);
        pausePanel.SetActive(true);    
    }

    public void OnMainMenuClick()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }       
    }

    public void ToggleMenu()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            ShowMenu();
            scoreUI.SetActive(false);
            optionsPanel.SetActive(false);
            pausePanel.SetActive(true);
        }

        else if (Time.timeScale == 0)
        {
            HideMenu();
            scoreUI.SetActive(true);
            Time.timeScale = 1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameObject[] mainMenuObjects;
    GameObject[] optionsMenuObjects;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuObjects = GameObject.FindGameObjectsWithTag("mainMenuObject");
        optionsMenuObjects = GameObject.FindGameObjectsWithTag("optionsMenuObject");

        HideOptionsMenu();
    }

    private void ShowMainMenu()
    {
        foreach(GameObject obj in mainMenuObjects)
        {
            obj.SetActive(true);
        }
    }

    private void HideMainMenu()
    {
        foreach (GameObject obj in mainMenuObjects)
        {
            obj.SetActive(false);
        }
    }

    private void ShowOptionsMenu()
    {
        foreach (GameObject obj in optionsMenuObjects)
        {
            obj.SetActive(true);
        }
    }

    private void HideOptionsMenu()
    {
        foreach (GameObject obj in optionsMenuObjects)
        {
            obj.SetActive(false);
        }
    }

    public void OptionsMenuClick()
    {
        HideMainMenu();
        ShowOptionsMenu();
    }

    public void BackClick()
    {
        HideOptionsMenu();
        ShowMainMenu();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

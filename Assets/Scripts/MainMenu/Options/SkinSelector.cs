using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinSelector : MonoBehaviour
{
    const string selectedSkinToken = "SelectedSkin";

    GameObject skinImage;

    [SerializeField] Sprite _originalBG;
    [SerializeField] Sprite _spaceBG;
    [SerializeField] Sprite _candyBG;

    private void Start()
    {
        skinImage = GameObject.Find("SkinImage");

        int selectedSkin = PlayerPrefs.GetInt(selectedSkinToken, 0);

        if(selectedSkin == 0)
        {
            skinImage.GetComponent<Image>().sprite = _originalBG;
        }
        else if(selectedSkin == 1)
        {
            skinImage.GetComponent<Image>().sprite = _spaceBG;
        }       
        else if (selectedSkin == 2)
        {
            skinImage.GetComponent<Image>().sprite = _candyBG;
        }

    }

    public void ShiftLeft()
    {

        if(skinImage.GetComponent<Image>().sprite == _originalBG)
        {
            skinImage.GetComponent<Image>().sprite = _candyBG;

            PlayerPrefs.SetInt(selectedSkinToken, 2);
            PlayerPrefs.Save();
        }
        else if(skinImage.GetComponent<Image>().sprite == _candyBG)
        {
            skinImage.GetComponent<Image>().sprite = _spaceBG;

            PlayerPrefs.SetInt(selectedSkinToken, 1);
            PlayerPrefs.Save();
        }
        else if (skinImage.GetComponent<Image>().sprite == _spaceBG)
        {
            skinImage.GetComponent<Image>().sprite = _originalBG;

            PlayerPrefs.SetInt(selectedSkinToken, 0);
            PlayerPrefs.Save();
        }
    }

    public void ShiftRight()
    {
        if (skinImage.GetComponent<Image>().sprite == _spaceBG)
        {
            skinImage.GetComponent<Image>().sprite = _candyBG;

            PlayerPrefs.SetInt(selectedSkinToken, 2);
            PlayerPrefs.Save();
        }
        else if (skinImage.GetComponent<Image>().sprite == _originalBG)
        {
            skinImage.GetComponent<Image>().sprite = _spaceBG;

            PlayerPrefs.SetInt(selectedSkinToken, 1);
            PlayerPrefs.Save();
        }
        else if (skinImage.GetComponent<Image>().sprite == _candyBG)
        {
            skinImage.GetComponent<Image>().sprite = _originalBG;

            PlayerPrefs.SetInt(selectedSkinToken, 0);
            PlayerPrefs.Save();
        }
    }
}

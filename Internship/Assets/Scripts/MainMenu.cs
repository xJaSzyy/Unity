using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreCountText;

    private void Start()
    {
        highScoreCountText.text = PlayerPrefs.GetInt("Highscore").ToString();
    }

    public void PlayButtonOnClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void SettingsButtonOnClick()
    {

    }

    public void ExitButtonOnClick()
    {
        Application.Quit();
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject SettingsPanel;
    public GameObject notgameOver;
    public Button continueButton;
    public Button settingsButton;
    public Button quitButton;
    public Button backButton;

    void Start()
    {
        PausePanel.SetActive(false);
        SettingsPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("paused");
            Pause();
        }
        quitButton.onClick.AddListener(Quit);
        continueButton.onClick.AddListener(Continue);
        settingsButton.onClick.AddListener(Settings);
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        SettingsPanel.SetActive(false);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        notgameOver.SetActive(false);
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        notgameOver.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("Button Clicked");
        Application.Quit();
    }

    public void Settings()
    {
        PausePanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }
}

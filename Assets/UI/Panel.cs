using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Panel : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject VolumePanel;

    public void ShowMainMenuPanel()
    {
        VolumePanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }

    public void ShowVolumePanel()
    {
        VolumePanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainStory");
    }

    public void OnBackButtonPressed()
    {
        MainMenuPanel.SetActive(true);
        VolumePanel.SetActive(false);
    }

    public void QuitGame()

    {
        Debug.Log("The game is closing");
        Application.Quit();
    }
}

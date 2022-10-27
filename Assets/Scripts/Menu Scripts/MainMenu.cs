using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Button Event Handled in Unity
    /// </summary>

    private GameObject activePanelCard;

    [SerializeField]
    private GameObject titleCard;

    [SerializeField]
    private GameObject settings;

    [SerializeField]
    private Button settingsDefaultButton;
    
    [SerializeField]
    private Button mainMenuDefaultButton;


    private void Start()
    {
        activePanelCard = titleCard;
    }


    public void LoadGame()
    {
        SceneController.instance.LoadScene(Scenes.Level_1_PU);
    }

    public void GoToSetttings()
    {
        activePanelCard.SetActive(false);
        activePanelCard = settings;
        settings.SetActive(true);
        EventSystem.current.SetSelectedGameObject(settingsDefaultButton.gameObject);
    }

    public void GoToMainMenu()
    {
        activePanelCard.SetActive(false);
        activePanelCard = titleCard;
        titleCard.SetActive(true);
        EventSystem.current.SetSelectedGameObject(mainMenuDefaultButton.gameObject);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

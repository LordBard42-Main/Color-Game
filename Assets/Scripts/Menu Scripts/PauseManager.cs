using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{


    [SerializeField]
    private PlayerInput playerInput;


    public delegate void PauseEvent(bool isPaused);
    public PauseEvent OnPause;
    

    private bool gamePaused = false;

    public void PauseGame(InputAction.CallbackContext obj)
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
            return;

        if (obj.performed)
        {
            if (!gameObject.activeInHierarchy)
                return;

            gamePaused = !gamePaused;
            OnPause?.Invoke(gamePaused);

            if (gamePaused)
            {
                playerInput.SwitchCurrentActionMap("UI");
                Time.timeScale = 0;
            }
            else
            {
                playerInput.SwitchCurrentActionMap("Player");
                Time.timeScale = 1;
            }
        }
    }

    public void ResetPause()
    {
        Time.timeScale = 1;
    }


}

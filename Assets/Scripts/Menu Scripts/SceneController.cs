using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Scenes
{
    MainMenu = 0,
    Level_1_PU = 1, Level_2_PU = 2, Level_3_PU = 3, Level_4_PU = 4, Level_5_PU = 5, Level_6_PU = 6,
    Level_1_PL = 10001, Level_2_PL = 10002, Level_3_PL = 10003, Level_4_PL = 10004,
}


public class SceneController : MonoBehaviour
{

    public static SceneController instance;

    [SerializeField]
    private Image screenCover;

    [SerializeField]
    private Animator transition;

    [SerializeField]
    private float transitionTime = 1f;

    [SerializeField]
    PlayerInput playerInput;


    public delegate void SceneLoadedCallback(Scenes scene);
    public event SceneLoadedCallback OnSceneLoaded; 
    
    


    private void Awake()
    {

        #region  Singleton
        if (instance != null)
        {
            Debug.LogWarning("SceneController already exists");
            Destroy(gameObject);
            return;
        }
        instance = this;
        #endregion



    }

    private void Start()
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }

    private void Update()
    {
    }

    public void LoadScene(Scenes to)
    {

        StartCoroutine(wait(to));

        IEnumerator wait(Scenes to)
        {
            transition.SetTrigger("Start");
            yield return new WaitForSecondsRealtime(transitionTime);

            if (GetCurrentScene() != to)
                SceneManager.LoadScene(to.ToString());
        }

    }
    
    /// <summary>
     /// This gets called automatically whenever unity loads a new scene.
     /// In this instance, it gets called after the screen fades to black
     /// </summary>
     /// <param name="scene"></param>
     /// <param name="mode"></param>
    void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (OnSceneLoaded != null)
            OnSceneLoaded(GetCurrentScene());


        transition.SetTrigger("End");

        if (scene.name == "MainMenu")
            playerInput.SwitchCurrentActionMap("UI");
        else
            playerInput.SwitchCurrentActionMap("Player");


    }

    /// <summary>
    /// Returns the enum equivelant of the current scene
    /// </summary>
    /// <returns></returns>
    public Scenes GetCurrentScene()
    {
        return ((Scenes)System.Enum.Parse(typeof(Scenes), SceneManager.GetActiveScene().name));
    }

    private void SetScreenImage(float value)
    {
        screenCover.color = new Color(0, 0, 0, 1 - value);
    }

}

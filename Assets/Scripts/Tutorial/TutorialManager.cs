using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    PlayerInputManager playerInputManager;
    ColorInjector colorInjector;

    [SerializeField]
    private bool initTutorial;

    private bool runTutorial;

    private bool characterMoved = false;
    private bool characterRotated = false;
    private bool characterSiphoned = false;
    private bool characterInjected = false;
    private bool tutorialCompleted = false;

    public delegate void MovementTutorialCompleted();
    public event MovementTutorialCompleted OnMovementTutorialCompleted;

    public delegate void RotateTutorialCompleted();
    public event RotateTutorialCompleted OnRotateTutorialCompleted;

    public delegate void SiphonTutorialCompleted();
    public event SiphonTutorialCompleted OnSiphonTutorialCompleted;

    public delegate void InjectTutorialCompleted();
    public event InjectTutorialCompleted OnInjectTutorialCompleted;

    public delegate void TutorialCompleted();
    public event TutorialCompleted OnTutorialCompleted;
    
    public delegate void MovementTutorialStarted();
    public event MovementTutorialStarted OnMovementTutorialStarted;

    public delegate void RotateTutorialStarted();
    public event RotateTutorialStarted OnRotateTutorialStarted;

    public delegate void SiphonTutorialStarted();
    public event SiphonTutorialStarted OnSiphonTutorialStarted;

    public delegate void InjectTutorialStarted();
    public event InjectTutorialStarted OnInjectTutorialStarted;

    public delegate void TutorialStarted();
    public event TutorialStarted OnTutorialStarted;


    private void Awake()
    {
        if (initTutorial)
            PlayerPrefs.SetInt("TutorialMode", 0);
        runTutorial = PlayerPrefs.GetInt("tutorialMode") == 1 ? false : true;
    }

    private void Start()
    {
        playerInputManager = PlayerInputManager.instance;
        colorInjector = FindObjectOfType<ColorInjector>();

        playerInputManager.OnMovementPressed += MoveCharacter;
        playerInputManager.OnCycleLeftPressed += RotateColorSiphon;
        playerInputManager.OnCycleRightPressed += RotateColorSiphon;
        //playerInputManager.OnFire2Pressed += SiphonColor;
        //playerInputManager.OnFire1Pressed += InjectColor;

        colorInjector.OnInjectTargetFound += InjectColor;
        colorInjector.OnSiphonTargetFound += SiphonColor;

        if (runTutorial)
            AdvanceColorTutorial();

    }

    private void OnDestroy()
    {

        playerInputManager.OnMovementPressed -= MoveCharacter;
        playerInputManager.OnCycleLeftPressed -= RotateColorSiphon;
        playerInputManager.OnCycleRightPressed -= RotateColorSiphon;
        //playerInputManager.OnFire2Pressed -= SiphonColor;
        //playerInputManager.OnFire1Pressed -= InjectColor;

        colorInjector.OnInjectTargetFound -= InjectColor;
        colorInjector.OnSiphonTargetFound -= SiphonColor;
    }

    public void AdvanceColorTutorial()
    {
        if(!characterMoved)
        {
            OnMovementTutorialStarted!?.Invoke();
        }
        else if(!characterRotated)
        {
            OnRotateTutorialStarted!?.Invoke();

        }
        else if(!characterSiphoned)
        {
            OnSiphonTutorialStarted!?.Invoke();

        }
        else if(!characterInjected)
        {
            OnInjectTutorialStarted!?.Invoke();
        }
        else
        {
            tutorialCompleted = true;
            PlayerPrefs.SetInt("TutorialMode", 1);
            OnTutorialCompleted!?.Invoke();
        }

    }

    public void MoveCharacter(Vector2 direction)
    {
        characterMoved = true;
        OnMovementTutorialCompleted!?.Invoke();
        StartCoroutine(wait());
    }

    public void RotateColorSiphon()
    {
        characterRotated = true;
        OnRotateTutorialCompleted!?.Invoke();
        StartCoroutine(wait());
    }

    public void SiphonColor()
    {
        characterSiphoned = true;
        OnSiphonTutorialCompleted!?.Invoke();
        StartCoroutine(wait());

    }

    public void InjectColor()
    {
        characterInjected = true;
        OnInjectTutorialCompleted!?.Invoke();
        StartCoroutine(wait());

    }


    IEnumerator wait()
    {
        yield return new WaitForSeconds(4f);
        AdvanceColorTutorial();
    }

}

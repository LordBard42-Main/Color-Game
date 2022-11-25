using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{

    [SerializeField]
    private Transform movementTutorial;

    [SerializeField]
    private Transform rotateTutorial;

    [SerializeField]
    private Transform siphonTutorial;

    [SerializeField]
    private Transform injectTutorial;


    TutorialManager tutorialManager;

    private void Awake()
    {
        tutorialManager = GetComponent<TutorialManager>();
    }

    private void Start()
    {
        tutorialManager.OnMovementTutorialCompleted += HideMovementTutorialUI;
        tutorialManager.OnRotateTutorialCompleted += HideRotateTutorialUI;
        tutorialManager.OnSiphonTutorialCompleted += HideSiphonTutorialUI;
        tutorialManager.OnInjectTutorialCompleted += HideInjectTutorialUI;

        tutorialManager.OnMovementTutorialStarted += ShowMovementTutorialUI;
        tutorialManager.OnRotateTutorialStarted += ShowRotateTutorialUI;
        tutorialManager.OnSiphonTutorialStarted += ShowSiphonTutorialUI;
        tutorialManager.OnInjectTutorialStarted += ShowInjectTutorialUI;
    }

    private void OnDestroy()
    {

        tutorialManager.OnMovementTutorialCompleted -= HideMovementTutorialUI;
        tutorialManager.OnRotateTutorialCompleted -= HideRotateTutorialUI;
        tutorialManager.OnSiphonTutorialCompleted -= HideSiphonTutorialUI;
        tutorialManager.OnInjectTutorialCompleted -= HideInjectTutorialUI;

        tutorialManager.OnMovementTutorialStarted -= ShowMovementTutorialUI;
        tutorialManager.OnRotateTutorialStarted -= ShowRotateTutorialUI;
        tutorialManager.OnSiphonTutorialStarted -= ShowSiphonTutorialUI;
        tutorialManager.OnInjectTutorialStarted -= ShowInjectTutorialUI;
    }

    public void ShowMovementTutorialUI()
    {
        movementTutorial.gameObject.SetActive(true);
    }
    
    public void HideMovementTutorialUI()
    {
        movementTutorial.gameObject.SetActive(false);
    }

    public void ShowRotateTutorialUI()
    {
        rotateTutorial.gameObject.SetActive(true);
    }

    public void HideRotateTutorialUI()
    {
        rotateTutorial.gameObject.SetActive(false);
    }

    public void ShowSiphonTutorialUI()
    {
        siphonTutorial.gameObject.SetActive(true);
    }

    public void HideSiphonTutorialUI()
    {
        siphonTutorial.gameObject.SetActive(false);
    }

    public void ShowInjectTutorialUI()
    {
        injectTutorial.gameObject.SetActive(true);
    }

    public void HideInjectTutorialUI()
    {
        injectTutorial.gameObject.SetActive(false);
    }

}

using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    IdleSlayerState slayerState = new IdleSlayerState();
    TownState townState = new TownState();
    BaseState currentState;
    public string currentStateName = "";
    public Button changeStateButton;
    public bool isChanging;

    public static GameManager instance;
    private void Awake()
    {
        instance = this;
        changeStateButton.onClick.AddListener(() => {StartCoroutine(ToggleState());});
    }

    private IEnumerator ToggleState()
    {
        if(isChanging == false)
        {
            isChanging = true;
            UIManager.instance.FadeIn();

            yield return new WaitForSeconds(0.1f);

            if(CompareState("IdleSlayerState"))
                ChangeState(townState);
            else
                ChangeState(slayerState);

            UIManager.instance.FadeOut();

            yield return new WaitForSeconds(1f);
            isChanging = false;
        }
        
    }

    private void Start() 
    {
        ChangeState(townState);
    }

    public void ChangeState(BaseState newState)
    {
        currentState?.OnStateExit();
        currentState = newState;
        currentState?.OnStateEnter();
        currentStateName = newState.ToString();
    }

    private void Update() 
    {
        currentState?.OnStateStay();
    }

    public bool CompareState(String stateName)
    {
        switch(stateName)
        {
            case "IdleSlayerState":
            return currentState == slayerState;

            case "TownState":
            return currentState == townState;
        }

        return false;
    }
}

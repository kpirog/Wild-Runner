using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    private BaseGameState currentState;

    private void Start()
    {
        SwitchState(new MenuState(this));
    }
    public void SwitchState(BaseGameState newState)
    {
        if (currentState != null) currentState.ExitState();

        currentState = newState;
        currentState.EnterState();
    }
    private void Update()
    {
        currentState.UpdateState();
    }
    private void OnDestroy()
    {
        currentState.ExitState();
    }
}

using UnityEngine;

public abstract class BaseGameState 
{
    protected GameStateMachine gameStateMachine;
    
    public BaseGameState(GameStateMachine gameStateMachine)
    {
        this.gameStateMachine = gameStateMachine;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
}

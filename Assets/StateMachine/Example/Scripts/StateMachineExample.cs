using Anderson.Tools;
using UnityEngine;

public class StateMachineExample : MonoBehaviour
{
    public enum States
    {
        IDLE,
        WALK,
        RUN,


        COUNT // will return 3 
    }

    private StateMachine m_StateMachine;

    private void Awake()
    {
        InitStateMachine();
    }

    private void InitStateMachine()
    {
        m_StateMachine = new StateMachine(States.COUNT.ToInt());

        m_StateMachine.AddState(States.IDLE.ToInt(), IdleEnterState, IdleUpdateState, IdleExitState);
        m_StateMachine.AddState(States.WALK.ToInt(), null, WalkUpdate, null);
        m_StateMachine.AddState(States.RUN.ToInt(), RunEnterState, null, null);

        m_StateMachine.ChangeState(States.IDLE.ToInt());
    }

    private void Update()
    {
        m_StateMachine.Update();

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            m_StateMachine.ChangeState(States.IDLE.ToInt());
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            m_StateMachine.ChangeState(States.WALK.ToInt());
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            m_StateMachine.ChangeState(States.RUN.ToInt());
        }
        
    }

    private void IdleEnterState()
    {
        Debug.Log("Idle Enter State");
    }

    private void IdleUpdateState()
    {
        Debug.Log("Idle Update State");
    }

    private void IdleExitState()
    {
        Debug.Log("Idle Exit State");
    }

    private void WalkUpdate()
    {
        Debug.Log("Walk Update State");
    }

    private void RunEnterState()
    {
        Debug.Log("Run Enter State");
    }
}

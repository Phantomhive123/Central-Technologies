using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 抽象层代码
public enum TRAN_INPUT
{
    BUTTON_A,
    BUTTON_B,
    TIME_OUT,
}

public interface State
{
    State HandleInput(TRAN_INPUT input);
    void EnterState();
}
#endregion

#region 状态实现代码
public class IdleState:State
{
    public State HandleInput(TRAN_INPUT input)
    {
        if(input == TRAN_INPUT.BUTTON_A)
        {
            return new SkillA();
        }
        else if(input == TRAN_INPUT.BUTTON_B)
        {
            return new DodgeState();
        }
        return null;
    }

    public void EnterState()
    {
        Debug.Log("To Idle State");
    }
}

public class DodgeState : State
{
    public void EnterState()
    {
        Debug.Log("To Dodge State");
    }

    public State HandleInput(TRAN_INPUT input)
    {
        if (input == TRAN_INPUT.TIME_OUT)
        {
            return new IdleState();
        }
        return null;
    }
}

public class SkillA : State
{
    public void EnterState()
    {
        Debug.Log("To Skill A");
    }

    public State HandleInput(TRAN_INPUT input)
    {
        if(input == TRAN_INPUT.BUTTON_A)
        {
            return new SkillB();
        }
        else if(input == TRAN_INPUT.TIME_OUT)
        {
            return new IdleState();
        }
        return null;
    }
}

public class SkillB : State
{
    public void EnterState()
    {
        Debug.Log("To Skill B");
    }

    public State HandleInput(TRAN_INPUT input)
    {
        if(input == TRAN_INPUT.TIME_OUT)
        {
            return new IdleState();
        }
        return null;
    }
}
#endregion

#region 对外接口
public class FSM
{
    State CurrentState;
    public FSM()
    {
        CurrentState = new IdleState();
        CurrentState.EnterState();
    }

    public void HandleInput(TRAN_INPUT input)
    {
        State newState = CurrentState.HandleInput(input);
        if(newState != null)
        {
            CurrentState = newState;
            CurrentState.EnterState();
        }
    }
}
#endregion

#region 测试用例
public class FSMTest : MonoBehaviour
{
    public FSM fsm;
    // Start is called before the first frame update
    void Start()
    {
        fsm = new FSM();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.J))
        {
            fsm.HandleInput(TRAN_INPUT.BUTTON_A);
            StopAllCoroutines();
            StartCoroutine(autoTimeOut(2));
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            fsm.HandleInput(TRAN_INPUT.BUTTON_B);
            StopAllCoroutines();
            StartCoroutine(autoTimeOut(1));
        }
    }

    IEnumerator autoTimeOut(float sec)
    {
        yield return new WaitForSeconds(sec);
        fsm.HandleInput(TRAN_INPUT.TIME_OUT);
    }
}
#endregion

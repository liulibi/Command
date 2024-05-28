using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    [SerializeField]private InputHandler m_InputHandler;
    private List<Command> m_Commands = new List<Command>();

    private readonly MoveForward moveForward = new MoveForward();
    private readonly MoveBack moveBack = new MoveBack();
    private readonly MoveLeft moveLeft = new MoveLeft();
    private readonly MoveRight moveRight = new MoveRight();

    private void Start()
    {
        m_InputHandler.playerMoveForwardAction += M_InputHandler_playerMoveForwardAction;
        m_InputHandler.playerMoveBackwardAction += M_InputHandler_playerMoveBackwardAction;
        m_InputHandler.playerMoveLeftAction += M_InputHandler_playerMoveLeftAction;
        m_InputHandler.playerMoveRightAction += M_InputHandler_playerMoveRightAction;
        m_InputHandler.playerMoveUndoAction += M_InputHandler_playerMoveUndoAction;
    }

    private void M_InputHandler_playerMoveUndoAction(object sender, System.EventArgs e)
    {
        StartCoroutine(UndoAction());
    }

    private IEnumerator UndoAction()
    {
        Debug.Log("Undon Action");
        m_Commands.Reverse();
        foreach(Command cmd in m_Commands)
        {
            yield return new WaitForSeconds(.2f);
            cmd.Undo();
        }
        m_Commands.Clear();
    }

    private void M_InputHandler_playerMoveRightAction(object sender, System.EventArgs e)
    {
        Debug.Log("MoveRight Action");
        moveRight.Execute(m_InputHandler._playerCube);
        m_Commands.Add(moveRight);
    }

    private void M_InputHandler_playerMoveLeftAction(object sender, System.EventArgs e)
    {
        Debug.Log("MoveLeft Action");
        moveLeft.Execute(m_InputHandler._playerCube);
        m_Commands.Add(moveLeft);
    }

    private void M_InputHandler_playerMoveBackwardAction(object sender, System.EventArgs e)
    {
        Debug.Log("MoveBack Action");
        moveBack.Execute(m_InputHandler._playerCube);
        m_Commands.Add(moveBack);
    }

    private void M_InputHandler_playerMoveForwardAction(object sender, System.EventArgs e)
    {
        Debug.Log("MoveForward Action");
        moveForward.Execute(m_InputHandler._playerCube);
        m_Commands.Add(moveForward);
    }
}

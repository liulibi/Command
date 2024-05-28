using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class InputHandler : MonoBehaviour
{
    public GameObject _playerCube;

    public event EventHandler playerMoveForwardAction;
    public event EventHandler playerMoveBackwardAction;
    public event EventHandler playerMoveLeftAction;
    public event EventHandler playerMoveRightAction;
    public event EventHandler playerMoveUndoAction; 

    private void Start()
    {
        _playerCube = GameObject.Find("Player");
    }

    private void Update()
    {
        PlayerInputHandler();
    }

    private void PlayerInputHandler()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            playerMoveForwardAction?.Invoke(this,EventArgs.Empty);
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            playerMoveBackwardAction?.Invoke(this, EventArgs.Empty);
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            playerMoveRightAction?.Invoke(this, EventArgs.Empty);
        }

        if( Input.GetKeyDown(KeyCode.A))
        {
            playerMoveLeftAction?.Invoke(this, EventArgs.Empty);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            playerMoveUndoAction?.Invoke(this, EventArgs.Empty);
        }
    }
}

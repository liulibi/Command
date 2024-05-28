using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward: Command
{
    private GameObject _player;

    public override void Execute(GameObject player)
    {
        this._player = player;
        _player.transform.Translate(Vector3.forward);
    }

    public override void Undo()
    {
        _player.transform.Translate(Vector3.back);
    }
}

public class MoveLeft : Command
{
    private GameObject _player;

    public override void Execute(GameObject player)
    {
        this._player = player;
        player.transform.Translate(Vector3.left);
    }

    public override void Undo()
    {
        _player.transform.Translate(Vector3.right);
    }
}

public class MoveRight : Command
{
    private GameObject _player;

    public override void Execute(GameObject player)
    {
        this._player = player;
        player.transform.Translate(Vector3.right);
    }

    public override void Undo()
    {
        _player.transform.Translate(Vector3.left);
    }
}

public class MoveBack : Command
{
    private GameObject _player;

    public override void Execute(GameObject player)
    {
        this._player = player;
        player.transform.Translate(Vector3.back);
    }

    public override void Undo()
    {
        _player.transform.Translate(Vector3.forward);
    }
}




using System;
using UnityEngine;

public class PlayerInput: IInput
{
    public PlayerMover _mover;
    protected Vector2 InputVector;
    protected IInputChecker Checker;

    public PlayerInput(PlayerMover mover, IInputChecker checker)
    {
        _mover = mover;
        Checker= checker;
    }

    public virtual void GetInput()
    {
    }

    public virtual void ProcessInput()
    {
        GetInput();
        _mover.Move(InputVector);
    }
}
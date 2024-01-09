using System;
using UnityEngine;

public class DesktopInput : PlayerInput
{
    private bool _isShooting;
    public DesktopInput(PlayerMover mover, IInputChecker checker) : base(mover, checker)
    {
        Checker.StartInputChecker(this);
    }

    public override void GetInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        InputVector = new Vector3(horizontalInput, verticalInput,3);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMover
{
    void Move(float speed);
    void ResetPosition(Vector3 position);
}

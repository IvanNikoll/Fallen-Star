using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerView : MonoBehaviour, IPositionChecker
{
    public event Action<Vector3> OnPositionChecked;
    public void PlayerPositionChecker()
    {
        OnPositionChecked?.Invoke(gameObject.transform.position);
    }
}

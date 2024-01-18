using System.Collections;
using UnityEngine;

public class MenuBG : MonoBehaviour
{
    private Transform _backGround;

    private void Start()
    {
        _backGround = transform;
        StartCoroutine(MoveBackGround());
    }

    private IEnumerator MoveBackGround()
    {
        while(true)
        {
            transform.Rotate(0, 0, 0.1f);
            yield return new WaitForSeconds(0.04f);
        }
    }
}
using System;
using UnityEngine;

public class GameFlowController: IGameStopper 
{
    public event Action OnGameOver;
    
    public void StopTheGame()
    {
        OnGameOver?.Invoke();
        StopObstacles();
    }

    private void StopObstacles()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Planet");
        foreach(GameObject gameObject in gameObjects)
        {
            IGameStopper stopper = gameObject.GetComponent<IGameStopper>();
            if (stopper != null)
            {
                stopper.StopTheGame();
            }
        }
    }
}
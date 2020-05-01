using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanelController : MonoBehaviour
{
    public EventManager eventManager;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            eventManager.OnRestartGame();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanelController : MonoBehaviour
{
    public EventManager eventManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            eventManager.OnRestartGame();
        }
    }
}

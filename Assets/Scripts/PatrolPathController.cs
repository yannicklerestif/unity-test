using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPathController : MonoBehaviour
{
    public GameObject left;
    public GameObject right;
    
    // Start is called before the first frame update
    void Start()
    {
        left.SetActive(false);
        right.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

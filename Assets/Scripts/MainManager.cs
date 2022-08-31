using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    //ENCAPSULATION
    public static MainManager Instance {get; private set;}
    // Start is called before the first frame update
    void Start()
    {
        MainManager.Instance = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemdisapears : MonoBehaviour
{
    [SerializeField] private DialogueManager _DialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        while (!_DialogueManager.RoboticEyes)
        {
            if (_DialogueManager.RoboticEyes == true)
            {
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemdisappears : MonoBehaviour
{
    [SerializeField] private DialogueManager _DialogueManager;

    // Start is called before the first frame update

    // Update is called once per frame
    
    
    void Update()
    {
        if (_DialogueManager.RoboticEyes)
        {
            Destroy(gameObject);
        }
    }
}

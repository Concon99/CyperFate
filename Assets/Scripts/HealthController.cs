using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int PlayerHealth;

    [SerializeField] private Image[] hearts; //Creating a Array for the hearts (the three hearts)
    
    void Start() 
    {
        UpdateHealth();
    }


    public void UpdateHealth()
    {
        for (int i = 0; i < hearts.Length; i++) /*searches through the array to check if i is less then the array 
        and then if its good it will increase by 1 (i++) untill it stops */
        {
            if (i < PlayerHealth) //if i is lower then player Health
            {
                hearts[i].color = Color.red; //make the heart red or alive (will probably change this later)
            }
            else //if i is higher then player Health
            {
                hearts[i].color = Color.black; //make the heart black/white or dead (will probably change this later)
            }
        }
    }
}

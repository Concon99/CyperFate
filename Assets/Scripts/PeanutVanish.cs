using UnityEngine;
using System.Collections;

public class PeauntVanish : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        // Assuming your Animator component is on the same GameObject
    }

    // This function will be called by an Animation Event
    public IEnumerator OnVanishAnimationComplete()
    {
        yield return new WaitForSeconds(0.92f);
        Debug.Log("Vanish animation has been triggered. Deleting the object.");
        // Add any additional logic before destroying the object if needed
        Destroy(gameObject);
    }

    void Update()
    {
        // Example: Check if the "Vanish" trigger is set in the Animator
        if (animator.GetBool("Vanish"))
        {
            Debug.Log("Delteing");
            // Trigger the Animation Event to delete the object
            StartCoroutine(OnVanishAnimationComplete());
        }
    }
}
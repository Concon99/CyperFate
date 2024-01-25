using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class B2Attack1 : MonoBehaviour
{
    [SerializeField] private PlayerMovement _PlayerMovement;
    private Animator animator;
    private bool isAnimating = false;

    // The created object
    private GameObject createdObject;

    // Function to be called externally to trigger the animation and deletion
    public void B2Attack1Function()
    {
        // Check if an animation is already in progress
        if (!isAnimating)
        {
            // Create the object if not already created
            if (createdObject == null)
            {
                createdObject = Instantiate(gameObject, transform.position, transform.rotation);
                createdObject.transform.SetParent(transform, false); // If it's UI, set the parent to maintain UI scaling

                // Initialize the Animator component
                animator = createdObject.GetComponent<Animator>();

                if (animator == null)
                {
                    Debug.LogError("Animator component not found on GameObject.");
                    return;
                }
            }
            else
            {
                // If the object is already created, reset its state
                createdObject.SetActive(true);
                animator.Rebind();
            }

            // Start the coroutine to handle animation and deletion for the created object
            StartCoroutine(AnimateAndDelete());
        }
    }

    // Coroutine to handle animation and deletion
    private IEnumerator AnimateAndDelete()
    {
        isAnimating = true;

        // Wait for a short delay before showing the object
        yield return new WaitForSeconds(1.0f);

        // Play the animation named "YourAnimationClip"
        PlayAnimation("YourAnimationClip");

        // Wait for the animation to complete (you can adjust the time or use an event)
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Delete the object after the animation
        Destroy(createdObject);

        // Set isAnimating back to false to allow the creation of a new object
        isAnimating = false;
    }

    // Play the specified animation
    private void PlayAnimation(string animationName)
    {
        // Check if the Animator component is available
        if (animator != null)
        {
            // Trigger the specified animation
            animator.SetTrigger(animationName);
        }
        else
        {
            Debug.LogError("Animator component is not available.");
        }
    }
}
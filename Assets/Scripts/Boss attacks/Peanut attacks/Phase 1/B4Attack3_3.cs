using System.Collections;
using UnityEngine;

public class B4Attack3_3 : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 3f; // Time before the bullet is destroyed
    private Transform portalTransform;
    private Rigidbody2D bulletRigidbody;

    

    // Start is called before the first frame update
    void Start()
    {
        portalTransform = GameObject.FindGameObjectWithTag("Portal").transform;

        // Rotate the bullet to match the rotation of the portal
        transform.rotation = portalTransform.rotation * Quaternion.Euler(0, 0, -180);
        // Get the Rigidbody2D component
        bulletRigidbody = GetComponent<Rigidbody2D>();

        StartCoroutine(DestroyAfterLifetime());
    }

    // Update is called once per frame
        void Update()
    {
        if (bulletRigidbody != null && portalTransform != null)
        {
        // Move in the same direction as the portal's forward
        bulletRigidbody.velocity = portalTransform.right * -speed;
        }
    }

    IEnumerator DestroyAfterLifetime()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }


}
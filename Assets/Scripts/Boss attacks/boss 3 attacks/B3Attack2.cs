using System.Collections;
using UnityEngine;

public class B3Attack2 : MonoBehaviour
{
    public Transform playerTransform;
    public float speed = 5f;

    private Vector3 initialPosition;
    private float moveDuration = 3f;

    public Animator _animator;

    void Start()
    {
        initialPosition = transform.position;
    }

    public IEnumerator Attack2()
    {
        _animator.SetInteger("Phase", 2);

        // Move towards the player
        yield return MoveToPosition(playerTransform.position);

        // Move back to the initial position
        yield return MoveToPosition(initialPosition);

        _animator.SetInteger("Phase", 1);
    }

    IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
using UnityEngine;

public class BottomCollisionDetectorScript : MonoBehaviour
{
    private Animator _parentAnimator;

    private void Start()
    {
        _parentAnimator = transform.GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UpdateAnimatorBottomCollision(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UpdateAnimatorBottomCollision(false);
        }
    }

    private void UpdateAnimatorBottomCollision(bool status)
    {
        if (_parentAnimator != null)
        {
            _parentAnimator.SetBool("BottomCollisionDetected", status);
        }
    }
}

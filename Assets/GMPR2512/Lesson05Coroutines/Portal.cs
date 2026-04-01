using UnityEngine;

namespace GMPR2512.Lesson05Coroutines
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] private Portal _pairedPortal;
        [SerializeField] private float _reentryLockSeconds = 0.2f;
        private float _lockedUntilTime;

        void OnTriggerEnter2D(Collider2D collider)
        {
            Rigidbody2D rb = collider.attachedRigidbody;
            if(rb == null || Time.time < _lockedUntilTime)
            {
                return;
            }
            _lockedUntilTime = Time.time + _reentryLockSeconds;
            _pairedPortal._lockedUntilTime = Time.time + _reentryLockSeconds;

            rb.linearVelocity = Vector3.zero;
            rb.position = _pairedPortal.gameObject.transform.position;
        }

    }
}

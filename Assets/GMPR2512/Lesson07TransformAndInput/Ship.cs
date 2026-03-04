using UnityEngine;
using UnityEngine.InputSystem;


namespace GMPR2512.Lesson07TransformAndInput
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 5, _rotationSpeed = 200, _scaleSpeed = 1.2f;
        [SerializeField] private float _minRotation = -25, _maxRotation = 25;
        private InputAction _moveAction, _rotateAction, _scaleAction;

        void Awake()
        {
            _moveAction = InputSystem.actions.FindAction("Player/Move");
            _rotateAction = InputSystem.actions.FindAction("Player/Rotate");
            _scaleAction = InputSystem.actions.FindAction("Player/Scale");
        }

        void Update()
        {
            #region movement
            Vector2 moveDirection = _moveAction.ReadValue<Vector2>();
            moveDirection.y = 0;
            Vector2 translation = moveDirection.normalized * _movementSpeed * Time.deltaTime;
            transform.Translate(translation, Space.World);
            #endregion
            #region rotation
            float rotationValue = _rotateAction.ReadValue<float>() * _rotationSpeed * Time.deltaTime;
            transform.Rotate(0, 0, rotationValue);
            
            //clamp rotation
            Vector3 eulers = transform.eulerAngles;
            // convert to signed range (-180 to 180)
            if(eulers.z > 180)
            {
                eulers.z -= 360;
            }
            eulers.z = Mathf.Clamp(eulers.z, _minRotation, _maxRotation);
            transform.eulerAngles = eulers;
            
            #endregion
            #region scaling

            float scaleValue = _scaleAction.ReadValue<float>() * _scaleSpeed * Time.deltaTime;
            
            transform.localScale += new Vector3(scaleValue, scaleValue, scaleValue);
            Vector3 scale = transform.localScale;
            if(scale.x < 0)
                scale.x = 0;
            if(scale.y < 0)
                scale.y = 0;
            if(scale.z < 0)
                scale.z = 0;
            transform.localScale = scale;
            #endregion
        }
    }
}

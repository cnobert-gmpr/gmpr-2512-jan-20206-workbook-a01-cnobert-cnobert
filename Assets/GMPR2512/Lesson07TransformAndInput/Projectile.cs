using PlasticGui.WorkspaceWindow;
using PlasticPipe.PlasticProtocol.Messages;
using UnityEngine;

namespace GMPR2512.Lesson07TransformAndInput
{
    public class Projectile : MonoBehaviour
    {
        private float _speed = 10;
        private Vector2 _direction = Vector2.up;

        internal Vector2 Direction{ set => _direction = value; }
        internal float Speed { set => _speed = value; }

        void Update()
        {
            transform.Translate(_direction.normalized * _speed * Time.deltaTime, Space.World);
        }
    }
}

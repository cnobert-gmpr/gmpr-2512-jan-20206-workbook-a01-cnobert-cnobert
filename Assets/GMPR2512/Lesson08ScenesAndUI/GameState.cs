using UnityEngine;

namespace GMPR2512.Lesson08ScenesAndUI
{
    [CreateAssetMenu(menuName = "Game State")]
    public class GameState : ScriptableObject
    {
        private int _scoreScene02 = 0;

        public int ScoreScene02 { get => _scoreScene02; set => _scoreScene02 = value; }
    
        private void ResetState()
        {
            _scoreScene02 = 0;
        }

        private void OnEnable() { ResetState(); }
        private void OnDisable() { ResetState();}
    }
}

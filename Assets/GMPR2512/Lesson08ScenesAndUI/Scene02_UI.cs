using UnityEngine;
using UnityEngine.UIElements;

namespace GMPR2512.Lesson08ScenesAndUI
{
    public class Scene02_UI : MonoBehaviour
    {
        [SerializeField] private GameState _gameState;
        private Label _labelScoreScene02;
        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            _labelScoreScene02 = root.Q<Label>("label-score");
        }
        void Update()
        {
            _labelScoreScene02.text = "Score: " + _gameState.ScoreScene02;
        }
    }
}

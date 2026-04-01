using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

namespace GMPR2512.Lesson08ScenesAndUI
{
    public class Scene01_UI : MonoBehaviour
    {
        private Button _buttonToChangeToScene02;
        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            _buttonToChangeToScene02 = root.Q<Button>("btn-start");
            if(_buttonToChangeToScene02 != null)
            {
                _buttonToChangeToScene02.clicked += ChangeToScene02;
            }
        }
        private void OnDisable()
        {
            if(_buttonToChangeToScene02 != null)
            {
                _buttonToChangeToScene02.clicked -= ChangeToScene02;
            }
        }
        private void ChangeToScene02()
        {
            // NOTE: this scene will only successfully open if it is in the scene list,
            // which can be set up in the Unity Editor like:
            // File -> Build Profiles
            SceneManager.LoadScene(2);
        }
    }
}

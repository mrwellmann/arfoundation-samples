using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace UnityEngine.XR.ARFoundation.Samples
{
    public class BackButton : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_BackButton;

        public GameObject backButton
        {
            get => m_BackButton;
            set => m_BackButton = value;
        }

        private void Start()
        {
            if (Application.CanStreamedLevelBeLoaded("Menu"))
                m_BackButton.SetActive(true);
        }

        private void Update()
        {
            if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
                BackButtonPressed();
        }

        public void BackButtonPressed()
        {
            if (Application.CanStreamedLevelBeLoaded("Menu"))
                SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }
}
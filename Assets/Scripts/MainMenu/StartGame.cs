using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private MainMenu _inputActions;

    [SerializeField]
    private string _sceneToLoad;

    private void Awake()
    {
        _inputActions = new MainMenu();

        _inputActions.MainMenuActionMap.AnyKey.performed += ctx =>
        {
            LoadScene();
        };
    }

    private void OnEnable() => _inputActions.Enable();
    private void OnDisable() => _inputActions.Disable();

    private void LoadScene()
    {
        _inputActions.Disable();

        SceneManager.LoadScene(_sceneToLoad);
    }
}

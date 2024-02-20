using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameplayHUD : MonoBehaviour
{
    [SerializeField] private Button _mainMenuButton;

    private SceneLoadMediator _sceneLoader;
    private Wallet _wallet;

    [Inject]
    private void Construct(SceneLoadMediator sceneLoadMediator, LevelLoadingData levelLoadingData, Wallet wallet)
    {
        _sceneLoader = sceneLoadMediator;

        _wallet = wallet;

        Debug.Log($"Level: {levelLoadingData.Level}");
    }

    private void OnEnable()
        => _mainMenuButton.onClick.AddListener(OnMainMenuClick);

    private void OnDisable()
        => _mainMenuButton.onClick.RemoveListener(OnMainMenuClick);

    private void OnMainMenuClick() => _sceneLoader.GoToMainMenu();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            if (_wallet.IsEnough(10))
                _wallet.Spend(10);

        if(Input.GetKeyDown(KeyCode.F))
            _wallet.AddCoins(10);
    }
}

using TMPro;
using UnityEngine;
using Zenject;

public class WalletView : MonoBehaviour
{
    [SerializeField] private TMP_Text _coins;

    private Wallet _wallet;

    [Inject]
    private void Construct(Wallet wallet) => _wallet = wallet;

    private void OnEnable()
    {
        _wallet.CoinsChanged += UpdateValue;

        UpdateValue(_wallet.Coins);
    }

    private void OnDisable()
    {
        _wallet.CoinsChanged -= UpdateValue;
    }

    public void Hide() => gameObject.SetActive(false);
    public void Show() => gameObject.SetActive(true);

    private void UpdateValue(int coins) => _coins.text = coins.ToString();
}

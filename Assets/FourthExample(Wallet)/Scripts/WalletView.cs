using TMPro;
using UnityEngine;
using Zenject;

public class WalletView : MonoBehaviour
{
    [SerializeField] private TMP_Text _value;

    private IReadOnlyWallet _wallet;

    [Inject]
    private void Construct(IReadOnlyWallet wallet) => _wallet = wallet;

    private void OnEnable()
    {
        _wallet.Changed += OnWalletChanged;
        OnWalletChanged(_wallet.Coins);
    }

    private void OnDisable()
    {
        _wallet.Changed -= OnWalletChanged;
    }

    private void OnWalletChanged(int value) => _value.text = value.ToString();
}

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BuyGun : MonoBehaviour
{
    [SerializeField]
    private int _gunCost = 2;
    [SerializeField]
    private InstantiatePoolObject _gunPool;
    [SerializeField]
    private CoinsNumber _coinsNumber;
    [SerializeField]
    private Text _costText;
    [SerializeField]
    private UnityEvent<Transform> _onGunPurchased;
    private void Start()
    {
        _costText.text = _gunCost.ToString();
    }
    public void TryBuyGun()
    {
        if (_coinsNumber.BuyObject(_gunCost))
        {
            _gunPool.InstantiateObject(transform);
            GameObject gunObject = _gunPool.GetCurrentObject();
            _onGunPurchased?.Invoke(gunObject.transform);
        }
    }
}

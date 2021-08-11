using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class ShopTemplate : MonoBehaviour
{
    [SerializeField] private int _price;
    [SerializeField] private Text _buttonText;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private Material _targetMaterial;
    [SerializeField] private SpriteRenderer _thisColor;

    private MoneyDisplay _money;
    private bool _isBought = false;
    private ShopPanel _shop;

    private void Awake()
    {
        _money = FindObjectOfType<MoneyDisplay>();
        _priceText.text = _price.ToString();
        _shop = FindObjectOfType<ShopPanel>();
    }

    public void TryToBuy()
    {
        if (_price <= _money.Money && _isBought == false)
        {
            _money.DecreaseByNumber(_price);
            _isBought = true;
            _shop.AddButton(_buttonText);
            Equip();
        }
        else if (_isBought == true)
        {
            Equip();
        }
    }

    public void Equip()
    {
        _targetMaterial.color = _thisColor.color;
        _shop.FilterButtonNames();
        _buttonText.text = "NOW";
    }
}

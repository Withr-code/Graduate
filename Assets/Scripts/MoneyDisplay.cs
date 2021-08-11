using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]

public class MoneyDisplay : MonoBehaviour
{
    private TMP_Text _text;
    private int _money = 0;

    public int Money => _money;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    public void AddScore()
    {
        _money++;

        _text.text = _money.ToString();
    }

    public void DecreaseByNumber(int number)
    {
        _money -= number;

        _text.text = _money.ToString();
    }
}

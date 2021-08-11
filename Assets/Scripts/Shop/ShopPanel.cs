using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private Volume _postProcessing;
    [SerializeField] private GameObject _canvas;

    private List<Text> _bought = new List<Text>();

    public void Continue()
    {
        ActivateShopPanel(false);
    }

    private void Awake()
    {
        Continue();
    }

    private void OnTriggerEnter(Collider other)
    {
        ActivateShopPanel(true);
    }

    private void ActivateShopPanel(bool isActive)
    {
        _canvas.SetActive(isActive);
        _postProcessing.enabled = !isActive;

        Time.timeScale = System.Convert.ToInt32(!isActive);
    }

    public void FilterButtonNames()
    {
        foreach (var button in _bought)
            button.text = "SET";
    }

    public void AddButton(Text text)
    {
        _bought.Add(text);
    }
}

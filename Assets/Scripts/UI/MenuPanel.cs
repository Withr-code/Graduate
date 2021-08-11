using UnityEngine;
using UnityEngine.Rendering;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private Volume _postProcessing;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private ShopPanel _shopPanel;

    private void Awake()
    {
        Continue();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OnOpenMenu()
    {
        ActivateCanvasGroup(true);
    }

    public void Continue()
    {
        ActivateCanvasGroup(false);
        _shopPanel.Continue();
    }

    private void ActivateCanvasGroup(bool isActive)
    {
        if (isActive == true)
        {
            _postProcessing.enabled = false;
            Time.timeScale = 0;
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }
        else
        {
            _postProcessing.enabled = true;
            Time.timeScale = 1;
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
    }
}

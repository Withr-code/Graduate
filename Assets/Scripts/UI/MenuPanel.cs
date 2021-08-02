using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private PlayerInputHandler _inputHandler;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();

        Continue();
    }

    public void Continue()
    {
        Time.timeScale = 1;
        ActivateCanvasGroup(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OnOpenMenu()
    {
        Time.timeScale = 0;
        ActivateCanvasGroup(true);
    }

    private void ActivateCanvasGroup(bool isActive)
    {
        if (isActive == true)
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }
        else
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
    }
}

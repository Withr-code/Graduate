using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerLooking))]
[RequireComponent(typeof(PlayerShooting))]

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private MenuPanel _menuPanel;
    [SerializeField] private ShopPanel _shopPanel;

    private PlayerShooting _shooting;

    public PlayerInput Input { get; private set; }

    private void Awake()
    {
        Input = new PlayerInput();

        _shooting = GetComponent<PlayerShooting>();

        Input.Player.Shoot.performed += ctx => _shooting.Shoot();

        Input.UI.OpenMenu.started += ctx => _menuPanel.OnOpenMenu();
        Input.UI.Continue.started += ctx => _menuPanel.Continue();
        Input.UI.Quit.performed += ctx => _menuPanel.Quit();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnEnable()
    {
        Input.Enable();
    }

    private void OnDisable()
    {
        Input.Disable();
    }
}

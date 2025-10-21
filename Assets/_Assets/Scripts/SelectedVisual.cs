using UnityEngine;

public class SelectedVisual : MonoBehaviour
{

    [SerializeField] private ChairInteraction chairInteraction;
    [SerializeField] private GameObject visualGameObject;

    private void Start()
    {
        Player.Instance.OnSelectedVisualChanged += Player_OnSelectedVisualChanged;
    }
    private void Player_OnSelectedVisualChanged(object sender, Player.OnSelectedVisualChangedEventArgs e)
    {
        if (e.selectedVisual == chairInteraction)
        {
            Show();
        }
        else {
            Hide();
            
        }
    }

    private void Show()
    {
        visualGameObject.SetActive(true);
    }

    private void Hide()
    {
        visualGameObject.SetActive(false);

    }
}

using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    [SerializeField] private string interactText;

    public void Interact()
    {
        Debug.Log("INTERACT");
        //ChatBubble.Create(transform, new Vector3(-3f, 1.7f, 0f), ChatBubble.Text, "Hewlllo");
    }
    public string GetInteractText()
    {
        return interactText;
    }
}

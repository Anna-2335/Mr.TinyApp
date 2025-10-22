using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class ChatBubble : MonoBehaviour
{
    private SpriteRenderer backgroundSpriteRenderer;
    private SpriteRenderer iconSpriteRenderer;
    private TextMeshPro textMeshPro;



    private void Awake()
    {
        backgroundSpriteRenderer = transform.Find("Background").GetComponent<SpriteRenderer>();
        iconSpriteRenderer = transform.Find("Icon").GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();

    }

    private void Start()
    {
        Setup("Welcome to the Tiny Library!");
    }
    public void Setup(string text)
    {
        textMeshPro.SetText(text);
        textMeshPro.ForceMeshUpdate();
        Vector2 textSize = textMeshPro.GetRenderedValues(false);

        Vector2 padding = new Vector2(10f, 2f);
        backgroundSpriteRenderer.size = textSize + padding;
        StartCoroutine(HideAfterSeconds(4f));

    }

    private IEnumerator HideAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        // Hide this chat bubble
        gameObject.SetActive(false);
        // Optionally, trigger the next chat bubble
        // For example, if you have a ChatManager:
        // ChatManager.Instance.ShowNextBubble();
    }
}
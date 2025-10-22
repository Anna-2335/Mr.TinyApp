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
        backgroundSpriteRenderer= transform.Find("Background").GetComponent<SpriteRenderer>();
        iconSpriteRenderer = transform.Find("Icon").GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();

    }

    private void Start()
    {
        Setup("Welcome to the Tiny Library!");
    }
    private void Setup(string text)
    {
        textMeshPro.SetText (text);
        textMeshPro.ForceMeshUpdate();
        Vector2 textSize= textMeshPro.GetRenderedValues(false);

        Vector2 padding = new Vector2 (10f, 2f);
        backgroundSpriteRenderer.size = textSize + padding;
    }
}

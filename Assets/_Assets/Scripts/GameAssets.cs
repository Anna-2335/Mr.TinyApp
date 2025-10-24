using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {
            if(_i ==null) _i = (Instantiate(Resources.Load<GameAssets>("GameAsset")));
            return _i;
        }
    }

    public Transform pfChatBubble;
}

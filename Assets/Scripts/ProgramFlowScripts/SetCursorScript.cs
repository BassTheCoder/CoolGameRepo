using UnityEngine;

public class SetCursorScript : MonoBehaviour
{
    public Texture2D CrosshairTexture;

    void Start()
    {
        var cursorOffset = new Vector2(CrosshairTexture.width/2, CrosshairTexture.height/2);
        Cursor.SetCursor(CrosshairTexture, cursorOffset, CursorMode.Auto);
    }
}

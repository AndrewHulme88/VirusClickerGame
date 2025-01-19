using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    [SerializeField] Texture2D smallCursor;
    [SerializeField] Texture2D largeCursor;
    [SerializeField] Vector2 cursorHotspot = Vector2.zero;
    [SerializeField] float cursorAnimationDuration = 0.2f;

    void Start()
    {
        Cursor.SetCursor(smallCursor, cursorHotspot, CursorMode.Auto);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ChangeCursorOnClick());
        }
    }

    private System.Collections.IEnumerator ChangeCursorOnClick()
    {
        Cursor.SetCursor(largeCursor, cursorHotspot, CursorMode.Auto);
        yield return new WaitForSeconds(cursorAnimationDuration);
        Cursor.SetCursor(smallCursor, cursorHotspot, CursorMode.Auto);
    }
}

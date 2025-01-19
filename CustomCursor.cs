using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    [SerializeField] Texture2D smallCursor;
    [SerializeField] Texture2D largeCursor;
    [SerializeField] Vector2 cursorHotspot = Vector2.zero;
    [SerializeField] float cursorAnimationDuration = 0.2f;
    [SerializeField] GameObject particlesPrefab;

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
        CreateHitParticles();
        Cursor.SetCursor(largeCursor, cursorHotspot, CursorMode.Auto);
        yield return new WaitForSeconds(cursorAnimationDuration);
        Cursor.SetCursor(smallCursor, cursorHotspot, CursorMode.Auto);
    }

    private void CreateHitParticles()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 1f;
        GameObject newParticles = Instantiate(particlesPrefab, mousePosition, Quaternion.identity);
        Destroy(newParticles, 2f);
    }
}

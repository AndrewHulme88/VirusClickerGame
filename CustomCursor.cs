using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    [SerializeField] Texture2D smallCursor;
    [SerializeField] Texture2D largeCursor;
    [SerializeField] float cursorAnimationDuration = 0.2f;
    [SerializeField] GameObject particlesPrefab;

    void Start()
    {
        SetCursor(smallCursor);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ChangeCursorOnClick());
        }
    }

    private IEnumerator ChangeCursorOnClick()
    {
        CreateHitParticles();
        SetCursor(largeCursor);
        yield return new WaitForSeconds(cursorAnimationDuration);
        SetCursor(smallCursor);
    }

    private void CreateHitParticles()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 1f;
        GameObject newParticles = Instantiate(particlesPrefab, mousePosition, Quaternion.identity);
        Destroy(newParticles, 2f);
    }

    private void SetCursor(Texture2D cursorTexture)
    {
        if (cursorTexture != null)
        {
            Vector2 hotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
            Cursor.SetCursor(cursorTexture, hotspot, CursorMode.ForceSoftware);
        }
    }
}

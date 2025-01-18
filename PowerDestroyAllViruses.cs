using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDestroyAllViruses : MonoBehaviour
{
    private void OnMouseDown()
    {
        DestroyAllViruses(); ;
        Destroy(this.gameObject);
    }

    private void DestroyAllViruses()
    {
        GameObject[] viruses = GameObject.FindGameObjectsWithTag("Virus");
        foreach (GameObject virus in viruses)
        {
            Destroy(virus);
        }
    }
}

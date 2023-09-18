using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepresentacionGrafica 
{
    private GameObject representacionGrafica;

    public RepresentacionGrafica(GameObject rep)
    {
        representacionGrafica = rep;
    }

    public void MoveGraphics(int posX, int posY)
    {
        representacionGrafica.transform.position = new Vector3(posX, representacionGrafica.transform.position.y, posY);

    }

    public void UpdateGraphics(GameObject toActivate)
    {
        representacionGrafica = toActivate;
        representacionGrafica.SetActive(true);
    }

    public void DestroyGraphics()
    {
        GameObject.Destroy(representacionGrafica);
    }
}

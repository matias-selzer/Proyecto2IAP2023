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
        throw new System.NotImplementedException();
    }

    public void UpdateGraphics(GameObject toActivate)
    {
        representacionGrafica = toActivate;
        representacionGrafica.SetActive(true);
    }
}

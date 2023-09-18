using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepGraficaUnica 
{
    private GameObject representacionGrafica;

    public RepGraficaUnica(GameObject rep)
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

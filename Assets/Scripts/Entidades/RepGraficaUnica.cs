using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepGraficaUnica : RepresentacionGrafica
{
    private GameObject representacionGrafica;

    public RepGraficaUnica(GameObject rep)
    {
        representacionGrafica = rep;
    }

    public override void MoveGraphics(int posX, int posY)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateGraphics(GameObject toActivate)
    {
        representacionGrafica = toActivate;
        representacionGrafica.SetActive(true);
    }
}

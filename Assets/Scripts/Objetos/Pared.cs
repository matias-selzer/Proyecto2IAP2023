using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pared : ObjetoAmbiente
{
    public Pared(RepresentacionGrafica rep)
    {
        representacionGrafica = rep;
    }

    public override void SerVisitado(GameManager gameManager)
    {
        gameManager.ColisionConPared();
    }
}

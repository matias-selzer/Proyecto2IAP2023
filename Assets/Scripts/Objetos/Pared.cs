using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pared : ObjetoAmbiente
{
    public Pared(RepresentacionGrafica rep)
    {
        representacionGrafica = rep;
        Costo = 1000;
    }

    public override void Visitar(Visitor v)
    {
        v.Visit(this);
    }

   /* public override void SerVisitado(GameManager gameManager)
    {
        gameManager.ColisionConPared();
    }*/
}

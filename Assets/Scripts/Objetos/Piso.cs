using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piso : ObjetoAmbiente
{
    public Piso(RepresentacionGrafica rep)
    {
        representacionGrafica = rep;
    }

    /*public override void SerVisitado(GameManager gameManager)
    {
        //Debug.Log("Me visitan - soy el Piso");
    }*/

    public override void Visitar(Visitor v)
    {
        v.Visit(this);
    }
}

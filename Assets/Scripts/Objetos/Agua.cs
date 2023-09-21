using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agua : ObjetoAmbiente
{
    public Agua(RepresentacionGrafica rep)
    {
        representacionGrafica = rep;
        Costo = 50;
    }

    public override void Visitar(Visitor v)
    {
        //throw new System.NotImplementedException();
    }

    
}

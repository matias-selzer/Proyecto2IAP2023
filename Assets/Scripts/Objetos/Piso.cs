using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piso : ObjetoAmbiente
{
    public Piso(RepresentacionGrafica rep)
    {
        representacionGrafica = rep;
    }

    public override void SerVisitado()
    {
        Debug.Log("Me visitan - soy el Piso");
    }
}

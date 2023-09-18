using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entidad 
{
    protected int puntos,tiempoDeVida;
    protected RepresentacionGrafica representacionGrafica;
    protected Node nodoActual;

    public void SetNode(Node n)
    {
        nodoActual = n;
    }

    public virtual void SerVisitado()
    {
        Debug.Log("Me visitan - soy una Entidad");
    }
}

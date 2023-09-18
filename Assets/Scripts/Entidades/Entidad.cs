using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entidad 
{
    protected int puntos,tiempoDeVida;
    protected RepresentacionGrafica representacionGrafica;
    private Node nodoActual;

    public Node NodoActual { get => nodoActual; set => nodoActual = value; }

    public virtual void SerVisitado()
    {
        Debug.Log("Me visitan - soy una Entidad");
    }
}

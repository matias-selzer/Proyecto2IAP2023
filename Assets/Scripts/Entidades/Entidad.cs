using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entidad 
{
    protected int puntos,tiempoDeVida;
    protected RepresentacionGrafica representacionGrafica;
    private Node nodoActual;
    private int costo;

    public Node NodoActual { get => nodoActual; set => nodoActual = value; }
    public int Costo { get => costo; set => costo = value; }

    public virtual void UpdateRepresentacionGrafica()
    {
        representacionGrafica.MoveGraphics(nodoActual.PosX, nodoActual.PosY);
    }

    /*public virtual void SerVisitado(GameManager gameManager)
    {
        Debug.Log("Me visitan - soy una Entidad");
    }*/

    public abstract void Visitar(Visitor v); //debe ser implementado por todos los hijos
}

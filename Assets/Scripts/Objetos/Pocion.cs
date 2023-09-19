using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocion : Tesoro
{
    public Pocion(RepresentacionGrafica rep)
    {
        representacionGrafica = rep;
    }

    public override void Visitar(Visitor v)
    {
        representacionGrafica.DestroyGraphics();
        NodoActual.RemoveEntity(this);
        v.Visit(this);
    }

    /*public override void SerVisitado(GameManager gameManager)
    {
        representacionGrafica.DestroyGraphics();
        NodoActual.RemoveEntity(this);
        gameManager.AgarrarPocion();
    }*/


}

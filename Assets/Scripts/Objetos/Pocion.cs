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
        
        v.Visit(this);
        representacionGrafica.DestroyGraphics();
        NodoActual.RemoveEntity(this);
    }

    /*public override void SerVisitado(GameManager gameManager)
    {
        representacionGrafica.DestroyGraphics();
        NodoActual.RemoveEntity(this);
        gameManager.AgarrarPocion();
    }*/


}

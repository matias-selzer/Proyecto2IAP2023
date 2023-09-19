using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{
    private int posX, posY;
    private List<Entidad> entidades;

    public Node(int x,int y)
    {
        PosX = x;
        PosY = y;
        entidades = new List<Entidad>();
    }

    public int PosX { get => posX; set => posX = value; }
    public int PosY { get => posY; set => posY = value; }

    public void RemoveEntity(Entidad entidad)
    {
        entidades.Remove(entidad);
    }

    public void AddEntity(Entidad entidad)
    {
        entidades.Add(entidad);
        //entidad.NodoActual = this;
    }

    public void SerVisitado(GameManager gameManager)
    {
        try
        {
            foreach (Entidad e in entidades)
            {
                e.Visitar(gameManager);
            }
        }
        catch (Exception e)
        {

        }
        
    }

    public int CantidadDeEntidades()
    {
        return entidades.Count;
    }
    
    //esto no debería estar
    public int CostoTotal()
    {
        int costoTotal = 0;
        foreach(Entidad e in entidades)
        {
            costoTotal += e.Costo;
        }
        return costoTotal;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{
    private int posX, posY;
    private List<Node> vecinos;
    private int costo;

    public Node(int x,int y,int c)
    {
        posX = x;
        posY = y;
        costo = c;
        vecinos = new List<Node>();
    }

    public void AddVecino(Node n)
    {
        vecinos.Add(n);
    }

    public int GetCantidadVecinos()
    {
        return vecinos.Count;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teclado : NoArtificial
{
    public List<Node> CalcularMovimiento(List<Node> conocimiento, Node nodoActual)
    {
        List<Node> camino = new List<Node>();
        if (Input.GetKey(KeyCode.D))
        {
            camino.Add(BuscarNodoAbajo(conocimiento, nodoActual));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            camino.Add(BuscarNodoArriba(conocimiento, nodoActual));
        }
        else if (Input.GetKey(KeyCode.W))
        {
            camino.Add(BuscarNodoIzquierda(conocimiento, nodoActual));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            camino.Add(BuscarNodoDerecha(conocimiento, nodoActual));
        }
        return camino;
    }

    private Node BuscarNodoDerecha(List<Node> conocimiento, Node nodoActual)
    {
        Node nuevoNodo = conocimiento[0];
        foreach(Node n in conocimiento)
        {
            if(n.PosX==nodoActual.PosX+1 && n.PosY == nodoActual.PosY)
            {
                nuevoNodo = n;
            }
        }
        return nuevoNodo;
    }

    private Node BuscarNodoIzquierda(List<Node> conocimiento, Node nodoActual)
    {
        Node nuevoNodo = conocimiento[0];
        foreach (Node n in conocimiento)
        {
            if (n.PosX == nodoActual.PosX - 1 && n.PosY == nodoActual.PosY)
            {
                nuevoNodo = n;
            }
        }
        return nuevoNodo;
    }

    private Node BuscarNodoArriba(List<Node> conocimiento, Node nodoActual)
    {
        Node nuevoNodo = conocimiento[0];
        foreach (Node n in conocimiento)
        {
            if (n.PosX == nodoActual.PosX && n.PosY == nodoActual.PosY-1)
            {
                nuevoNodo = n;
            }
        }
        return nuevoNodo;
    }

    private Node BuscarNodoAbajo(List<Node> conocimiento, Node nodoActual)
    {
        Node nuevoNodo = conocimiento[0];
        foreach (Node n in conocimiento)
        {
            if (n.PosX == nodoActual.PosX && n.PosY == nodoActual.PosY + 1)
            {
                nuevoNodo = n;
            }
        }
        return nuevoNodo;
    }
}

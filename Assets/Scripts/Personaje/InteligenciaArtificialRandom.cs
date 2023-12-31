using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class InteligenciaArtificialRandom : Artificial
{
    public override List<Node> CalcularMovimiento(List<Node> conocimiento, List<Node> objetivos, Node nodoActual)
    {
        List<Node> camino = new List<Node>();

        List<Node> vecinos = ObtenerNodosVecinos(conocimiento, nodoActual);

        int r = Random.Range(0, vecinos.Count);

        camino.Add(vecinos[r]);
        return camino;
    }

    private List<Node> VecinosMenosCostosos(List<Node> vecinos)
    {
        List<Node> nodosMenosCostosos = new List<Node>();
        foreach (Node n in vecinos)
        {
            if (n.CostoTotal() < 1000)
            {
                nodosMenosCostosos.Add(n);
            }
        }
        return nodosMenosCostosos;
    }

    private Node ObtenerMejorVecino(Node mejorObjetivo, List<Node> vecinos)
    {
        Node mejorVecino = vecinos[0];
        foreach (Node n in vecinos)
        {
            if (Distance(n, mejorObjetivo) < Distance(mejorVecino, mejorObjetivo))
            {
                mejorVecino = n;
            }
        }
        return mejorVecino;
    }

    private Node ObtenerMejorObjetivo(List<Node> objetivos, Node nodoActual)
    {
        Node mejorObjetivo = objetivos[0];
        foreach (Node n in objetivos)
        {
            if (Distance(n, nodoActual) < Distance(mejorObjetivo, nodoActual))
            {
                mejorObjetivo = n;
            }
        }
        return mejorObjetivo;
    }

    private double Distance(Node a, Node b)
    {
        return Vector2.Distance(new Vector2(a.PosX, a.PosY), new Vector2(b.PosX, b.PosY));
    }

    private List<Node> ObtenerNodosVecinos(List<Node> conocimiento, Node nodoActual)
    {
        List<Node> vecinos = new List<Node>();
        foreach (Node n in conocimiento)
        {
            if (CalcularDistanciaManhattan(n.PosX, n.PosY, nodoActual.PosX, nodoActual.PosY) <= 1)
            {
                if(n.CostoTotal()<1000)
                    vecinos.Add(n);
            }
        }
        return vecinos;
    }

    private int CalcularDistanciaManhattan(int x1, int y1, int x2, int y2)
    {
        int diferenciaX = Math.Abs(x1 - x2);
        int diferenciaY = Math.Abs(y1 - y2);

        return diferenciaX + diferenciaY;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


public class InteligenciaAstar : Artificial
{

    public override List<Node> CalcularMovimiento(List<Node> conocimiento, List<Node> objetivos, Node nodoActual)
    {

        List<Node> caminoObtenido = Aestrella(conocimiento, objetivos, nodoActual);

        Debug.Log("Debug A*");
        foreach(Node n in caminoObtenido)
        {
            Debug.Log(n.PosX + " " + n.PosY);
        }
        
        return caminoObtenido;
    }
    
    private List<Node> Aestrella(List<Node> conocimiento, List<Node> objetivos, Node nodoInicial)
    {
        List<Node> frontera = new List<Node>();
        frontera.Add(nodoInicial);
        Dictionary<Node, Node> parents = new Dictionary<Node, Node>();
        parents.Add(nodoInicial, null);

        List<Node> caminoObtenido = buscarAstar(conocimiento, objetivos, nodoInicial, frontera, parents);

        return caminoObtenido;
    }

    
    private List<Node> buscarAstar(List<Node> conocimiento, List<Node> objetivos, Node nodoInicial, List<Node> frontera, Dictionary<Node, Node> parents)
    {

        Node nodoSeleccionado = SeleccionarNodoDeFrontera(frontera);

        if (objetivos.Contains(nodoSeleccionado))
        {
            // Caso base: nodoActual es un nodo meta. Generar camino

            return ReconstruirCamino(parents, nodoSeleccionado);
        }
        else
        {
            // Caso recursivo: obtener vecinos de nodoActual, agregarlos a la frontera ordenados por F(n)

            frontera.Remove(nodoSeleccionado);

            List<Node> vecinos = ObtenerNodosVecinos(conocimiento, nodoSeleccionado, parents);

            AgregarVecinosAFrontera(frontera, vecinos, objetivos, nodoSeleccionado, parents);

            return buscarAstar(conocimiento, objetivos, nodoInicial, frontera, parents);

        }
    }

    private List<Node> ReconstruirCamino(Dictionary<Node, Node> parents, Node meta)
    {
        var path = new List<Node>();
        Node current = meta;
        
        path.Add(meta);

        while (parents.ContainsKey(current))
        {
            current = parents[current];
            path.Insert(0, current);
        }
        return path;
    }

    private Node SeleccionarNodoDeFrontera(List<Node> frontera)
    {
        return frontera[0];
    }

    private List<Node> ObtenerNodosVecinos(List<Node> conocimiento, Node nodoActual, Dictionary<Node, Node> parents)
    {
        List<Node> vecinos = new List<Node>();
        foreach (Node n in conocimiento)
        {
            if (CalcularDistanciaManhattan(n.PosX, n.PosY, nodoActual.PosX, nodoActual.PosY) <= 1)
            {
                vecinos.Add(n);
                //parents.Add(n, nodoActual);
            }
        }
        return vecinos;
    }

    private void AgregarVecinosAFrontera(List<Node> frontera, List<Node> vecinos, List<Node> objetivos, Node nodoActual, Dictionary<Node, Node> parents)
    {

        List<Node> nuevaFrontera = frontera;

        foreach (Node v in vecinos)
        {
            int posicionAInsertar = CalcularPosicionVecino(frontera, v, objetivos);

            nuevaFrontera.Insert(posicionAInsertar, v);

            if (!parents.ContainsKey(v))
            {
                parents.Add(nodoActual, v);
            } // Aca hay un error...
        }
        
    }

    private int CalcularPosicionVecino(List<Node> frontera, Node vecino, List<Node> objetivos)
    {
        int hv = CalcularH(vecino, objetivos);

        for(int i = 0; i < frontera.Count; i++)
        {
            int hf = CalcularH(frontera[i], objetivos);
            if(hv > hf)
            {
                return i;
            }
        }

        return frontera.Count;
    }


    private int CalcularH(Node vecino, List<Node> objetivos)
    {
        List<int> hs = new List<int>();
        foreach(Node objetivo in objetivos)
        {
            hs.Add(CalcularDistanciaManhattan(vecino.PosX, vecino.PosY, objetivo.PosX, objetivo.PosY));
        }

        return hs.Min();
    }


    private int CalcularDistanciaManhattan(int x1, int y1, int x2, int y2)
    {
        int diferenciaX = Math.Abs(x1 - x2);
        int diferenciaY = Math.Abs(y1 - y2);

        return diferenciaX + diferenciaY;
    }
    
}

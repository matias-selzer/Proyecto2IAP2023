using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa 
{
    private Node[,] grilla;

    public Mapa(int tama�oX, int tama�oY)
    {
        grilla = new Node[tama�oX, tama�oY];
        Debug.Log("Tama�o X: " + tama�oX);
        Debug.Log("Tama�o Y: " + tama�oY);
    }

    public void AddNode(Node n,int x,int y)
    {
        grilla[x, y] = n;
    }

    public int ObtenerTama�oX()
    {
        return grilla.GetLength(0);
    }

    public int ObtenerTama�oY()
    {
        return grilla.GetLength(1);
    }

    public void AsignarVecinos()
    {
        for(int i = 0; i< ObtenerTama�oX(); i++)
        {
            for(int j = 0; j < ObtenerTama�oY(); j++)
            {
                Node nodoActual = grilla[i, j];
                for(int h = i - 1; h <= i + 1; h++)
                {
                    for(int k = j - 1; k <= j + 1; k++)
                    {
                        if(DentroDeLasFilas(h) && DentroDeLasColumnas(k) && NodoDistinto(i,j,h,k))
                        {
                            //Debug.Log("i: " + i + " - j: " + j);
                            //Debug.Log("     h: " + h + " - k: " + k);
                            //Debug.Log(grilla[h, k] == null);
                            //nodoActual.AddVecino(grilla[h, k]);
                        }
                    }
                }
            }
        }
    }

    public bool DentroDeLasFilas(int h)
    {
        return h > 0 && h < ObtenerTama�oX();
    }

    public bool DentroDeLasColumnas(int k)
    {
        return k > 0 && k < ObtenerTama�oY();
    }

    public bool NodoDistinto(int i, int j, int h, int k)
    {
        return !(h == i && k == j);
    }

}

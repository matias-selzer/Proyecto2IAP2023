using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa 
{
    private Node[,] grilla;

    public Mapa(int tamañoX, int tamañoY)
    {
        grilla = new Node[tamañoX, tamañoY];
        Debug.Log("Tamaño X: " + tamañoX);
        Debug.Log("Tamaño Y: " + tamañoY);
    }

    public void AddNode(Node n,int x,int y)
    {
        grilla[x, y] = n;
    }

    public int ObtenerTamañoX()
    {
        return grilla.GetLength(0);
    }

    public int ObtenerTamañoY()
    {
        return grilla.GetLength(1);
    }

    public void AsignarVecinos()
    {
        for(int i = 0; i< ObtenerTamañoX(); i++)
        {
            for(int j = 0; j < ObtenerTamañoY(); j++)
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
        return h > 0 && h < ObtenerTamañoX();
    }

    public bool DentroDeLasColumnas(int k)
    {
        return k > 0 && k < ObtenerTamañoY();
    }

    public bool NodoDistinto(int i, int j, int h, int k)
    {
        return !(h == i && k == j);
    }

}

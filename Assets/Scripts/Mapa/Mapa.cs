using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa 
{
    private Node[,] grilla;
    private Personaje personaje;

    public Personaje Personaje { get => personaje; set => personaje = value; }

    public Mapa(int tamañoX, int tamañoY)
    {
        grilla = new Node[tamañoX, tamañoY];
        Debug.Log("Tamaño X: " + tamañoX);
        Debug.Log("Tamaño Y: " + tamañoY);
    }

    public void SetPersonaje(Personaje p)
    {
        Personaje = p;
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

    public void MoverPersonajeDerecha()
    {
        if (personaje.PosX < ObtenerTamañoX() - 1)
        {
            personaje.PosX++;
            VisitarNodo();
        }
    }
    public void MoverPersonajeIzquierda()
    {
        if (personaje.PosX > 0)
        {
            personaje.PosX--;
            VisitarNodo();
        }
    }
    public void MoverPersonajeArriba()
    {
        if (personaje.PosY > 0)
        {
            personaje.PosY--;
            VisitarNodo();
        }
    }
    public void MoverPersonajeAbajo()
    {
        if (personaje.PosY < ObtenerTamañoY() - 1)
        {
            personaje.PosY++;
            VisitarNodo();
        }
    }

    public void VisitarNodo()
    {
        int posX = personaje.PosY;
        int posY = personaje.PosX;

        Node nodoActual = grilla[posX, posY];
        nodoActual.SerVisitado();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa 
{
    private Node[,] mapa;

    
    public Mapa(int tama�oX, int tama�oY)
    {
        mapa = new Node[tama�oX, tama�oY];
        Debug.Log("Tama�o X: " + tama�oX);
        Debug.Log("Tama�o Y: " + tama�oY);
    }

    public Node ObtenerNodo(int posX,int posY)
    {
        return mapa[posX, posY];
    }

    public void AddNode(Node n,int x,int y)
    {
        mapa[x, y] = n;
    }

    public int ObtenerTama�oX()
    {
        return mapa.GetLength(0);
    }

    public int ObtenerTama�oY()
    {
        return mapa.GetLength(1);
    }
    /*
    public void MoverPersonajeDerecha()
    {
        if (personaje.PosX < ObtenerTama�oX() - 1)
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
        if (personaje.PosY < ObtenerTama�oY() - 1)
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
    }*/

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

    public void AddEntity(int posX,int posY, Entidad e)
    {
        mapa[posX, posY].AddEntity(e);
    }

}

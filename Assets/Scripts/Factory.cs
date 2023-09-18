using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [Serializable]
    public struct ObjetosDelJuego
    {
        public char code;
        public float alturaInicial;
        public int costo;
        public GameObject objectPrefab;
    }

    public ObjetosDelJuego[] objetosDelJuego;

    public float GetAltura(char c)
    {
        float altura = 0;
        for (int i = 0; i < objetosDelJuego.Length; i++)
        {
            if (c == objetosDelJuego[i].code)
            {
                altura = objetosDelJuego[i].alturaInicial;
            }
        }
        return altura;
    }
    public int GetCosto(char c)
    {
        int costo = 0;
        for (int i = 0; i < objetosDelJuego.Length; i++)
        {
            if (c == objetosDelJuego[i].code)
            {
                costo = objetosDelJuego[i].costo;
            }
        }
        return costo;
    }


    public GameObject GetPrefab(char c)
    {
        GameObject prefab = objetosDelJuego[0].objectPrefab;
        for (int i = 0; i < objetosDelJuego.Length; i++)
        {
            if (c == objetosDelJuego[i].code)
            {
                prefab = objetosDelJuego[i].objectPrefab;
            }
        }
        return prefab;
    }

    public Entidad CreateEntity(char objectCode, int posx,int posy)
    {
        Entidad nuevaEntidad;

        float alturaInicial = GetAltura(objectCode);
        GameObject objectPrefab = GetPrefab(objectCode);
        int costo = GetCosto(objectCode);

        GameObject instancia = Instantiate(objectPrefab, new Vector3(posx, alturaInicial, posy), Quaternion.identity);
        RepresentacionGrafica repGrafica = new RepresentacionGrafica(instancia);

        nuevaEntidad = new Piso(repGrafica);
        
        if (objectCode == '1')
        {
            nuevaEntidad = new Pared(repGrafica);
        }
        else if (objectCode == '2')
        {
            nuevaEntidad = new Pocion(repGrafica);
        }
        else if (objectCode == '3')
        {
            nuevaEntidad = new Pocion(repGrafica);
        }


        return nuevaEntidad;
    }
}

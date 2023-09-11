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
}

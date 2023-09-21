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

    public List<Entidad> CreateEntities(char objectCode, int posx,int posy)
    {
        List<Entidad> entities = new List<Entidad>();
        entities.Add(CreateBase(posx, posy));

        if (objectCode != '0')
        {
            float alturaInicial = GetAltura(objectCode);
            GameObject objectPrefab = GetPrefab(objectCode);
            int costo = GetCosto(objectCode);

            GameObject instancia = Instantiate(objectPrefab, new Vector3(posx, alturaInicial, posy), Quaternion.identity);
            RepresentacionGrafica repGrafica = new RepresentacionGrafica(instancia);

            if (objectCode == '1')
            {
                entities.Add(new Pared(repGrafica));
            }
            else if (objectCode == '2')
            {
                entities.Add(new Pocion(repGrafica));
            }
            else if (objectCode == '3')
            {
                entities.Add(new Agua(repGrafica));
            }

        }

        return entities;
    }

    public Entidad CreateBase(int posx, int posy)
    {
        Entidad nuevaEntidad;

        float alturaInicial = GetAltura('0');
        GameObject objectPrefab = GetPrefab('0');
        int costo = GetCosto('0');

        GameObject instancia = Instantiate(objectPrefab, new Vector3(posx, alturaInicial, posy), Quaternion.identity);
        RepresentacionGrafica repGrafica = new RepresentacionGrafica(instancia);

        nuevaEntidad = new Piso(repGrafica);

      

        return nuevaEntidad;
    }

    public Entidad CreatePocion(int posx, int posy)
    {
        Entidad nuevaEntidad;

        float alturaInicial = GetAltura('2');
        GameObject objectPrefab = GetPrefab('2');
        int costo = GetCosto('2');

        GameObject instancia = Instantiate(objectPrefab, new Vector3(posx, alturaInicial, posy), Quaternion.identity);
        RepresentacionGrafica repGrafica = new RepresentacionGrafica(instancia);

        nuevaEntidad = new Pocion(repGrafica);

        return nuevaEntidad;
    }
}

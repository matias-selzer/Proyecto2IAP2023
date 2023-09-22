using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorDePersonaje : MonoBehaviour
{
    public GameObject representacionGraficaPrefab;

    public Character CrearPersonaje(int posX,int posY)
    {
        //Inteligencia i = new Teclado();
        //Inteligencia i = new InteligenciaArtificialObjetivoMasCercano();
        Inteligencia i = new InteligenciaArtificialRandom();
        GameObject representacionGraficaPersonaje = Instantiate(representacionGraficaPrefab, new Vector3(posX, 0, posY), representacionGraficaPrefab.transform.rotation) as GameObject;
        RepresentacionGrafica r = new RepresentacionGrafica(representacionGraficaPersonaje);
        Character p = new Character(i, r);
        return p;
    }

}

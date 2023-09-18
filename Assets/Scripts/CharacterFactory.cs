using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFactory : MonoBehaviour
{
    public GameObject representacionGraficaPrefab;

    public Personaje CrearPersonaje(int posX,int posY)
    {
        Inteligencia i = new Teclado();
        GameObject representacionGraficaPersonaje = Instantiate(representacionGraficaPrefab, new Vector3(posX, 0, posY), Quaternion.identity) as GameObject;
        RepresentacionGrafica r = new RepresentacionGrafica(representacionGraficaPersonaje);
        Personaje p = new Personaje(i, r);
        return p;
    }

    private void MoverPersonajeInicial(GameObject p)
    {
        p.transform.position=(new Vector3(3, 0, 3));
    }
}

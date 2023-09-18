using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFactory : MonoBehaviour
{
    public GameObject repLeft, repRight, repUp, repDown;

    public Personaje CrearPersonaje()
    {
        Inteligencia i = new Teclado();
        GameObject up = Instantiate(repUp) as GameObject;
        GameObject down = Instantiate(repDown) as GameObject;
        GameObject left = Instantiate(repLeft) as GameObject;
        GameObject right = Instantiate(repRight) as GameObject;
        MoverPersonajeInicial(up);
        MoverPersonajeInicial(down);
        MoverPersonajeInicial(left);
        MoverPersonajeInicial(right);
        up.SetActive(false);
        right.SetActive(false);
        left.SetActive(false);
        RepresentacionGrafica r = new RepGraficaMultiple(up,down,left,right);
        Personaje p = new Personaje(i, r);
        return p;
    }

    private void MoverPersonajeInicial(GameObject p)
    {
        p.transform.position=(new Vector3(3, 0, 3));
    }
}

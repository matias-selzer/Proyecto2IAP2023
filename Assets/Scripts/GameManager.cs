using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pared, piso, caja, jarron,personaje;
    //public GameObject camara;
    public Factory factory;

    private Mapa grilla;
    private Personaje personajeActual;

    // Start is called before the first frame update
    void Start()
    {
        ReadMap();
        AsignarVecinos();
        CrearPersonaje(3,3); //hallar lugar libre
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void ReadMap()
    {
        string textFile = Resources.Load("Mapa1").ToString();
        string[] lineas = textFile.Split("\n");

        int tama�ox = lineas.Length;
        int tama�oy = lineas[0].ToCharArray().Length-1;

        CrearGrilla(tama�ox, tama�oy);

        for (int i = 0; i < tama�ox; i++)
        {
            for (int j = 0; j < tama�oy; j++)
            {
                char objectCode = lineas[i].ToCharArray()[j];
                float alturaInicial = factory.GetAltura(objectCode);
                GameObject objectPrefab = factory.GetPrefab(objectCode);
                int costo = factory.GetCosto(objectCode);

                GameObject nuevoObjecto = Instantiate(objectPrefab, new Vector3(i, alturaInicial, j), Quaternion.identity) as GameObject;
                Node nuevoNodo = new Node(i, j);
                //crear objeto ambiente con costo y agregarselo al nodo
                grilla.AddNode(nuevoNodo, i, j);

            }
        }
    }

    private void CrearGrilla(int tama�ox, int tama�oy)
    {
        grilla = new Mapa(tama�ox, tama�oy);
    }

    private void AsignarVecinos()
    {
        grilla.AsignarVecinos();
    }

 
    private void CrearPersonaje(int posX,int posY)
    {
        GameObject personajeGrafico = Instantiate(personaje) as GameObject;
        personajeActual = personajeGrafico.GetComponent<Personaje>();
        personajeActual.Mover(posX, posY);
    }
}

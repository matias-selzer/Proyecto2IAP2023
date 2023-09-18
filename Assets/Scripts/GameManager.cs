using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public GameObject camara;
    public Factory factory;

    private Mapa grilla;

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
        grilla.Personaje.CalcularMomiviento();
    }


    private void ReadMap()
    {
        string textFile = Resources.Load("Mapa1").ToString();
        string[] lineas = textFile.Split("\n");

        int tamañox = lineas.Length;
        int tamañoy = lineas[0].ToCharArray().Length-1;

        CrearGrilla(tamañox, tamañoy);

        for (int i = 0; i < tamañox; i++)
        {
            for (int j = 0; j < tamañoy; j++)
            {
                char objectCode = lineas[i].ToCharArray()[j];

                Entidad nuevaEntidad=factory.CreateEntity(objectCode, i, j);
                

                //GameObject nuevoObjecto = Instantiate(objectPrefab, new Vector3(i, alturaInicial, j), Quaternion.identity) as GameObject;
                Node nuevoNodo = new Node(i, j);
                nuevoNodo.AddEntity(nuevaEntidad);
                //crear objeto ambiente con costo y agregarselo al nodo
                grilla.AddNode(nuevoNodo, i, j);

            }
        }
    }

    private void CrearGrilla(int tamañox, int tamañoy)
    {
        grilla = new Mapa(tamañox, tamañoy);
    }

    private void AsignarVecinos()
    {
        grilla.AsignarVecinos();
    }

 
    private void CrearPersonaje(int posX,int posY)
    {
        grilla.Personaje= GetComponent<CharacterFactory>().CrearPersonaje();
        grilla.Personaje.PosX = posX;
        grilla.Personaje.PosY = posY;
        grilla.Personaje.Mapa = grilla;
    }
}

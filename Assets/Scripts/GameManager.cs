using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public GameObject camara;
    public Factory factory;

    private Mapa grilla;
    private Personaje personaje;

    // Start is called before the first frame update
    void Start()
    {
        ReadMap();
       // AsignarVecinos();
        CrearPersonaje(3,3); //hallar lugar libre
        InvokeRepeating("MoverPersonaje", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void MoverPersonaje()
    {
        personaje.ActualizarConocimiento(ObtenerContexto(personaje.NodoActual.PosX,personaje.NodoActual.PosY,5));
        personaje.Mover();
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

    /*private void AsignarVecinos()
    {
        grilla.AsignarVecinos();
    }*/

 
    private void CrearPersonaje(int posX,int posY)
    {
        personaje= GetComponent<CharacterFactory>().CrearPersonaje(posX,posY);
        personaje.ActualizarConocimiento(ObtenerContexto(posX,posY,5));
        grilla.AddEntity(posX, posY, personaje);
    }

    private List<Node> ObtenerContexto(int posX,int posY, int distancia)
    {
        List<Node> contexto = new List<Node>();
        for (int i = posX - distancia / 2; i < posX + distancia / 2; i++)
        {
            if (grilla.DentroDeLasFilas(i))
            {
                for (int j = posY - distancia / 2; j < posY + distancia / 2; j++)
                {
                    if (grilla.DentroDeLasColumnas(j))
                    {
                        contexto.Add(grilla.ObtenerNodo(i, j));
                    }
                }
            }
        }
        return contexto;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour,Visitor
{
    //public GameObject camara;
    public Factory factory;

    public TMP_Text textPuntos;
    private int puntos = 0;

    private Mapa grilla;
    private Character personaje;

    private Node nodoAnterior;
    private List<Node> objetivos;

    // Start is called before the first frame update
    void Start()
    {
        objetivos = new List<Node>();
        ReadMap();
       // AsignarVecinos();
        CrearPersonaje(3,3); //hallar lugar libre
        InvokeRepeating("MoverPersonaje", 0, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CrearNuevaPocion();
        }
    }

    private void CrearNuevaPocion()
    {
        Node nuevoObjeto = grilla.ObtenerNodoDisponible();
        Entidad nuevaPocion = factory.CreatePocion(nuevoObjeto.PosX, nuevoObjeto.PosY);
        nuevoObjeto.AddEntity(nuevaPocion);
        nuevaPocion.NodoActual = nuevoObjeto;

        objetivos.Add(nuevoObjeto);
    }

    public void MoverPersonaje()
    {
        personaje.ActualizarConocimiento(ObtenerContexto(personaje.NodoActual.PosX,personaje.NodoActual.PosY,5));
        personaje.Mover(this, objetivos);
    }

    public void GameOver()
    {
        Debug.Log("GameOver");
    }


    private void ReadMap()
    {
        string textFile = Resources.Load("Mapa2").ToString();
        string[] lineas = textFile.Split("\n");

        int tamañox = lineas.Length;
        int tamañoy = lineas[0].ToCharArray().Length-1;

        CrearGrilla(tamañox, tamañoy);

        for (int i = 0; i < tamañox; i++)
        {
            for (int j = 0; j < tamañoy; j++)
            {
                char objectCode = lineas[i].ToCharArray()[j];

                List<Entidad> nuevasEntidades=factory.CreateEntities(objectCode, i, j);
 
                Node nuevoNodo = new Node(i, j);

                foreach(Entidad e in nuevasEntidades)
                {
                    nuevoNodo.AddEntity(e);
                    e.NodoActual = nuevoNodo;
                }
               
                
                //crear objeto ambiente con costo y agregarselo al nodo
                grilla.AddNode(nuevoNodo, i, j);

            }
        }
    }

    public void AgregarNodoObjetivo(Node n)
    {
        objetivos.Add(n);
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
        personaje.ActualizarConocimiento(ObtenerContexto(posX,posY,20));
        grilla.AddEntity(posX, posY, personaje);
        personaje.NodoActual = grilla.ObtenerNodo(posX, posY);
    }

    private List<Node> ObtenerContexto(int posX,int posY, int distancia)
    {
        List<Node> contexto = new List<Node>(); //la distancia no funciona
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


    public void MoverPersonajeDeNodo(Node nodoSiguiente)
    {
        nodoAnterior = personaje.NodoActual;
        personaje.NodoActual.RemoveEntity(personaje);
        personaje.NodoActual = nodoSiguiente;
        nodoSiguiente.AddEntity(personaje);
        personaje.UpdateRepresentacionGrafica();
        nodoSiguiente.SerVisitado(this);
    }

    private void VolverPersonaje()
    {
        personaje.NodoActual.RemoveEntity(personaje);
        personaje.NodoActual = nodoAnterior;
        nodoAnterior.AddEntity(personaje);
        personaje.UpdateRepresentacionGrafica();
    }

    /*public void ColisionConPared()
    {
        VolverPersonaje();
    }


    public void AgarrarPocion()
    {
        //sumar puntos o lo que sea
        Debug.Log("Agarre una poción");
    }*/

    public void Visit(Pared p)
    {
        VolverPersonaje();
    }

    public void Visit(Piso p)
    {
        //throw new System.NotImplementedException();
    }

    public void Visit(Pocion p)
    {
        objetivos.Remove(p.NodoActual);
        puntos += 10;
        textPuntos.text = "Puntos\n"+puntos + "";
    }

    public void Visit(Character p)
    {
        //throw new System.NotImplementedException();
    }
}

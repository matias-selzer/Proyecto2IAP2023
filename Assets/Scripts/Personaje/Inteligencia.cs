using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Inteligencia 
{
    public List<Node> CalcularMovimiento(List<Node> conocimiento, List<Node> objetivos, Node nodoActual);
}

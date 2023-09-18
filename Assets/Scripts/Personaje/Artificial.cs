using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Artificial : Inteligencia
{
    public abstract List<Node> CalcularMovimiento(List<Node> conocimiento, List<Node> objetivos, Node nodoActual);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Visitor
{
    public void Visit(Pared p);
    public void Visit(Piso p);
    public void Visit(Pocion p);
    public void Visit(Character p);

}

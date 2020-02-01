using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public float x;
    public float y;
    public Vector3 position;


    public bool isObstical;
    public float fcost;
    public float hcost;
    public float gcost;

    Node( float mx, float my, float h, float g = Mathf.Infinity, bool obstical = false)
    {
        this.isObstical = obstical;
        this.x = mx;
        this.y = my;
        this.hcost = h;
        this.gcost = g;
        this.fcost = this.gcost + this.hcost;
        this.position = new Vector3(this.x, this.y);
    }


}

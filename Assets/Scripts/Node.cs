using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public float x;
    public float y;
    public int nodeX;
    public int nodeY;
    public Vector3 position;
    public Color col;


    public bool isObstical;
    public float fcost;
    public float hcost;
    public float gcost;
    public Node parent;


    public Node( float mx, float my,int nx, int ny, float h, float g = Mathf.Infinity, bool obstical = false)
    {
        this.isObstical = obstical;
        this.x = mx;
        this.y = my;
        this.nodeX = nx;
        this.nodeY = ny;
        this.hcost = h;
        this.gcost = g;
        this.fcost = this.gcost + this.hcost;
        this.position = new Vector3(this.x, this.y,1);
        this.col = Color.white;


       

        

    }

    public void setHcost(Vector3 endPos)
    {
        float currentHcost = Vector2.Distance(this.position, endPos);
        this.hcost = currentHcost;

    }

    public List<Node> getNeighbours(Node[,] grid)
    {
        List<Node> Neighbours = new List<Node>();

        int maxX = grid.GetLength(0);
        int maxY = grid.GetLength(1);

        for(int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                if (!(i == 0 && j== 0))
                {

                    if((i + nodeY < maxY && i+nodeY > -1) && (j + nodeX > -1 && j + nodeX < maxX))
                    {
                        Neighbours.Add(grid[j + nodeX,i + nodeY]);
                    }
                    
                }
            }
        }

        return Neighbours;


    }

    public void setFcost()
    {
        this.fcost = this.gcost + this.hcost;

    }


}

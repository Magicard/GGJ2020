using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NavGrid : MonoBehaviour
{
 
    public Transform basePlate;
    public float worldWidth;
    public float worldHeight;
    bool created = false;
    Vector3 topLeftPos;
    int maxNodesX;
    int maxNodesY;
    public GameObject colliderObj;

    public float nodeSize =12f;

    
    public Node[,] Nodes;

    void Start()
    {
        worldWidth = basePlate.transform.lossyScale.x;
        worldHeight = basePlate.transform.lossyScale.y;


        topLeftPos = new Vector3(basePlate.position.x - (worldWidth / 2), basePlate.position.y - (worldHeight / 2), 0);
        createNodes();


    }

    void createNodes()
    {
        maxNodesX = Mathf.CeilToInt(worldWidth / nodeSize);
        maxNodesY = Mathf.CeilToInt(worldHeight / nodeSize);

        Nodes = new Node[maxNodesX,maxNodesY];
        for(int y = 0; y < maxNodesY; y++)
        {
            for(int x = 0; x < maxNodesX; x++)
            {
                Vector3 newNodePos = new Vector3(topLeftPos.x + (nodeSize * x), topLeftPos.y + (nodeSize * y), 1);
                BoxCollider2D[] cols = new BoxCollider2D[2];
                
                Nodes[x, y] = new Node(newNodePos.x, newNodePos.y, x, y, Mathf.Infinity);
                colliderObj.transform.position = Nodes[x, y].position;
                colliderObj.GetComponent<BoxCollider2D>().OverlapCollider(new ContactFilter2D(), cols);
                //Debug.Log(cols[0].gameObject.name);

                for (int i = 0; i < cols.GetLength(0); i++)
                {
                    if (cols[i].gameObject.layer == 8)
                    {
                        //Nodes[x, y].isObstical = true;
                        //Nodes[x, y].col = Color.black;

                    }
                }
                


            }
        }
        created = true;
        //findPath(Nodes[7, 1], Nodes[1, 8]);

    }

    void OnDrawGizmos()
    {
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
        if (created)
        {
            for (int y = 0; y < maxNodesY; y++)
            {
                for (int x = 0; x < maxNodesX; x++)
                {
                    Gizmos.color = Nodes[x, y].col;
                    Vector3 truePos = new Vector3(Nodes[x, y].position.x - nodeSize / 2, Nodes[x, y].position.y - nodeSize / 2, 1);
                    Gizmos.DrawCube(Nodes[x,y].position, new Vector3(nodeSize, nodeSize, 1));
                    Gizmos.color = Color.black;
                    Gizmos.DrawCube(Nodes[x, y].position, new Vector3(0.1f, 0.1f, 0.1f));


                }
            }
        }
    }

    public Node[] findPath(Vector3 startPos,Vector3 endPos)
    {
        createNodes();

        Node startNode = Nodes[Mathf.CeilToInt(startPos.x / nodeSize - topLeftPos.x) , Mathf.CeilToInt(startPos.y / nodeSize - topLeftPos.y)];
        Node endNode = Nodes[Mathf.CeilToInt(endPos.x / nodeSize - topLeftPos.x) , Mathf.CeilToInt(endPos.y / nodeSize - topLeftPos.y)];

        startNode.col = Color.red;
        endNode.col = Color.green;

        List<Node> openlist = new List<Node>();
        List<Node> closedList = new List<Node>();

        startNode.setHcost(endNode.position);
        startNode.fcost = startNode.hcost;
        startNode.gcost = 0f;

        openlist.Add(startNode);

        while (openlist.Count > 0)
        {
            float currentFcost = Mathf.Infinity;
            int currentIndex = 0;

            Node CurrentNode = null;

            //Find node with smallest fcost
            for (int i = 0; i < openlist.Count; i++)
            {
                Node tempNode = openlist[i];
                if(tempNode.fcost < currentFcost)
                {
                    currentFcost = tempNode.fcost;
                    CurrentNode = tempNode;
                    currentIndex = i;
                   

                }

                openlist.RemoveAt(currentIndex);
                closedList.Add(CurrentNode);

            }

            if(CurrentNode == endNode)
            {
                List<Node> path = new List<Node>();
                Node closedNode = closedList[closedList.Count - 1];
                while (closedNode != null){
                    closedNode.col = Color.blue;

                    path.Add(closedNode);
                    closedNode = closedNode.parent;

                }
                startNode.col = Color.red;
                endNode.col = Color.green;
                //path.Reverse();
                return path.ToArray();
                


            }

            List<Node> neighbours = CurrentNode.getNeighbours(Nodes);

            for(int n = 0; n < neighbours.Count; n++)
            {
                Node node = neighbours[n];
                if(node.isObstical == false)
                {
                    if(CurrentNode.gcost + nodeSize < node.gcost)
                    {
                        node.gcost = CurrentNode.gcost + nodeSize;
                        node.parent = CurrentNode;
                        node.setHcost(endNode.position);
                        node.setFcost();

                    }
                    if(!closedList.Contains(node) && !openlist.Contains(node))
                    {
                        openlist.Add(node);
                        node.col = Color.yellow;

                    }
                }
            }

        }

        return null;





    }

}

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
    public GameObject obs;
    [SerializeField]
    public List<Transform> G;
    public List<Node> obMemory;





    public float nodeSize = 12f;


    public Node[,] Nodes;

    void Start()
    {
        obMemory = new List<Node>();

        worldWidth = basePlate.transform.lossyScale.x;
        worldHeight = basePlate.transform.lossyScale.y;


        topLeftPos = new Vector3(basePlate.position.x - (worldWidth / 2), basePlate.position.y - (worldHeight / 2), 0);
        createNodes();



    }

    void createNodes()
    {
        maxNodesX = Mathf.CeilToInt(worldWidth / nodeSize);
        maxNodesY = Mathf.CeilToInt(worldHeight / nodeSize);

        BoxCollider2D c = new BoxCollider2D();


        Nodes = new Node[maxNodesX, maxNodesY];
        for (int y = 0; y < maxNodesY; y++)
        {
            for (int x = 0; x < maxNodesX; x++)
            {
                Vector3 newNodePos = new Vector3(topLeftPos.x + (nodeSize * x), topLeftPos.y + (nodeSize * y), 1);
                BoxCollider2D[] cols = new BoxCollider2D[2];

                Nodes[x, y] = new Node(newNodePos.x, newNodePos.y, x, y, Mathf.Infinity);


            }


        }
        int mem = 0;
        if (obMemory.Count > 0)
        {

            for (mem = 0; mem < obMemory.Count; mem++)
            {
                obMemory[mem].isObstical = true;
                obMemory[mem].col = Color.black;


            }
        }





        created = true;
        //findPath(Nodes[7, 1], Nodes[1, 8]);

    }

    void OnDrawGizmos()
    {
        // Draw a semitransparent blue cube at the transforms position

        if (created)
        {
            for (int y = 0; y < maxNodesY; y++)
            {
                for (int x = 0; x < maxNodesX; x++)
                {
                    Gizmos.color = Nodes[x, y].col;
                    Vector3 truePos = new Vector3(Nodes[x, y].position.x - nodeSize / 2, Nodes[x, y].position.y - nodeSize / 2, 1);
                    Gizmos.DrawCube(Nodes[x, y].position, new Vector3(nodeSize, nodeSize, 1));
                    Gizmos.color = Color.black;
                    Gizmos.DrawCube(Nodes[x, y].position, new Vector3(0.1f, 0.1f, 0.1f));


                }
            }
        }
    }

    public Node[] findPath(Vector3 startPos, Vector3 endPos)
    {
        createNodes();

        //Node startNode = Nodes[Mathf.RoundToInt(startPos.x / nodeSize - topLeftPos.x) , Mathf.RoundToInt(startPos.y / nodeSize - topLeftPos.y)];
        //Node endNode = Nodes[Mathf.RoundToInt(endPos.x / nodeSize - topLeftPos.x) , Mathf.RoundToInt(endPos.y / nodeSize - topLeftPos.y)];

        Node startNode = getNodeAt(startPos);
        Node endNode = getNodeAt(endPos);

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
                if (tempNode.fcost < currentFcost)
                {
                    currentFcost = tempNode.fcost;
                    CurrentNode = tempNode;
                    currentIndex = i;


                }

                openlist.RemoveAt(currentIndex);
                closedList.Add(CurrentNode);

            }

            if (CurrentNode == endNode)
            {
                List<Node> path = new List<Node>();
                Node closedNode = closedList[closedList.Count - 1];
                while (closedNode != null) {
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

            for (int n = 0; n < neighbours.Count; n++)
            {
                Node node = neighbours[n];
                if (node.isObstical == false)
                {
                    if (CurrentNode.gcost + nodeSize < node.gcost)
                    {
                        node.gcost = CurrentNode.gcost + nodeSize;
                        node.parent = CurrentNode;
                        node.setHcost(endNode.position);
                        node.setFcost();

                    }
                    if (!closedList.Contains(node) && !openlist.Contains(node))
                    {
                        openlist.Add(node);
                        node.col = Color.yellow;

                    }
                }
            }

        }

        return null;





    }

    public Node getNodeAt(Vector3 pos)
    {
        //Debug.Log(pos);
        int trueX = Mathf.RoundToInt(pos.x + worldWidth / 2);
        int trueY = Mathf.RoundToInt(pos.y + worldHeight / 2);

        int x = Mathf.RoundToInt(trueX / nodeSize);
        int y = Mathf.RoundToInt(trueY / nodeSize);

        //int mx = Mathf.RoundToInt(maxNodesX - 1 * x);
        //int my = Mathf.RoundToInt(maxNodesY - 1 * y);
        // Debug.Log(x.ToString() + " " + y.ToString());


        return Nodes[x, y];
    }
}

    /*public void makeObs(GameObject o)
    {


        //int trueX = Mathf.RoundToInt((o.transform.position.x + worldWidth / 2) / nodeSize);
        //int trueY = Mathf.RoundToInt((o.transform.position.y + worldHeight / 2) / nodeSize);

        int trueX = getNodeAt(o.transform.position).nodeX;
        int trueY = getNodeAt(o.transform.position).nodeY;

        int AW = Mathf.CeilToInt(o.transform.lossyScale.x / nodeSize);
        int AH = Mathf.CeilToInt(o.transform.lossyScale.y / nodeSize);
        Debug.Log(trueX.ToString() + " " + trueY.ToString());
        Debug.Log(AW.ToString() + " " + AH.ToString());
        obMemory.Add(Nodes[x], true[Y]);
        for (int x = trueX; x < trueX + AH;x++)
        {
            obMemory.Add(Nodes[x, trueY]);
        }
    }

}
*/
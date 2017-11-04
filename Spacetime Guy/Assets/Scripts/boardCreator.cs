using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardCreator : MonoBehaviour
{


    public int maxLeaf = 20;
    public List<Leafs> leafs;
    public List<Hallways> hallwayList;
    public int levelHeight = 30;
    public int levelWidth = 30;
    //public GameObject[] floor;
    //public GameObject[] wall;
    //public GameObject[] outerwall;
    //public GameObject player;
    private int[,] board;
    //array of objects
    private GameObject[,] playfield;
    public GameObject wall;
    private Room[] rooms;
    private GameObject boardHolder;
    public List<Leafs> childLeafs;
    //the starting corner for instantiating game objects
    public float yBoardCorner = -20.0f;
    public float xBoardCorner = -40.0f;

    // Use this for initialization
    void Start()
    {
        Leafs root = new Leafs(0, 0, levelWidth, levelHeight);
        leafs = new List<Leafs>();
        childLeafs = new List<Leafs>();
        leafs.Add(root);
        bool hasSplit = true;

        while (hasSplit)
        {
            hasSplit = false;
            for (int i = 0; i < leafs.Count; i++)
            {
                if (leafs[i].leftChild == null && leafs[i].rightChild == null)
                {
                    if (leafs[i].split())
                    {
                        leafs.Add(leafs[i].leftChild);
                        leafs.Add(leafs[i].rightChild);
                        hasSplit = true;
                    }
                }
            }
        }
        this.createrooms(root);
        
        foreach (Leafs i in childLeafs)
        {
            i.room = new Room(i.height, i.width, i.xpos, i.ypos);
        }
        hallwayList = new List<Hallways>();
        
        foreach (Leafs i in childLeafs)
        {
            int temp1 = Random.Range(0, childLeafs.Count);
            int temp2 = Random.Range(0, childLeafs.Count);
            while (temp1 == temp2)
            {
                temp1 = Random.Range(0, childLeafs.Count);
            }
            Hallways h1 = new Hallways(childLeafs[temp1].room, childLeafs[temp2].room);
            hallwayList.Add(h1);
        }
        foreach (Leafs i in childLeafs)
        {
            printroom(i.room);
        }
        print("END OF PRINT ROOMSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS");
        foreach (Leafs i in childLeafs)
        {
            printleaf(i);
        }
        board = new int[levelHeight, levelWidth];
        for (int i = 0; i < levelWidth; i++)
        {
            for (int j = 0; j < levelHeight; j++)
            {
                board[i, j] = 1;
            }
        }

        foreach (Leafs i in childLeafs)
        {
            for (int j = i.room.xPos; j < i.room.xPos + i.room.roomWidth; j++)
            {
                for (int k = i.room.yPos; k < i.room.yPos + i.room.roomHeight; k++)
                {
                    board[j, k] = 0;
                }
            }
        }
        foreach (Hallways i in hallwayList)
        {
            if (i.hallwayHorizontalLength > 0)
            {
                for (int j = i.xCornerStarting; j != i.xCornerStarting + i.hallwayHorizontalLength; j++)
                {
                    board[j, i.yCornerStarting] = 0;
                }
            }
            else
            {
                for (int j = i.xCornerStarting; j != i.xCornerStarting + i.hallwayHorizontalLength; j--)
                {
                    board[j, i.yCornerStarting] = 0;
                }
            }
            if (i.hallwayVerticalLength > 0)
            {
                for (int j = i.yCornerStarting; j != i.yCornerStarting + i.hallwayVerticalLength; j++)
                {
                    board[i.xCornerStarting, j] = 0;
                }
            }
            else
            {
                for (int j = i.yCornerStarting; j != i.yCornerStarting + i.hallwayVerticalLength; j--)
                {
                    board[i.xCornerStarting, j] = 0;
                }
            }
            for (int j = 0; j < levelWidth; j++)
            {
                for (int k = 0; k < levelHeight; k++)
                {
                    if (board[j, k] == 1)
                    {
                        Vector2 position = new Vector2(j + xBoardCorner, k + yBoardCorner);
                        Quaternion rotation = Quaternion.Euler(0, 0, 0);
                        Instantiate(wall, position, rotation);
                    }
                }
            }

        }
        //this.printArray(board);



       
    }
    void createrooms(Leafs l)
    {
        if(l.leftChild != null || l.rightChild != null)
        {
            if(l.leftChild != null)
            {
                this.createrooms(l.leftChild);
            }
            if(l.rightChild != null)
            {
                this.createrooms(l.rightChild);
            }
        }
        else
        {
            this.childLeafs.Add(l);
        }
    } 

    void printroom(Room r)
    {
        print("The x coordinate is " +  r.xPos);
        print("The Y coordinate is " + r.yPos);

        print("The width is " + r.roomWidth);
        print("The height is " + r.roomHeight);
    }
    void printleaf(Leafs l)
    {
        print("The x coordinate is " + l.xpos);
        print("The Y coordinate is " + l.ypos);

        print("The width is " + l.width);
        print("The height is " + l.height);
    }
    void printArray(int[,] board)
    {
        string newString = "";
        for(int i=0; i < levelHeight; i++)
        {
            for(int j=0; j < levelWidth; j++)
            {
                newString += board[i, j];
            }
            newString += System.Environment.NewLine;
        }
        print(newString);
    }

}




   


    //SetTileValuesForRooms()
    //{
    //    for (int i =0; i < rooms.Length; i++)
    //    {
    //        Room currentRoom = rooms[i];
    //        for (int j=0; j < currentRoom.roomWidth; j++)
    //        {
    //            int xCoord = currentRoom.xPos + j;

    //            for (int k=0; k < currentRoom.roomHeight; k++)
    //            {
    //                int yCoord = currentRoom.yPos + k;

    //                //Edit this part to add enemies and powerups

    //                board[xCoord][yCoord] = TileType.Floor;
    //            }
    //        }
    //    }
    //}

//    void InstantiateTiles()
//    {
//        for(int i=0; i < board.Length; i++)
//        {
//            for(int j=0; j < board.Length; j++)
//            {
//                InstantiateFromArray(floorTiles, i, j);

//                if(board[i][j] == TileType.Wall)
//                {
//                    InstantiateFromArray(wallTiles, i, j);
//                }
//            }
//        }
//    }
//}

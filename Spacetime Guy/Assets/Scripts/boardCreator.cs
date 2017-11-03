using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardCreator : MonoBehaviour
{


    public int maxLeaf = 20;
    public List<Leafs> leafs;
    public List<Hallways> hallwayList;
    public int levelHeight = 100;
    public int levelWidth = 100;
    //public GameObject[] floor;
    //public GameObject[] wall;
    //public GameObject[] outerwall;
    //public GameObject player;
    private int[,] board;
    private Room[] rooms;
    private GameObject boardHolder;
    public List<Leafs> childLeafs;

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
                    else
                    {
                        childLeafs.Add(leafs[i]);
                    }
                }
            }
        }
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
            for (int j = i.room.leafXPos; j < i.room.leafXPos + i.room.leafWidth; j++)
            {
                for (int k = i.room.leafYPos; k < i.room.leafYPos + i.room.leafHeight; k++)
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
        }

        /*
        boardHolder = new GameObject("BoardHolder");

        SetupTilesArray();

        CreateRooms();

        SetTileValuesForRooms();

        InstantiateTiles();
        InstantiateOuterWalls();
        */
        for (int i = 0; i < levelHeight; i++)
        {

            for (int j = 0; j < levelWidth; j++)
            {
                print(board[i, j]);
            }
            print(System.Environment.NewLine);
        }
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

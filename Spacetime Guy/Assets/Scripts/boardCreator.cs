using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardCreator : MonoBehaviour {


    public int maxLeaf = 20;
    public List<Leafs> leafs;
    public int levelHeight = 100;
    public int levelWidth = 100;
    //public GameObject[] floor;
    //public GameObject[] wall;
    //public GameObject[] outerwall;
    //public GameObject player;
    private TileType[][] board;
    private Room[] rooms;
    private GameObject boardHolder;
    public List<Leafs> childLeafs;

    // Use this for initialization
    void Start() {
        Leafs root = new Leafs(0,0,levelWidth,levelHeight);
        leafs = new List<Leafs>();
        childLeafs = new List<Leafs>();
        leafs.Add(root);
        bool hasSplit = true;

        while (hasSplit)
        {
            hasSplit = false;
            for(int i=0; i < leafs.Count; i++){
                if(leafs[i].leftChild == null && leafs[i].rightChild == null)
                {
                    if (leafs[i].split())
                    {
                        leafs.Add(leafs[i].leftChild);
                        leafs.Add(leafs[i].rightChild);
                        hasSplit = true;
                    } else {
                        childLeafs.Add(leafs[i]);
                    }
                }
            }
        }
        foreach (Leafs i in childLeafs)
        {
            i.room = new Room();
        }

        /*
        boardHolder = new GameObject("BoardHolder");

        SetupTilesArray();

        CreateRooms();

        SetTileValuesForRooms();

        InstantiateTiles();
        InstantiateOuterWalls();
        */

    }

    void SetupTilesArray()
    {
        board = new TileType[levelWidth][];

        for (int i = 0; i < board.Length; i++)
        {
            board[i] = new TileType[levelHeight];
        }
    }

    void CreateRooms()
    {
        System.Random randInt = new System.Random();
        numRooms = randInt.Next(2, 4);
        rooms = new Room[numRooms];

        //Set up start room
        rooms[0] = new Room();
        rooms[0].createStartRoom();

        for (int i = 1; i < numRooms; i++)
        {
            rooms[i] = new Room();

            rooms[i].createRoom(rooms[i - 1]);
        }
    } 

    SetTileValuesForRooms()
    {
        for (int i =0; i < rooms.Length; i++)
        {
            Room currentRoom = rooms[i];
            for (int j=0; j < currentRoom.roomWidth; j++)
            {
                int xCoord = currentRoom.xPos + j;

                for (int k=0; k < currentRoom.roomHeight; k++)
                {
                    int yCoord = currentRoom.yPos + k;

                    //Edit this part to add enemies and powerups

                    board[xCoord][yCoord] = TileType.Floor;
                }
            }
        }
    }

    void InstantiateTiles()
    {
        for(int i=0; i < board.Length; i++)
        {
            for(int j=0; j < board.Length; j++)
            {
                InstantiateFromArray(floorTiles, i, j);

                if(board[i][j] == TileType.Wall)
                {
                    InstantiateFromArray(wallTiles, i, j);
                }
            }
        }
    }
}

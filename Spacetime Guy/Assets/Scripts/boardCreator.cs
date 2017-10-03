/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardCreator : MonoBehaviour {



    public int levelHeight = 100;
    public int levelWidth = 100;
    //public GameObject[] floor;
    //public GameObject[] wall;
    //public GameObject[] outerwall;
    //public GameObject player;
    private TileType[][] board;
    private Room[] rooms;
    private GameObject boardHolder;

    // Use this for initialization
    void Start() {
        boardHolder = new GameObject("BoardHolder");

        SetupTilesArray();

        CreateRooms();

        SetTileValuesForRooms();

        InstantiateTiles();
        InstantiateOuterWalls();

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
}*/

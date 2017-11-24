﻿using System.Collections;
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
    public GameObject player;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject powerup;
    private Room[] rooms;
    private GameObject boardHolder;
    public List<Leafs> childLeafs;
    //the starting corner for instantiating game objects
    public float yBoardCorner = -20.0f;
    public float xBoardCorner = -40.0f;
    //Enemies per room
    public int minEnemies;
    public int maxEnemies;

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

        //foreach (Leafs i in childLeafs)
        for (int i = 0; i < (childLeafs.Count - 1); i++)
        {
            if (i == 1)
            {
                childLeafs[i].room.startRoom = true;
            }

            Hallways h1 = new Hallways(childLeafs[i].room, childLeafs[i + 1].room);
            hallwayList.Add(h1);

        }
        /**
        foreach (Leafs i in childLeafs)
        {
            printroom(i.room);
        }
        print("END OF PRINT ROOMSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS");
       
        foreach (Leafs i in childLeafs)
        {
            printleaf(i);
        }
        */
        board = new int[levelHeight, levelWidth];
        for (int i = 0; i < levelWidth; i++)
        {
            for (int j = 0; j < levelHeight; j++)
            {
                board[i, j] = 1;
            }
        }
        int countE = 0;
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

        print("size of HallwaysList: " + hallwayList.Count);
        foreach (Hallways i in hallwayList)
        {
            //printHallways(i);
            //going left
            if ((i.hallwayHorizontalLength > 0) && (i.startRoomYCorner == i.yBendCorner))
            {
                //printHallways(i);
                for (int j = i.startRoomXCorner; j < i.xBendCorner; j++)
                {
                    board[j, i.startRoomYCorner] = 0;
                    board[j, i.startRoomYCorner + 1] = 0;
                }
            }
            if ((i.hallwayHorizontalLength > 0) && (i.yBendCorner == i.endRoomYCorner))
            {
                //printHallways(i);
                for (int j = i.xBendCorner; j < i.endRoomXCorner; j++)
                {
                    board[j, i.yBendCorner] = 0;
                    board[j, i.yBendCorner + 1] = 0;
                }
            }
            if ((i.hallwayHorizontalLength < 0) & (i.startRoomYCorner == i.yBendCorner))
            {
                //printHallways(i);
                for (int j = i.startRoomXCorner; j > i.xBendCorner; j--)
                {
                    board[j, i.startRoomYCorner] = 0;
                    board[j, i.startRoomYCorner - 1] = 0;
                }
            }
            if ((i.hallwayHorizontalLength < 0) && (i.yBendCorner == i.endRoomYCorner))
            {
                //printHallways(i);
                for (int j = i.xBendCorner; j > i.endRoomXCorner; j--)
                {
                    board[j, i.yBendCorner] = 0;
                    board[j, i.yBendCorner - 1] = 0;
                }
            }
            if ((i.hallwayVerticalLength > 0) && (i.startRoomXCorner == i.xBendCorner))
            {
                //printHallways(i);
                for (int j = i.startRoomYCorner; j < i.yBendCorner; j++)
                {
                    board[i.startRoomXCorner, j] = 0;
                    board[i.startRoomXCorner - 1, j] = 0;
                }
            }
            if ((i.hallwayVerticalLength > 0) && (i.xBendCorner == i.endRoomXCorner))
            {
                //printHallways(i);
                for (int j = i.yBendCorner; j < i.endRoomYCorner; j++)
                {
                    board[i.xBendCorner, j] = 0;
                    board[i.xBendCorner + 1, j] = 0;
                }
            }
            if ((i.hallwayVerticalLength < 0) & (i.startRoomXCorner == i.xBendCorner))
            {
                //printHallways(i);
                for (int j = i.startRoomYCorner; j > i.yBendCorner; j--)
                {
                    board[i.startRoomXCorner, j] = 0;
                    board[i.startRoomXCorner - 1, j] = 0;
                }
            }
            if ((i.hallwayVerticalLength < 0) && (i.xBendCorner == i.endRoomXCorner))
            {
                //printHallways(i);
                for (int j = i.yBendCorner; j > i.endRoomYCorner; j--)
                {
                    board[i.xBendCorner, j] = 0;
                    board[i.xBendCorner - 1, j] = 0;


                }
            }

        }
        foreach (Leafs i in childLeafs)
        {
            int numEnemies1 = 0; //number of enemies in the room
            int numEnemies2 = 0; //number of enemies in the room
            int numPowerups = 0; //number of powerups int the room
            System.Random randnum = new System.Random();
            if (i.room.startRoom != true) //determine num of enemies
            {
                numEnemies1 = randnum.Next(minEnemies, maxEnemies);
                numEnemies2 = randnum.Next(minEnemies, maxEnemies);
                //countE += numEnemies;
            }
            if (i.room.startRoom != true) //determine num of enemies
            {
                numPowerups = 1;
            }
            //find location of enemy type 1
            while (numEnemies1 != 0)
            {
                int x = randnum.Next(i.room.xPos + 1, i.room.xPos + i.room.roomWidth - 1);
                int y = randnum.Next(i.room.yPos + 1, i.room.yPos + i.room.roomHeight - 1);
                board[x, y] = 2;

                //add implementation to prevent 2 enemies spawning on same spot

                numEnemies1--;
            }
            //find location of enemy type 2
            while (numEnemies2 != 0)
            {
                int x = randnum.Next(i.room.xPos + 1, i.room.xPos + i.room.roomWidth - 1);
                int y = randnum.Next(i.room.yPos + 1, i.room.yPos + i.room.roomHeight - 1);
                board[x, y] = 3;

                //add implementation to prevent 2 enemies spawning on same spot

                numEnemies2--;
            }
            //find location of powerups
            while (numPowerups != 0)
            {
                int x = randnum.Next(i.room.xPos, i.room.xPos + i.room.roomWidth);
                int y = randnum.Next(i.room.yPos, i.room.yPos + i.room.roomHeight);
                board[x, y] = 6;

                //add implementation to prevent 2 enemies/powerups spawning on same spot

                numPowerups--;
            }
            ///set location of character
            if (i.room.startRoom)
            {

                print(i.room.xPos + i.room.roomWidth / 2 + "," + i.room.yPos + i.room.roomHeight / 2);
                board[i.room.xPos + i.room.roomWidth / 2, i.room.yPos + i.room.roomHeight / 2] = 5;
            }
        }
        int count = 0;
        //instantiate walls and players
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
                if (board[j, k] == 5)
                {
                    Vector2 position = new Vector2(j + xBoardCorner, k + yBoardCorner);
                    Quaternion rotation = Quaternion.Euler(0, 0, 0);
                    Instantiate(player, position, rotation);
                    //print("player");
                }

            }

        }
        //Instantiate enemy types and powerups
        for (int j = 0; j < levelWidth; j++)
        {
            for (int k = 0; k < levelHeight; k++)
            {

                if (board[j, k] == 2)
                {

                    Vector2 position = new Vector2(j + xBoardCorner, k + yBoardCorner);
                    Quaternion rotation = Quaternion.Euler(0, 0, 0);
                    Instantiate(enemy1, position, rotation);
                    //print("enemy1");
                }
                if (board[j, k] == 3) {
                    Vector2 position = new Vector2(j + xBoardCorner, k + yBoardCorner);
                    Quaternion rotation = Quaternion.Euler(0, 0, 0);
                    Instantiate(enemy2, position, rotation);
                    //print("enemy2");
                }
                if (board[j, k] == 6)
                {
                    Vector2 position = new Vector2(j + xBoardCorner, k + yBoardCorner);
                    Quaternion rotation = Quaternion.Euler(0, 0, 0);
                    Instantiate(powerup, position, rotation);
                    
                }
            }
        }
    
        //print("num enemies" + count);
        //this.printArray(board);
        //}



    }
    //cretes rooms
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
    //prints rooms
    void printroom(Room r)
    {
        print("The x coordinate is " +  r.xPos);
        print("The Y coordinate is " + r.yPos);

        //print("The width is " + r.roomWidth);
        //print("The height is " + r.roomHeight);
    }
    void printleaf(Leafs l)
    {
        print("The x coordinate is " + l.xpos);
        print("The Y coordinate is " + l.ypos);

        print("The width is " + l.width);
        print("The height is " + l.height);
    }
    void printHallways(Hallways h)
    {
    
        /*print("the starting xcoord of hallway is " + h.startRoomXCorner);
        print("the bend xcoord of hallway is " + h.xBendCorner);
        print("the ending xcoord of hallway is " + h.endRoomXCorner);
        print("the starting ycoord of hallway is" + h.startRoomYCorner);
        print("the bend ycoord of hallway is " + h.yBendCorner);
        print("the ending ycoord of hallway is" + h.endRoomYCorner);*/
        print("the vertical length is" + h.hallwayVerticalLength);
        print("the horizontal length is" + h.hallwayHorizontalLength);
        print("starting room x pos" + h.startRoomXCorner);
        print("starting room y pos" + h.startRoomYCorner);
        print("ending room x pos" + h.endRoomXCorner);
        print("ending room y pos" + h.endRoomYCorner);
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
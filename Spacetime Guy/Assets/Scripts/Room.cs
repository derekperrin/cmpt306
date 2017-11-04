using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Room {
    public int xPos; //x coordinate of lower left corner
    public int yPos; //y coordinate of lower left corner
    //Height and Width of Room 
    public int roomHeight;
    public int roomWidth;
    //Height and Width of leaf
    public int leafHeight;
    public int leafWidth;
    //Where leaf is in scene
    public int leafXPos;
    public int leafYPos;
    //Capped minimum size of height and Width
    public int minRoomWidth = 5; 
    public int minRoomHeight = 5;
    //factor to set point at to start room creation
    public int divisionFactor = 4;
    public Rect roomRect;

    public Room(int leafHeight,int leafWidth,int leafXPos,int leafYPos)
    {
        System.Random randInt = new System.Random();
        /*
        xPos = randInt.Next(leafXPos, leafXPos + leafWidth/4);
        yPos = randInt.Next(leafYPos, leafYPos + leafHeight / 4);
        */
        xPos = leafXPos + 1;
        yPos = leafYPos + 1;
        roomHeight = leafHeight - 2;
        roomWidth = leafWidth - 2;
        
        /*
        if(minRoomHeight > leafHeight - (yPos - leafYPos))
        {
            roomHeight = randInt.Next(leafHeight - (yPos - leafYPos), minRoomHeight);
        }
        else
        {
            roomHeight = randInt.Next(minRoomHeight, leafHeight - (yPos - leafYPos));
        }
        if (minRoomWidth > leafWidth - (xPos - leafXPos))
        {
            roomWidth = randInt.Next(leafWidth - (xPos - leafXPos), minRoomWidth);
        }
        else
        {
            roomWidth = randInt.Next(minRoomWidth, leafWidth - (xPos - leafXPos));
        }*/
        /*
        roomHeight = randInt.Next(minRoomHeight, leafHeight-(leafHeight - yPos));
        roomWidth = randInt.Next(minRoomWidth, leafWidth-(leafWidth - xPos));*/
        //roomRect = new Rect();
        

    }

    
	

}

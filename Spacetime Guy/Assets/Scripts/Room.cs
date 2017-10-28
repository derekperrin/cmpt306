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
        if(leafXPos > leafWidth / divisionFactor)
        {
            xPos = randInt.Next(leafWidth / divisionFactor, leafXPos);
        }
        else
        {
            xPos = randInt.Next(leafXPos, leafWidth / divisionFactor);
        }
        if (leafYPos > leafHeight/divisionFactor)
        {
            yPos = randInt.Next(leafHeight / divisionFactor, leafYPos);
        }
        else
        {
            yPos = randInt.Next(leafYPos, leafHeight / divisionFactor);
        }
        roomHeight = randInt.Next(minRoomHeight, leafHeight - (leafHeight/divisionFactor) );
        roomWidth = randInt.Next(minRoomWidth, leafWidth - (leafWidth/divisionFactor) );
        //roomRect = new Rect();
        

    }

    
	

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Room {
    private int xPos; //x coordinate of lower left corner
    private int yPos; //y coordinate of lower left corner
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

    Room(int leafHeight,int leafWidth,int leafXPos,int leafYPos)
    {
        System.Random randInt = new System.Random();
        xPos = randInt.Next(leafXPos,leafWidth/divisionFactor);
        yPos = randInt.Next(leafYPos, leafHeight/divisionFactor);
        roomHeight = randInt.Next(minRoomHeight, leafHeight - (leafHeight/divisionFactor) );
        roomWidth = randInt.Next(minRoomWidth, leafWidth - (leafWidth/divisionFactor) );
        //roomRect = new Rect();
        

    }

    
	

}

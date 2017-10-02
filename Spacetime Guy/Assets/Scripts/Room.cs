using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Room {
    public int xPos; //x coordinate of lower left corner
    public int yPos; //y coordinate of lower left corner
    public int roomWidth;
    public int roomHeight;
    public int[] doorXPos;
    public int[] doorYPos;
    public String compassLocation;

	// Use this for initialization
	public void createStartRoom () {

        Room temp = new Room();
        System.Random random = new System.Random();  //implements a random number generator

        temp.roomWidth = random.Next(5, 10); // sets room width
        temp.roomHeight = random.Next(5, 10); //sets room height

        //temp.xPos[0] = levelWidth/2 + temp.roomWidth/2
        //temp.yPos[0] = levelHeight/2 + temp.roomHeight/2

        int tempInt = random.Next(1, 4);

        if (tempInt == 1)
        {
            temp.doorXPos[0] = temp.xPos;
            temp.doorYPos[0] = temp.yPos + random.Next(1, temp.roomHeight - 1);
            temp.compassLocation = "W";
        }
        if (tempInt == 2)
        {
            temp.doorXPos[0] = temp.xPos + temp.roomWidth;
            temp.doorYPos[0] = temp.yPos + random.Next(1, temp.roomHeight - 1);
            temp.compassLocation = "E";
        }
        if (tempInt == 3)
        {
            temp.doorXPos[0] = temp.xPos + random.Next(1, temp.roomWidth - 1); ;
            temp.doorYPos[0] = temp.yPos;
            temp.compassLocation = "S";
        }
        if (tempInt == 4)
        {
            temp.doorXPos[0] = temp.xPos + random.Next(1, temp.roomWidth - 1); ;
            temp.doorYPos[0] = temp.yPos + temp.roomWidth;
            temp.compassLocation = "N";
        }
    }

    public void createRoom(Room previousRoom) {

        Room temp = new Room();
        System.Random random = new System.Random();  //implements a random number generator

        temp.roomWidth = random.Next(5, 10); // sets room width
        temp.roomHeight = random.Next(5, 10); //sets room height

        if(previousRoom.compassLocation == "N")
        {
            temp.xPos = previousRoom.doorXPos[0] - previousRoom.roomWidth / 2;
            temp.yPos = previousRoom.yPos + previousRoom.roomHeight + 1;
            int tempInt2 = random.Next(1, 3);

            if (tempInt2 == 1)
            {
                temp.doorXPos[1] = temp.xPos;
                temp.doorYPos[1] = temp.yPos + random.Next(1, temp.roomHeight - 1);
                temp.compassLocation = "W";
            }
            if (tempInt2 == 2)
            {
                temp.doorXPos[1] = temp.xPos + temp.roomWidth;
                temp.doorYPos[1] = temp.yPos + random.Next(1, temp.roomHeight - 1);
                temp.compassLocation = "E";
            }
            if (tempInt2 == 3)
            {
                temp.doorXPos[1] = temp.xPos + random.Next(1, temp.roomWidth - 1); ;
                temp.doorYPos[1] = temp.yPos;
                temp.compassLocation = "S";
            }
        }
        if (previousRoom.compassLocation == "S")
        {
            temp.xPos = previousRoom.doorXPos[0] - previousRoom.roomWidth / 2;
            temp.yPos = previousRoom.yPos - 1;
            int tempInt2 = random.Next(1, 3);

            if (tempInt2 == 1)
            {
                temp.doorXPos[1] = temp.xPos;
                temp.doorYPos[1] = temp.yPos + random.Next(1, temp.roomHeight - 1);
                temp.compassLocation = "W";
            }
            if (tempInt2 == 2)
            {
                temp.doorXPos[1] = temp.xPos + temp.roomWidth;
                temp.doorYPos[1] = temp.yPos + random.Next(1, temp.roomHeight - 1);
                temp.compassLocation = "E";
            }
            if (tempInt2 == 3)
            {
                temp.doorXPos[1] = temp.xPos + random.Next(1, temp.roomWidth - 1); ;
                temp.doorYPos[1] = temp.yPos + temp.roomWidth;
                temp.compassLocation = "N";
            }
        }
        if (previousRoom.compassLocation == "E")
        {
            temp.yPos = previousRoom.doorYPos[0] - previousRoom.roomHeight / 2;
            temp.xPos = previousRoom.xPos + previousRoom.roomWidth + 1;
            int tempInt2 = random.Next(1, 3);
            if (tempInt2 == 1)
            {
                temp.doorXPos[1] = temp.xPos;
                temp.doorYPos[1] = temp.yPos + random.Next(1, temp.roomHeight - 1);
                temp.compassLocation = "W";
            }
            if (tempInt2 == 2)
            {
                temp.doorXPos[1] = temp.xPos + random.Next(1, temp.roomWidth - 1); ;
                temp.doorYPos[1] = temp.yPos;
                temp.compassLocation = "S";
            }
            if (tempInt2 == 3)
            {
                temp.doorXPos[1] = temp.xPos + random.Next(1, temp.roomWidth - 1); ;
                temp.doorYPos[1] = temp.yPos + temp.roomWidth;
                temp.compassLocation = "N";
            }

        }
        if (previousRoom.compassLocation == "W")
        {
            temp.yPos = previousRoom.doorYPos[0] - previousRoom.roomHeight / 2;
            temp.xPos = previousRoom.xPos - 1;
            int tempInt2 = random.Next(1, 3);
            if (tempInt2 == 1)
            {
                temp.doorXPos[1] = temp.xPos + temp.roomWidth;
                temp.doorYPos[1] = temp.yPos + random.Next(1, temp.roomHeight - 1);
                temp.compassLocation = "E";
            }
            if (tempInt2 == 2)
            {
                temp.doorXPos[1] = temp.xPos + random.Next(1, temp.roomWidth - 1); ;
                temp.doorYPos[1] = temp.yPos;
                temp.compassLocation = "S";
            }
            if (tempInt2 == 3)
            {
                temp.doorXPos[1] = temp.xPos + random.Next(1, temp.roomWidth - 1); ;
                temp.doorYPos[1] = temp.yPos + temp.roomWidth;
                temp.compassLocation = "N";
            }
        }
        //temp.xPos = levelWidth/2 + temp.roomWidth/2
        //temp.yPos = levelHeight/2 + temp.roomHeight/2

    }

}

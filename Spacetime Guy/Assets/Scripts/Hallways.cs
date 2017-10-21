using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Hallways {
    //bottom left corner point
    int xCorner;
    int yCorner;
    int hallwayLength = 1;
    int hallwayWidth = 1;
   
    //Two rooms we're connecting
    Room startingRoom;
    Room endingRoom;

    //the point we need to bend to create an L-shape 
    int xBendCorner = null;
    int yBendCorner = null;

    //tells if we need to bend the hallway.
    bool lShape = false;

    //Which side do we make the hallway on?
    bool r1FurtherThanR2 = false;
    //boolean top = false;
    //boolean left = false;
    //how much they overlap within the distance between each other.
    int xOverlap;
    int yOverlap;

    Hallways(Room startingRoom, Room endingRoom)
    {
        xOverlap = calculateOverlap(startingRoom.xPos, endingRoom.xPos, startingRoom.xPos + startingRoom.roomWidth, endingRoom.xPos + endingRoom.roomWidth);
       // if (r1FurtherThanR2)
       // {

       // }
        yOverlap = calculateOverlap(startingRoom.yPos, endingRoom.yPos, startingRoom.yPos + startingRoom.roomHeight, endingRoom.yPos + endingRoom.roomHeight);
       // if (r1FurtherThanR2)
       // {

       // }
        

    }

    public int calulateOverlap(int R1LeftCorner, int R2LeftCorner, int R1RightCorner, int R2RightCorner)
    {
        int Overlap;
        if (R1LeftCorner > R2RightCorner)
        {
            Overlap = R1LeftCorner - R2RightCorner;
            r1FurtherThanR2 = true;

        } else
        {
            Overlap = R2LeftCorner - R1RightCorner;
            r1FurtherThanR2 = false;
        }
        return Overlap;
        
    }

}

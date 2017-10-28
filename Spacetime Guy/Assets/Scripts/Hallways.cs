using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Hallways {
    //bottom left corner point
    public int xCornerStarting;
    public int yCornerStarting;
    //ending room corner point
    public int xCornerEnding;
    public int yCornerEnding;

    public int hallwayHorizontalLength = 0;
    public int hallwayVerticalLength = 0;


    public int hallwayWidth = 1;
   
    //Two rooms we're connecting
    public Room startingRoom;
    public Room endingRoom;

    //the point we need to bend to create an L-shape 
    public int xBendCorner=0;
    public int yBendCorner=0;

    //tells if we need to bend the hallway.
    bool lShape = false;

    
    bool hallwayIntersect = false;
    //boolean top = false;
    //boolean left = false;
    //how much they overlap within the distance between each other.
    int xOverlap;
    int yOverlap;

    public Hallways(Room startingRoom, Room endingRoom)
    {
        if (Mathf.Abs(startingRoom.xPos - endingRoom.xPos) > Mathf.Abs(startingRoom.yPos - endingRoom.yPos))
        {
            if (startingRoom.xPos - endingRoom.xPos > 0)
            {
                //Hallway is going to the left
                xCornerStarting = startingRoom.xPos;
                yCornerStarting = startingRoom.yPos + startingRoom.roomHeight / 2;
                //xCornerEnding = endingRoom.xPos;
                hallwayHorizontalLength = (endingRoom.xPos + endingRoom.roomWidth) - startingRoom.xPos;
                xCornerEnding = startingRoom.xPos + hallwayHorizontalLength;
                yCornerEnding = yCornerStarting;
                //check if room and hallway overlap
                if (!CheckIfHallwayOverlap(endingRoom, xCornerEnding, yCornerEnding))
                {
                    lShape = true;
                    xBendCorner = xCornerEnding - 1;
                    yBendCorner = yCornerEnding;
                    hallwayHorizontalLength--;

                    if (lShape == true)
                    {
                        int bendDir = WhichWayToBend(endingRoom, xBendCorner, yBendCorner);
                        xCornerEnding = xBendCorner;
                        yCornerEnding = yBendCorner + (bendDir * Mathf.Abs(endingRoom.yPos - yBendCorner));
                        hallwayVerticalLength = endingRoom.yPos - yBendCorner;
                    }
                }
            }
            else
            {


                xCornerStarting = startingRoom.xPos + startingRoom.roomWidth;
                yCornerStarting = startingRoom.yPos + startingRoom.roomHeight / 2;
                //Hallway is going to the right
                hallwayHorizontalLength = endingRoom.xPos - startingRoom.xPos + startingRoom.roomWidth;
                xCornerEnding = startingRoom.xPos + hallwayHorizontalLength;
                yCornerEnding = yCornerStarting;
                //check if room and hallway overlap
                if (!CheckIfHallwayOverlap(endingRoom, xCornerEnding, yCornerEnding))
                {
                    lShape = true;
                    xBendCorner = xCornerEnding + 1;
                    yBendCorner = yCornerEnding;
                    hallwayHorizontalLength++;

                    if (lShape == true)
                    {
                        int bendDir = WhichWayToBend(endingRoom, xBendCorner, yBendCorner);
                        xCornerEnding = xBendCorner;
                        yCornerEnding = yBendCorner + (bendDir * Mathf.Abs(endingRoom.yPos - yBendCorner));
                        hallwayVerticalLength = endingRoom.yPos - yBendCorner;
                    }
                }
            }
        }
        else
        {
            if (startingRoom.yPos - endingRoom.yPos > 0)
            {
                //Hallway going down
                yCornerStarting = startingRoom.yPos;
                xCornerStarting = startingRoom.xPos + startingRoom.roomWidth / 2;
                //xCornerEnding = endingRoom.xPos;
                hallwayVerticalLength = (endingRoom.yPos + endingRoom.roomHeight)-startingRoom.yPos;
                yCornerEnding = startingRoom.yPos + hallwayVerticalLength;
                xCornerEnding = xCornerStarting;
                //check if room and hallway overlap
                if (!CheckIfHallwayOverlap(endingRoom, xCornerEnding, yCornerEnding))
                {
                    lShape = true;
                    yBendCorner = yCornerEnding - 1;
                    xBendCorner = xCornerEnding;
                    hallwayVerticalLength--;

                    if (lShape == true)
                    {
                        int bendDir = WhichWayToBend(endingRoom, xBendCorner, yBendCorner);
                        yCornerEnding = yBendCorner;
                        xCornerEnding = xBendCorner + (bendDir * Mathf.Abs(endingRoom.xPos - xBendCorner));
                        hallwayHorizontalLength = endingRoom.xPos - xBendCorner;
                    }
                }
                else
                {
                    //Hallway going up
                    yCornerStarting = startingRoom.yPos + startingRoom.roomHeight;
                    xCornerStarting = startingRoom.xPos + startingRoom.roomWidth / 2;
                    //xCornerEnding = endingRoom.xPos;
                    hallwayVerticalLength = endingRoom.yPos - (startingRoom.yPos + startingRoom.roomHeight);
                    yCornerEnding = startingRoom.yPos + hallwayVerticalLength;
                    xCornerEnding = xCornerStarting;
                    //check if room and hallway overlap
                    if (!CheckIfHallwayOverlap(endingRoom, xCornerEnding, yCornerEnding))
                    {
                        lShape = true;
                        yBendCorner = yCornerEnding + 1;
                        xBendCorner = xCornerEnding;
                        hallwayVerticalLength++;

                        if (lShape == true)
                        {
                            int bendDir = WhichWayToBend(endingRoom, xBendCorner, yBendCorner);
                            yCornerEnding = yBendCorner;
                            xCornerEnding = xBendCorner + (bendDir * Mathf.Abs(endingRoom.xPos - xBendCorner));
                            hallwayHorizontalLength = endingRoom.xPos - xBendCorner;
                        }
                    }
                }
            }
        }
	}

    public bool CheckIfHallwayOverlap(Room endRoom, int xHallwayEnd,int yHallwayEnd)
    {
        if ((xHallwayEnd >= endRoom.xPos && xHallwayEnd <= endRoom.xPos + endRoom.roomWidth) &&
            (yHallwayEnd >= endRoom.yPos && yHallwayEnd <= endRoom.yPos + endRoom.roomHeight) )
        {
            return true;    
        }
            return false;
    }

    public int WhichWayToBend(Room endRoom, int xBend,int yBend)
    {
        if (endRoom.xPos > xBend)
        {
            return 1;
        }
        if (endRoom.xPos < xBend)
        {
            return -1;
        }
        if (endRoom.yPos > yBend)
        {
            return 1;
        }
        if (endRoom.yPos > yBend)
        {
            return -1;
        }
        return 0;
    }

   /*  public int calulateOverlap(int R1LeftCorner, int R2LeftCorner, int R1RightCorner, int R2RightCorner)
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
        
    }*/

}

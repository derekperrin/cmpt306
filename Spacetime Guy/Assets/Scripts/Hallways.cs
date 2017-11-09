using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Hallways {
    //bottom left corner point of starting room
    public int startRoomXCorner;
    public int startRoomYCorner;
    //bottom left conrner point of ending room ending room
    public int endRoomXCorner;
    public int endRoomYCorner;
    public enum Direction { NORTH, EAST, SOUTH, WEST,ERROR };

    public int hallwayHorizontalLength = 0;
    public int hallwayVerticalLength = 0;


    public int hallwayWidth = 5;

    //Two rooms we're connecting
    public Room startingRoom;
    public Room endingRoom;

    //the point we need to bend to create an L-shape 
    public int xBendCorner = 0;
    public int yBendCorner = 0;

    //tells if we need to bend the hallway.
    //bool lShape = false;


    //bool hallwayIntersect = false;
    //boolean top = false;
    //boolean left = false;
    //how much they overlap within the distance between each other.
    //int xOverlap;
    //int yOverlap;

    public Hallways(Room startingRoom, Room endingRoom)
    {
        Direction currDir = GetDirection(startingRoom, endingRoom);
        //Debug.Log(currDir);
        if (currDir == Direction.WEST||currDir == Direction.EAST)
        {
            startRoomXCorner = startingRoom.xPos + startingRoom.roomWidth/2;
            startRoomYCorner = startingRoom.yPos + (startingRoom.roomHeight/2);
            endRoomXCorner = endingRoom.xPos + endingRoom.roomWidth/2;
            endRoomYCorner = endingRoom.yPos + endingRoom.roomHeight/2;
            xBendCorner = startRoomXCorner+endRoomXCorner-startRoomXCorner;
            yBendCorner = startRoomYCorner;
            hallwayHorizontalLength = xBendCorner - startRoomXCorner;
            hallwayVerticalLength = endRoomYCorner - yBendCorner;
        }
        else if (currDir == Direction.SOUTH||currDir == Direction.NORTH)
        {

            startRoomYCorner = startingRoom.yPos + startingRoom.roomHeight/2;
            startRoomXCorner = startingRoom.xPos + startingRoom.roomWidth / 2;
            
            
            endRoomYCorner = (endingRoom.yPos + endingRoom.roomHeight/2);
            endRoomXCorner = endingRoom.xPos + endingRoom.roomWidth/2;
            xBendCorner = startRoomXCorner;
            yBendCorner = startRoomYCorner+endRoomYCorner-startRoomYCorner;
            hallwayVerticalLength = yBendCorner - startRoomYCorner;
            hallwayHorizontalLength = endRoomXCorner - xBendCorner;
        } else
        {
            Debug.Log("Your Direction function created an error somewhere and you are bad!");
        }
    }
    //gets the direction of the two rooms relative to each other.
    public Direction GetDirection(Room room1,Room room2)
    {
        //going left/right
        if (Mathf.Abs(room1.xPos - room2.xPos) >= Mathf.Abs(room1.yPos - room2.yPos))
        {
            if ((room1.xPos - room2.xPos) >= 0)
            {
                return Direction.WEST;
            }
            else
            {
                return Direction.EAST;
            }
        }
        //going up/down
        else if (Mathf.Abs(room1.xPos - room2.xPos) < Mathf.Abs(room1.yPos - room2.yPos))
        {
            if (room1.yPos - room2.yPos >= 0)
            {
                return Direction.SOUTH;
            }
            else
            {
                return Direction.NORTH;
            }
        }
        else
        {
            Debug.Log("Error this code is bad and does not work!");
            return Direction.ERROR;
        }
    }

    public bool CheckIfHallwayOverlap(Room endRoom, int xHallwayEnd, int yHallwayEnd)
    {
        if ((xHallwayEnd >= endRoom.xPos && xHallwayEnd <= endRoom.xPos + endRoom.roomWidth) &&
            (yHallwayEnd >= endRoom.yPos && yHallwayEnd <= endRoom.yPos + endRoom.roomHeight))
        {
            return true;
        }
        return false;
    }

}
     /**   if (Mathf.Abs(startingRoom.xPos - endingRoom.xPos) > Mathf.Abs(startingRoom.yPos - endingRoom.yPos))
        {
            if (startingRoom.xPos - endingRoom.xPos > 0)
            {
                //Hallway is going to the left
                startRoomXCorner = startingRoom.xPos;
                startRoomYCorner = startingRoom.yPos + startingRoom.roomHeight / 2;
                //endRoomXCorner = endingRoom.xPos;
                hallwayHorizontalLength = (endingRoom.xPos + endingRoom.roomWidth) - startingRoom.xPos;
                endRoomXCorner = startingRoom.xPos + hallwayHorizontalLength;
                endRoomYCorner = startRoomYCorner;
                //check if room and hallway overlap
                if (!CheckIfHallwayOverlap(endingRoom, endRoomXCorner, endRoomYCorner))
                {
                    lShape = true;
                    xBendCorner = endRoomXCorner - 1;
                    yBendCorner = endRoomYCorner;
                    hallwayHorizontalLength--;

                    if (lShape == true)
                    {
                        int bendDir = WhichWayToBend(endingRoom, xBendCorner, yBendCorner);
                        endRoomXCorner = xBendCorner;
                        endRoomYCorner = yBendCorner + (bendDir * Mathf.Abs(endingRoom.yPos - yBendCorner));
                        hallwayVerticalLength = endingRoom.yPos - yBendCorner;
                    }
                }
            }
            else
            {


                startRoomXCorner = startingRoom.xPos + startingRoom.roomWidth;
                startRoomYCorner = startingRoom.yPos + startingRoom.roomHeight / 2;
                //Hallway is going to the right
                hallwayHorizontalLength = endingRoom.xPos - startingRoom.xPos + startingRoom.roomWidth;
                endRoomXCorner = startingRoom.xPos + hallwayHorizontalLength;
                endRoomYCorner = startRoomYCorner;
                //check if room and hallway overlap
                if (!CheckIfHallwayOverlap(endingRoom, endRoomXCorner, endRoomYCorner))
                {
                    lShape = true;
                    xBendCorner = endRoomXCorner + 1;
                    yBendCorner = endRoomYCorner;
                    hallwayHorizontalLength++;

                    if (lShape == true)
                    {
                        int bendDir = WhichWayToBend(endingRoom, xBendCorner, yBendCorner);
                        endRoomXCorner = xBendCorner;
                        endRoomYCorner = yBendCorner + (bendDir * Mathf.Abs(endingRoom.yPos - yBendCorner));
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
                startRoomYCorner = startingRoom.yPos;
                startRoomXCorner = startingRoom.xPos + startingRoom.roomWidth / 2;
                //endRoomXCorner = endingRoom.xPos;
                hallwayVerticalLength = (endingRoom.yPos + endingRoom.roomHeight)-startingRoom.yPos;
                endRoomYCorner = startingRoom.yPos + hallwayVerticalLength;
                endRoomXCorner = startRoomXCorner;
                //check if room and hallway overlap
                if (!CheckIfHallwayOverlap(endingRoom, endRoomXCorner, endRoomYCorner))
                {
                    lShape = true;
                    yBendCorner = endRoomYCorner - 1;
                    xBendCorner = endRoomXCorner;
                    hallwayVerticalLength--;

                    if (lShape == true)
                    {
                        int bendDir = WhichWayToBend(endingRoom, xBendCorner, yBendCorner);
                        endRoomYCorner = yBendCorner;
                        endRoomXCorner = xBendCorner + (bendDir * Mathf.Abs(endingRoom.xPos - xBendCorner));
                        hallwayHorizontalLength = endingRoom.xPos - xBendCorner;
                    }
                }
                else
                {
                    //Hallway going up
                    startRoomYCorner = startingRoom.yPos + startingRoom.roomHeight;
                    startRoomXCorner = startingRoom.xPos + startingRoom.roomWidth / 2;
                    //endRoomXCorner = endingRoom.xPos;
                    hallwayVerticalLength = endingRoom.yPos - (startingRoom.yPos + startingRoom.roomHeight);
                    endRoomYCorner = startingRoom.yPos + hallwayVerticalLength;
                    endRoomXCorner = startRoomXCorner;
                    //check if room and hallway overlap
                    if (!CheckIfHallwayOverlap(endingRoom, endRoomXCorner, endRoomYCorner))
                    {
                        lShape = true;
                        yBendCorner = endRoomYCorner + 1;
                        xBendCorner = endRoomXCorner;
                        hallwayVerticalLength++;

                        if (lShape == true)
                        {
                            int bendDir = WhichWayToBend(endingRoom, xBendCorner, yBendCorner);
                            endRoomYCorner = yBendCorner;
                            endRoomXCorner = xBendCorner + (bendDir * Mathf.Abs(endingRoom.xPos - xBendCorner));
                            hallwayHorizontalLength = endingRoom.xPos - xBendCorner;
                        }
                    }
                }
            }
        }
	}
        */
   
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

//}

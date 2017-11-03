using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leafs{

    public int leafSize = 15;
    public int xpos;
    public int ypos;
    public int width;
    public int height;
    public Leafs leftChild;
    public Leafs rightChild;
    public Room room;
    //public Hallway hallway;

	// Use this for initialization
	public Leafs(int x, int y, int w, int h) {
        xpos = x;
        ypos = y;
        width = w;
        height = h;
	}

    public bool split()
    {
        if(leftChild != null || rightChild != null)
        {
            return false;
        }
        bool splitHorizontal = true;
        if(width > height && width/height >= 1.25) //checks if width is .25 bigger than height
        {
            splitHorizontal = false;
        }
        if (height > width && height / width >= 1.25) //checks if height is .25 bigger than width
        {
            splitHorizontal = true;
        }
        int max = (splitHorizontal ? height : width) - leafSize; //get the max available split size
        if (max <= leafSize)
        {
            return false; //area to small to split
        }
        System.Random random = new System.Random();
        int split = random.Next(leafSize, max);
        if (splitHorizontal)
        {
            leftChild = new Leafs(xpos, ypos, width, split);
            rightChild = new Leafs(xpos, ypos + split, width, height - split);
        }
        else
        {
            leftChild = new Leafs(xpos, ypos, split, height);
            rightChild = new Leafs(xpos + split, ypos, width-split, height);
        }
        return true;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

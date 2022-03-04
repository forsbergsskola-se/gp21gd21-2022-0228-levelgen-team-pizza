using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class DungeonGeneratorJJ : MonoBehaviour
{

    public class Cell
    {
        public bool Visited;
        public bool[] neighbourDirection = new bool[4]; //0 = up, 1=down, 2=Right, 3=left

    }

    public Vector2 gridSize;
    private int startPos = 0;

    private List<Cell> grid;

    private void Start()
    {
        MazeCreator();
    }

    void MazeCreator()
    {
        grid = new List<Cell>();

        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                grid.Add(new Cell());
            }
        }

        int currentCell = startPos;

        Stack<int> path = new Stack<int>();

        Debug.Log(grid.Count);










    }



    void CheckNeighbours()
    {

    }


}

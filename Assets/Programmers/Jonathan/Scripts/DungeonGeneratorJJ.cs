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
                grid.Add(new Cell()); // add a cell to each spot in the grid
            }
        }

        int currentCell = startPos; // 0

        Stack<int> path = new Stack<int>(); // stack for backtracking and keeping a path through the generated maze


        int k = 0;

        while (k<1000) // this controls size --> should probably be modified to handle dynamic instantiation
        {
            k++;
            grid[currentCell].Visited = true;
            List<int> neighbours = CheckNeighbours(currentCell);

            Debug.Log(neighbours.Count);

        }






    }



    List<int> CheckNeighbours(int cell) // LIST<INT> = NEIGHBOURS INT
    {
        List<int> neighbour = new List<int>();

        //Up neighbour
        if (cell - gridSize.x >= 0 && !grid[Mathf.FloorToInt(cell - gridSize.x)].Visited)
        {
            neighbour.Add(Mathf.FloorToInt(cell - gridSize.x));
        }
        //Down neighbour
        if (cell + gridSize.x < grid.Count && !grid[Mathf.FloorToInt(cell + gridSize.x)].Visited)
        {
            neighbour.Add(Mathf.FloorToInt(cell + gridSize.x));
        }

        //Right Neighbour
        if ((cell+1) % gridSize.x !=0 && !grid[Mathf.FloorToInt(cell + 1)].Visited) //  cell%gridsize.x = gridsize.x-1 for the rightmost column --> +1 to each side --> cell+1%gridsize.x = gridsize.x = 0 if on rightmost column. See min 20:00 on https://www.youtube.com/watch?v=gHU5RQWbmWE&t=157s
        {
            neighbour.Add(Mathf.FloorToInt(cell + 1));
        }
        //Left Neighbour
        if (cell % gridSize.x !=0 && !grid[Mathf.FloorToInt(cell - 1)].Visited)
        {
            neighbour.Add(Mathf.FloorToInt(cell -1));
        }
        return neighbour;

    }


}

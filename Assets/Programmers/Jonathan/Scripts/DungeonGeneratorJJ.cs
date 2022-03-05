using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DungeonGeneratorJJ : MonoBehaviour
{
    // public Vector2 gridSize;

    [SerializeField]
    private GameObject testRoom;

    public Vector2 offset;
    private readonly int startPos = 0;

    // private List<Cell> grid;
    // private int xPlacement = 0;
    // private int yPlacement =0;

    private List<Vector2> PlacedRoomCoords = new List<Vector2>();

    private void Start()
    {
        // Instantiate(testRoom, new Vector3(xPlacement*offset.x, 0, - yPlacement*offset.y), Quaternion.identity);
        Instantiate(testRoom, new Vector3(0,0,0), Quaternion.identity);

        // MazeCreator();
    }



    public void GenerateRoom(RoomDirection RoomDir, Vector2 roomCoords)
    {
        Debug.Log($"Room dir: {RoomDir} with room coords: {roomCoords}");

        if (RoomDir == RoomDirection.Down)
        {
            Debug.Log("In down");

            if (!PlacedRoomCoords.Contains(new Vector2(roomCoords.x, roomCoords.y + 1)))
            {
                var room = Instantiate(testRoom, new Vector3(roomCoords.x*offset.x, 0, -(roomCoords.y + 1)*offset.y), Quaternion.identity).GetComponent<RoomHandler>();
                room.roomCoords = new Vector2(roomCoords.x, (roomCoords.y + 1));
                PlacedRoomCoords.Add(new Vector2(roomCoords.x, roomCoords.y + 1));

            }
            else
            {
                Debug.Log("Spot taken");
            }
        }

        if (RoomDir == RoomDirection.Up)
            {

                Debug.Log("In up");
                if (!PlacedRoomCoords.Contains(new Vector2(roomCoords.x, roomCoords.y - 1)))
                {
                    var room = Instantiate(testRoom, new Vector3(roomCoords.x*offset.x, 0, -(roomCoords.y - 1)*offset.y), Quaternion.identity).GetComponent<RoomHandler>();
                    room.roomCoords = new Vector2(roomCoords.x, roomCoords.y - 1);
                    PlacedRoomCoords.Add(new Vector2(roomCoords.x, roomCoords.y - 1));
                }
                else
                {
                    Debug.Log("Spot taken");
                }


            }

            if (RoomDir == RoomDirection.Right)
            {
                Debug.Log("In Right");
                if (!PlacedRoomCoords.Contains(new Vector2(roomCoords.x + 1, roomCoords.y)))
                {

                    var room = Instantiate(testRoom, new Vector3((roomCoords.x + 1)*offset.x, 0, -roomCoords.y*offset.y), Quaternion.identity).GetComponent<RoomHandler>();
                    room.roomCoords = new Vector2(roomCoords.x + 1, roomCoords.y);
                    PlacedRoomCoords.Add(new Vector2(roomCoords.x + 1, roomCoords.y));
                }
                else
                {
                    Debug.Log("Spot taken");
                }
            }

            if (RoomDir == RoomDirection.Left)
            {
                Debug.Log("In left");
                if (!PlacedRoomCoords.Contains(new Vector2(roomCoords.x - 1, roomCoords.y)))
                {

                    var room = Instantiate(testRoom, new Vector3((roomCoords.x - 1)*offset.x, 0, -roomCoords.y*offset.y), Quaternion.identity).GetComponent<RoomHandler>();
                    room.roomCoords = new Vector2(roomCoords.x - 1, roomCoords.y);
                    PlacedRoomCoords.Add(new Vector2(roomCoords.x - 1, roomCoords.y));
                }
                else
                {
                    Debug.Log("Spot taken");
                }

            }
            //ORIGINAL CODE:
            // for (var i = 0; i < gridSize.x; i++)
            // {
            //     for (var j = 0; j < gridSize.y; j++)
            //     {
            //         // Debug.Log($"i: {i} and j: {j}" );
            //         Instantiate(testRoom, new Vector3(i*offset.x, 0, - j*offset.y), Quaternion.identity);
            //     }
            // }
        }


    // private void MazeCreator()
    // {
    //     grid = new List<Cell>();
    //
    //     for (var i = 0; i < gridSize.x; i++)
    //     {
    //         for (var j = 0; j < gridSize.y; j++)
    //         {
    //             grid.Add(new Cell()); // add a cell to each spot in the grid
    //         }
    //     }
    //
    //     var currentCell = startPos; // 0
    //     var path = new Stack<int>(); // stack for backtracking and keeping a path through the generated maze
    //     var k = 0;
    //
    //     while (k < 10) // this controls size --> should probably be modified to handle dynamic instantiation
    //     {
    //         k++;
    //         grid[currentCell].Visited = true;
    //         var neighbours = CheckNeighbours(currentCell);
    //
    //         if (neighbours.Count == 0) // no neighbours
    //         {
    //             if (path.Count == 0) //back at start
    //             {
    //                 break; // done
    //             }
    //
    //             currentCell = path.Pop(); // move backwards in stack
    //         }
    //         else // if we have free neighbour
    //         {
    //             path.Push(currentCell); // add to path
    //             var newCell = neighbours[Random.Range(0, neighbours.Count)];
    //
    //             if (newCell > currentCell) // down or right
    //             {
    //                 if (newCell - 1 == currentCell) // going right
    //                 {
    //                     grid[currentCell].neighbourDirection[2] = true;
    //                     currentCell = newCell;
    //                     grid[currentCell].neighbourDirection[3] = true;
    //                 }
    //                 else //going down
    //                 {
    //                     grid[currentCell].neighbourDirection[1] = true;
    //                     currentCell = newCell;
    //                     grid[currentCell].neighbourDirection[0] = true;
    //                 }
    //             }
    //             else //Up or left
    //             {
    //                 if (newCell + 1 == currentCell) // going left
    //                 {
    //                     grid[currentCell].neighbourDirection[3] = true;
    //                     currentCell = newCell;
    //                     grid[currentCell].neighbourDirection[2] = true;
    //                 }
    //                 else //going up
    //                 {
    //                     grid[currentCell].neighbourDirection[0] = true;
    //                     currentCell = newCell;
    //                     grid[currentCell].neighbourDirection[1] = true;
    //                 }
    //             }
    //         }
    //     }
    //     //Create start room - should be integrated better but temp placement is here
    //
    // }

    // private List<int> CheckNeighbours(int cell) // LIST<INT> = NEIGHBOURS INT
    // {
    //     var neighbour = new List<int>();
    //
    //     //Up neighbour
    //     if (cell - gridSize.x >= 0 && !grid[Mathf.FloorToInt(cell - gridSize.x)].Visited)
    //     {
    //         neighbour.Add(Mathf.FloorToInt(cell - gridSize.x));
    //     }
    //
    //     //Down neighbour
    //     if (cell + gridSize.x < grid.Count && !grid[Mathf.FloorToInt(cell + gridSize.x)].Visited)
    //     {
    //         neighbour.Add(Mathf.FloorToInt(cell + gridSize.x));
    //     }
    //
    //     //Right Neighbour
    //     if ((cell + 1)%gridSize.x != 0 && !grid[Mathf.FloorToInt(cell + 1)].Visited) //  cell%gridsize.x = gridsize.x-1 for the rightmost column --> +1 to each side --> cell+1%gridsize.x = gridsize.x = 0 if on rightmost column. See min 20:00 on https://www.youtube.com/watch?v=gHU5RQWbmWE&t=157s
    //     {
    //         neighbour.Add(Mathf.FloorToInt(cell + 1));
    //     }
    //
    //     //Left Neighbour
    //     if (cell%gridSize.x != 0 && !grid[Mathf.FloorToInt(cell - 1)].Visited)
    //     {
    //         neighbour.Add(Mathf.FloorToInt(cell - 1));
    //     }
    //
    //     return neighbour;
    // }
    //
    // public class Cell
    // {
    //     public bool[] neighbourDirection = new bool[4]; //0 = up, 1=down, 2=Right, 3=left
    //     public bool Visited;
    // }
}

using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DungeonGenerator : MonoBehaviour
{
    // public Vector2 gridSize;

    [SerializeField]
    private GameObject startRoom;

    [SerializeField]
    private List<GameObject> upRooms = new List<GameObject>();
    [SerializeField]
    private List<GameObject> downRooms = new List<GameObject>();
    [SerializeField]
    private List<GameObject> leftRooms = new List<GameObject>();
    [SerializeField]
    private List<GameObject> rightRooms = new List<GameObject>();
    public Vector2 offset;
    // private readonly int startPos = 0;

    // private List<Cell> grid;
    // private int xPlacement = 0;
    // private int yPlacement =0;

    private readonly List<Vector2> OccupiedSpots = new List<Vector2>();

    private void Start()
    {
        var startRoom = Instantiate(this.startRoom, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<RoomHandler>(); // spawn start room at 0,0,0
        OccupiedSpots.Add(new Vector2(startRoom.roomCoords.x,startRoom.roomCoords.y));
        // MazeCreator();
    }

    public void GenerateRoom(RoomDirection RoomDir, Vector2 roomCoords)
    {

        if (RoomDir == RoomDirection.Down)
        {
            if (!OccupiedSpots.Contains(new Vector2(roomCoords.x, roomCoords.y + 1))) // if there is no room in the next spot to spawn in
            {
                //spawn room
                var room = Instantiate(downRooms[Random.Range(0,downRooms.Count)], new Vector3(roomCoords.x*offset.x, 0, -(roomCoords.y + 1)*offset.y), Quaternion.identity).GetComponent<RoomHandler>();
                //update room cords on room
                room.roomCoords = new Vector2(roomCoords.x, roomCoords.y + 1);
                //Add the new spot to the occupied spots list
                OccupiedSpots.Add(new Vector2(roomCoords.x, roomCoords.y + 1));
            }
            //TODO: REMOVE DEBUG STATEMENTS
            else
            {
                Debug.Log("Spot taken");
            }
        }

        if (RoomDir == RoomDirection.Up)
        {
            if (!OccupiedSpots.Contains(new Vector2(roomCoords.x, roomCoords.y - 1)))
            {
                var room = Instantiate(upRooms[Random.Range(0,upRooms.Count)], new Vector3(roomCoords.x*offset.x, 0, -(roomCoords.y - 1)*offset.y), Quaternion.identity).GetComponent<RoomHandler>();
                room.roomCoords = new Vector2(roomCoords.x, roomCoords.y - 1);
                OccupiedSpots.Add(new Vector2(roomCoords.x, roomCoords.y - 1));
            }
            else
            {
                Debug.Log("Spot taken");
            }
        }

        if (RoomDir == RoomDirection.Right)
        {
            if (!OccupiedSpots.Contains(new Vector2(roomCoords.x + 1, roomCoords.y)))
            {
                var room = Instantiate(rightRooms[Random.Range(0,rightRooms.Count)], new Vector3((roomCoords.x + 1)*offset.x, 0, -roomCoords.y*offset.y), Quaternion.identity).GetComponent<RoomHandler>();
                room.roomCoords = new Vector2(roomCoords.x + 1, roomCoords.y);
                OccupiedSpots.Add(new Vector2(roomCoords.x + 1, roomCoords.y));
            }
            else
            {
                Debug.Log("Spot taken");
            }
        }

        if (RoomDir == RoomDirection.Left)
        {
            if (!OccupiedSpots.Contains(new Vector2(roomCoords.x - 1, roomCoords.y)))
            {
                var room = Instantiate(leftRooms[Random.Range(0,leftRooms.Count)], new Vector3((roomCoords.x - 1)*offset.x, 0, -roomCoords.y*offset.y), Quaternion.identity).GetComponent<RoomHandler>();
                room.roomCoords = new Vector2(roomCoords.x - 1, roomCoords.y);
                OccupiedSpots.Add(new Vector2(roomCoords.x - 1, roomCoords.y));
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

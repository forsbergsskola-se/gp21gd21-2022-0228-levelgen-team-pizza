using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DungeonGenerator : MonoBehaviour
{


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


    private readonly List<Vector2> OccupiedSpots = new List<Vector2>();

    private void Start()
    {
        var startRoom = Instantiate(this.startRoom, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<RoomHandler>(); // spawn start room at 0,0,0
        OccupiedSpots.Add(new Vector2(startRoom.roomCoords.x,startRoom.roomCoords.y));
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


    }

}

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


    private readonly List<Vector2> occupiedSpots = new List<Vector2>();

    private void Start()
    {
        var startRoom = Instantiate(this.startRoom, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<SectionHandler>(); // spawn start room at 0,0,0
        occupiedSpots.Add(new Vector2(startRoom.roomCoords.x,startRoom.roomCoords.y));
    }

    public void GenerateRoom(RoomDirection roomDir, Vector2 roomCoords)
    {

        if (roomDir == RoomDirection.Down)
        {
            if (!occupiedSpots.Contains(new Vector2(roomCoords.x, roomCoords.y + 1))) // if there is no room in the next spot to spawn in
            {
                //spawn room
                var room = Instantiate(downRooms[Random.Range(0,downRooms.Count)], new Vector3(roomCoords.x*offset.x, 0, -(roomCoords.y + 1)*offset.y), Quaternion.identity).GetComponent<SectionHandler>();
                //update room cords on room
                room.roomCoords = new Vector2(roomCoords.x, roomCoords.y + 1);
                //Add the new spot to the occupied spots list
                occupiedSpots.Add(new Vector2(roomCoords.x, roomCoords.y + 1));
            }
            //TODO: REMOVE DEBUG STATEMENTS
            else
            {
                Debug.Log("Spot taken");
            }
        }

        if (roomDir == RoomDirection.Up)
        {
            if (!occupiedSpots.Contains(new Vector2(roomCoords.x, roomCoords.y - 1)))
            {
                var room = Instantiate(upRooms[Random.Range(0,upRooms.Count)], new Vector3(roomCoords.x*offset.x, 0, -(roomCoords.y - 1)*offset.y), Quaternion.identity).GetComponent<SectionHandler>();
                room.roomCoords = new Vector2(roomCoords.x, roomCoords.y - 1);
                occupiedSpots.Add(new Vector2(roomCoords.x, roomCoords.y - 1));
            }
            else
            {
                Debug.Log("Spot taken");
            }
        }

        if (roomDir == RoomDirection.Right)
        {
            if (!occupiedSpots.Contains(new Vector2(roomCoords.x + 1, roomCoords.y)))
            {
                var room = Instantiate(rightRooms[Random.Range(0,rightRooms.Count)], new Vector3((roomCoords.x + 1)*offset.x, 0, -roomCoords.y*offset.y), Quaternion.identity).GetComponent<SectionHandler>();
                room.roomCoords = new Vector2(roomCoords.x + 1, roomCoords.y);
                occupiedSpots.Add(new Vector2(roomCoords.x + 1, roomCoords.y));
            }
            else
            {
                Debug.Log("Spot taken");
            }
        }

        if (roomDir == RoomDirection.Left)
        {
            if (!occupiedSpots.Contains(new Vector2(roomCoords.x - 1, roomCoords.y)))
            {
                var room = Instantiate(leftRooms[Random.Range(0,leftRooms.Count)], new Vector3((roomCoords.x - 1)*offset.x, 0, -roomCoords.y*offset.y), Quaternion.identity).GetComponent<SectionHandler>();
                room.roomCoords = new Vector2(roomCoords.x - 1, roomCoords.y);
                occupiedSpots.Add(new Vector2(roomCoords.x - 1, roomCoords.y));
            }
            else
            {
                Debug.Log("Spot taken");
            }
        }


    }

}

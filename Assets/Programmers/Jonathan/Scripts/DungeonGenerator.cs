using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DungeonGenerator : MonoBehaviour
{


    [SerializeField]
    private GameObject startRoom;

    [SerializeField]
    private List<GameObject> upSections = new List<GameObject>();
    [SerializeField]
    private List<GameObject> downSections = new List<GameObject>();
    [SerializeField]
    private List<GameObject> leftSections = new List<GameObject>();
    [SerializeField]
    private List<GameObject> rightSections = new List<GameObject>();
    public Vector2 offset;


    public  List<Vector2> occupiedSpots = new List<Vector2>();

    private void Start()
    {
        var startSection = Instantiate(this.startRoom, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<SectionHandler>(); // spawn start room at 0,0,0
        occupiedSpots.Add(new Vector2(startSection.sectionCoords.x,startSection.sectionCoords.y));
    }

    public void GenerateSection(sectionDirection sectionDir, Vector2 sectionCoords)
    {

        if (sectionDir == sectionDirection.Down)
        {
            if (!occupiedSpots.Contains(new Vector2(sectionCoords.x, sectionCoords.y + 1))) // if there is no room in the next spot to spawn in
            {
                //spawn room
                var section = Instantiate(downSections[Random.Range(0,downSections.Count)], new Vector3(sectionCoords.x*offset.x, 0, -(sectionCoords.y + 1)*offset.y), Quaternion.identity).GetComponent<SectionHandler>();
                section.transform.parent = transform;

                //TODO: Section rotate 0-90-180-270 degrees.

                //update room cords on room
                section.sectionCoords = new Vector2(sectionCoords.x, sectionCoords.y + 1);
                //Add the new spot to the occupied spots list
                occupiedSpots.Add(new Vector2(sectionCoords.x, sectionCoords.y + 1));
            }
        }

        if (sectionDir == sectionDirection.Up)
        {
            if (!occupiedSpots.Contains(new Vector2(sectionCoords.x, sectionCoords.y - 1)))
            {
                var section = Instantiate(upSections[Random.Range(0,upSections.Count)], new Vector3(sectionCoords.x*offset.x, 0, -(sectionCoords.y - 1)*offset.y), Quaternion.identity).GetComponent<SectionHandler>();
                section.transform.parent = transform;
                section.sectionCoords = new Vector2(sectionCoords.x, sectionCoords.y - 1);
                occupiedSpots.Add(new Vector2(sectionCoords.x, sectionCoords.y - 1));
            }
        }

        if (sectionDir == sectionDirection.Right)
        {
            if (!occupiedSpots.Contains(new Vector2(sectionCoords.x + 1, sectionCoords.y)))
            {
                var section = Instantiate(rightSections[Random.Range(0,rightSections.Count)], new Vector3((sectionCoords.x + 1)*offset.x, 0, -sectionCoords.y*offset.y), Quaternion.identity).GetComponent<SectionHandler>();
                section.transform.parent = transform;
                section.sectionCoords = new Vector2(sectionCoords.x + 1, sectionCoords.y);
                occupiedSpots.Add(new Vector2(sectionCoords.x + 1, sectionCoords.y));
            }
        }

        if (sectionDir == sectionDirection.Left)
        {
            if (!occupiedSpots.Contains(new Vector2(sectionCoords.x - 1, sectionCoords.y)))
            {
                var section = Instantiate(leftSections[Random.Range(0,leftSections.Count)], new Vector3((sectionCoords.x - 1)*offset.x, 0, -sectionCoords.y*offset.y), Quaternion.identity).GetComponent<SectionHandler>();
                section.transform.parent = transform;
                section.sectionCoords = new Vector2(sectionCoords.x - 1, sectionCoords.y);
                occupiedSpots.Add(new Vector2(sectionCoords.x - 1, sectionCoords.y));
            }
        }
    }
}

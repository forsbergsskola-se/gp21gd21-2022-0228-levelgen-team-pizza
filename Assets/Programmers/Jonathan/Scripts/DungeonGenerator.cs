using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DungeonGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject startSection;

    [SerializeField]
    private List<GameObject> upSections = new List<GameObject>();
    [SerializeField]
    private List<GameObject> downSections = new List<GameObject>();
    [SerializeField]
    private List<GameObject> leftSections = new List<GameObject>();
    [SerializeField]
    private List<GameObject> rightSections = new List<GameObject>();
    public Vector2 offset;

    private int[] sectionRotation = {
        0,
        90,
        180,
        270
    };

    public  List<Vector2> occupiedSpots = new List<Vector2>();

    private void Start()
    {
        var startSection = Instantiate(this.startSection, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<SectionHandler>(); // spawn start room at 0,0,0
        occupiedSpots.Add(new Vector2(startSection.SectionCoords.x,startSection.SectionCoords.y));
    }


    //TODO: Rotation of rooms seem to work, but the pivot needs to be set to center before implementation.

    public void GenerateSection(sectionDirection sectionDir, Vector2 sectionCoords)
    {
        if (sectionDir == sectionDirection.Down)
        {
            if (!occupiedSpots.Contains(new Vector2(sectionCoords.x, sectionCoords.y + 1))) // if there is no room in the next spot to spawn in
            {
                Debug.Log(sectionCoords);

                //spawn room
                var section = Instantiate(downSections[Random.Range(0,downSections.Count)], new Vector3(sectionCoords.x*offset.x, 0, -(sectionCoords.y + 1)*offset.y), Quaternion.identity).GetComponent<SectionHandler>();
                SetRandomRotationOfSection(section);
                //update room cords on room
                section.SectionCoords = new Vector2(sectionCoords.x, sectionCoords.y + 1);
                //Add the new spot to the occupied spots list
                occupiedSpots.Add(new Vector2(sectionCoords.x, sectionCoords.y + 1));
            }
        }

        if (sectionDir == sectionDirection.Up)
        {
            if (!occupiedSpots.Contains(new Vector2(sectionCoords.x, sectionCoords.y - 1)))
            {
                var section = Instantiate(upSections[Random.Range(0,upSections.Count)], new Vector3(sectionCoords.x*offset.x, 0, -(sectionCoords.y - 1)*offset.y), Quaternion.identity).GetComponent<SectionHandler>();
                SetRandomRotationOfSection(section);

                section.SectionCoords = new Vector2(sectionCoords.x, sectionCoords.y - 1);
                occupiedSpots.Add(new Vector2(sectionCoords.x, sectionCoords.y - 1));
            }
        }

        if (sectionDir == sectionDirection.Right)
        {
            if (!occupiedSpots.Contains(new Vector2(sectionCoords.x + 1, sectionCoords.y)))
            {
                var section = Instantiate(rightSections[Random.Range(0,rightSections.Count)], new Vector3((sectionCoords.x + 1)*offset.x, 0, -sectionCoords.y*offset.y), Quaternion.identity).GetComponent<SectionHandler>();
                SetRandomRotationOfSection(section);

                section.SectionCoords = new Vector2(sectionCoords.x + 1, sectionCoords.y);
                occupiedSpots.Add(new Vector2(sectionCoords.x + 1, sectionCoords.y));
            }
        }

        if (sectionDir == sectionDirection.Left)
        {
            if (!occupiedSpots.Contains(new Vector2(sectionCoords.x - 1, sectionCoords.y)))
            {
                var section = Instantiate(leftSections[Random.Range(0,leftSections.Count)], new Vector3((sectionCoords.x - 1)*offset.x, 0, -sectionCoords.y*offset.y), Quaternion.identity).GetComponent<SectionHandler>();
                SetRandomRotationOfSection(section);

                section.SectionCoords = new Vector2(sectionCoords.x - 1, sectionCoords.y);
                occupiedSpots.Add(new Vector2(sectionCoords.x - 1, sectionCoords.y));
            }
        }
    }
    private void SetRandomRotationOfSection(SectionHandler section)
    {
        // Vector3 pivot = section.transform.position + new Vector3(50.4f, 0, 50.4f);
        // section.transform.RotateAround(pivot, Vector3.up, 90);
        // section.transform.GetChild(0).eulerAngles = new Vector3(0, 90, 0);
    }
}

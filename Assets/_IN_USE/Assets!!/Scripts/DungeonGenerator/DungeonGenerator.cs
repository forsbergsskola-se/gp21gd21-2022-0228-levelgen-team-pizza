using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject startSection;

    [SerializeField]
    private WeightedGOTable sectionTable;

    public Vector2 offset;


    public List<Vector2> occupiedSpots = new List<Vector2>();

    private void Start()
    {
        var startSection = Instantiate(this.startSection, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<SectionHandler>(); // spawn start room at 0,0,0
        occupiedSpots.Add(new Vector2(startSection.SectionCoords.x, startSection.SectionCoords.y));
    }


    public void GenerateSection(sectionDirection sectionDir, Vector2 sectionCoords)
    {
        var newPosY = sectionCoords.y; // should probably use int coords.
        var newPosX = sectionCoords.x;

        if (sectionDir == sectionDirection.Down)
        {
            newPosY = sectionCoords.y + 1;
        }

        if (sectionDir == sectionDirection.Up)
        {
            newPosY = sectionCoords.y - 1;
        }

        if (sectionDir == sectionDirection.Right)
        {
            newPosX = sectionCoords.x + 1;
        }

        if (sectionDir == sectionDirection.Left)
        {
            newPosX = sectionCoords.x - 1;
        }

        if (!occupiedSpots.Contains(new Vector2(newPosX, newPosY)))
        {
            var section = Instantiate(sectionTable.PickGO(), new Vector3(newPosX*offset.x, 0, -newPosY*offset.y), Quaternion.identity).GetComponent<SectionHandler>();
            section.SectionCoords = new Vector2(newPosX, newPosY);
            occupiedSpots.Add(new Vector2(newPosX, newPosY));
        }
    }
}

using System.Collections.Generic;
using UnityEngine;


public class DungeonGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject startSection;

    [SerializeField]
    private WeightedGOTable sectionTable;

    public Vector2 offset;

    // private List<NavMeshSurface> sectionNavMeshSurface = new List<NavMeshSurface>();

    public  List<Vector2> occupiedSpots = new List<Vector2>();

    private void Start()
    {
        var startSection = Instantiate(this.startSection, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<SectionHandler>(); // spawn start room at 0,0,0
        // sectionNavMeshSurface.Add(startSection.transform.GetChild(0).GetComponent<NavMeshSurface>());
        // StartCoroutine(BakeNavMesh());
        occupiedSpots.Add(new Vector2(startSection.SectionCoords.x,startSection.SectionCoords.y));
    }


    public void GenerateSection(sectionDirection sectionDir, Vector2 sectionCoords)
    {
        if (sectionDir == sectionDirection.Down)
        {
            if (!occupiedSpots.Contains(new Vector2(sectionCoords.x, sectionCoords.y + 1))) // if there is no room in the next spot to spawn in
            {
                //spawn room
                var section = Instantiate(sectionTable.PickGO(), new Vector3(sectionCoords.x*offset.x, 0, -(sectionCoords.y + 1)*offset.y), Quaternion.identity).GetComponent<SectionHandler>();

                // sectionNavMeshSurface.Add(section.transform.GetChild(0).GetComponent<NavMeshSurface>());
                // StartCoroutine(BakeNavMesh());
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
                var section = Instantiate(sectionTable.PickGO(), new Vector3(sectionCoords.x*offset.x, 0, -(sectionCoords.y - 1)*offset.y), Quaternion.identity).GetComponent<SectionHandler>();
                // var section = Instantiate(upSections[Random.Range(0,upSections.Count)], new Vector3(sectionCoords.x*offset.x, 0, -(sectionCoords.y - 1)*offset.y), Quaternion.identity).GetComponent<SectionHandler>();
                // sectionNavMeshSurface.Add(section.transform.GetChild(0).GetComponent<NavMeshSurface>());
                // StartCoroutine(BakeNavMesh());
                section.SectionCoords = new Vector2(sectionCoords.x, sectionCoords.y - 1);
                occupiedSpots.Add(new Vector2(sectionCoords.x, sectionCoords.y - 1));
            }
        }

        if (sectionDir == sectionDirection.Right)
        {
            if (!occupiedSpots.Contains(new Vector2(sectionCoords.x + 1, sectionCoords.y)))
            {
                var section = Instantiate(sectionTable.PickGO(), new Vector3((sectionCoords.x + 1)*offset.x, 0, -sectionCoords.y*offset.y), Quaternion.identity).GetComponent<SectionHandler>();
                // sectionNavMeshSurface.Add(section.transform.GetChild(0).GetComponent<NavMeshSurface>());
                // StartCoroutine(BakeNavMesh());
                // BakeNavMesh(section.transform.GetChild(0).GetComponent<NavMeshSurface>());
                section.SectionCoords = new Vector2(sectionCoords.x + 1, sectionCoords.y);
                occupiedSpots.Add(new Vector2(sectionCoords.x + 1, sectionCoords.y));
            }
        }

        if (sectionDir == sectionDirection.Left)
        {
            if (!occupiedSpots.Contains(new Vector2(sectionCoords.x - 1, sectionCoords.y)))
            {
                var section = Instantiate(sectionTable.PickGO(), new Vector3((sectionCoords.x - 1)*offset.x, 0, -sectionCoords.y*offset.y), Quaternion.identity).GetComponent<SectionHandler>();
                // sectionNavMeshSurface.Add(section.transform.GetChild(0).GetComponent<NavMeshSurface>());
                // StartCoroutine(BakeNavMesh());
                // BakeNavMesh(section.transform.GetChild(0).GetComponent<NavMeshSurface>());
                section.SectionCoords = new Vector2(sectionCoords.x - 1, sectionCoords.y);
                occupiedSpots.Add(new Vector2(sectionCoords.x - 1, sectionCoords.y));
            }
        }
    }

  // public IEnumerator BakeNavMesh()
  //  {
  //
  //       foreach (var navMeshSurface in sectionNavMeshSurface)
  //       {
  //           if (navMeshSurface != null && !navMeshSurface.transform.parent.GetComponent<SectionHandler>().hasANavmesh)
  //           {
  //               yield return new WaitForSeconds(0.2f);
  //
  //               navMeshSurface.BuildNavMesh();
  //               navMeshSurface.GetComponent<SectionHandler>().hasANavmesh = true;
  //               // break;
  //           }
  //       }
  //
  //       yield return null;
  //  }
}

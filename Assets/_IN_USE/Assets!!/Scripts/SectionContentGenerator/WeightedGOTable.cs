using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "Object table", menuName = "Object Table/Object table")]
public class WeightedGOTable : ScriptableObject
{
    public string GoTableName;
    public int GoTableID;

    public float TotalProbabilityWeight;
    [Space]
    public List<GO> GoList;
    private float pickedNumber;

    private void OnValidate()
    {
        ValidateTable();
    }

    private void ValidateTable()
    {
        if (GoList == null || GoList.Count <= 0)
        {
            return;
        }

        float currentProbabilityWeightMax = 0f;

        foreach (GO go in GoList)
        {
            if (go.ProbabilityWeight < 0)
            {
                Debug.Log("You can't have negative probability weight!");
                go.ProbabilityWeight = 0f;
            }
            else
            {
                go.ProbabilityRangeFrom = currentProbabilityWeightMax;
                currentProbabilityWeightMax += go.ProbabilityWeight;
                go.ProbabilityRangeTo = currentProbabilityWeightMax;
            }
        }
        TotalProbabilityWeight = currentProbabilityWeightMax;
        foreach (GO go in GoList)
        {
            go.ProbabilityPercent = go.ProbabilityWeight/TotalProbabilityWeight*100;
        }
    }

    public GameObject PickGO()
    {
        pickedNumber = Random.Range(0, TotalProbabilityWeight);
        foreach (GO go in GoList)
        {
            if (pickedNumber > go.ProbabilityRangeFrom && pickedNumber < go.ProbabilityRangeTo)
            {
                if (go == null)
                {
                    Debug.LogError("ERROR: No gameobject set in table slot");
                }
                return go.GameObj;
            }
        }
        Debug.LogError("GO couldn't be picked... Be sure that all of your active GameObject Tables (GO-class)  have assigned at least one GO! Returning NULL");
        //reset picked number in last method dependent on it (in this case, pick GO)
        pickedNumber = 0;
        return null;
    }

    [Serializable]
    public class GO
    {
        public float ProbabilityWeight;
        public float ProbabilityPercent;
        [HideInInspector]
        public float ProbabilityRangeFrom;
        [HideInInspector]
        public float ProbabilityRangeTo;
        public GameObject GameObj;
    }
}


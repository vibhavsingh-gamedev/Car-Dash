using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    [SerializeField] private GameObject[] pathPrefab;
    [SerializeField] private GameObject firstPath;
    [SerializeField] private int pathCount;
    private float zPathSize;
    public List<GameObject> pathList = new List<GameObject>();
    private const float positionBais = 0f;

    public int listPathIndex = 0;

    public float destroyDistance;

    // Reference the other cars manager
   [SerializeField] OtherCarsManager otherCarsManager;


    private void Start()
    {
        zPathSize = firstPath.transform.GetChild(0).GetComponent<Renderer>().bounds.size.z;
        pathList.Add(firstPath);

        SpawnPath();
        StartCoroutine(RepositionPath());
    }

    void SpawnPath()
    {
        for (int i = 0; i < pathCount; i++)
        {
            Vector3 pathPosition = pathList[pathList.Count - 1].transform.position + Vector3.forward * zPathSize;
            pathPosition.z += positionBais;
            GameObject path = Instantiate(pathPrefab[Random.Range(0, pathPrefab.Length)], pathPosition, Quaternion.identity);
            path.transform.parent = transform;
            pathList.Add(path);
        }
    }

    // Make the path endless
    IEnumerator RepositionPath()
    {
        while (true)
        {
            destroyDistance = Camera.main.transform.position.z - 15f;

            if(pathList[listPathIndex].transform.position.z < destroyDistance) {
                Vector3 nextPathPos = FarestPath().transform.position + Vector3.forward * zPathSize; // Find the next pos
                nextPathPos.z += positionBais;

                pathList[listPathIndex].transform.position = nextPathPos;// Move the path

                otherCarsManager.CheckAndDisableCarPath();

                listPathIndex++;

                if(listPathIndex == pathList.Count)
                    listPathIndex = 0;
            }
            otherCarsManager.FindCarAndReset();
            yield return null;
        }
    }

    GameObject FarestPath()
    {
        GameObject thisPath = pathList[0];

        for (int i = 0; i < pathList.Count; i++) 
        {
            if (pathList[i].transform.position.z > thisPath.transform.position.z)
                thisPath = pathList[i];
        }
        return thisPath;
    }
}

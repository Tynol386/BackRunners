using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chunks_generation : MonoBehaviour
{
   /* [SerializeField]
    private GameObject chunk1;
    [SerializeField]
    private GameObject chunk2;

    [SerializeField]
    private GameObject point1;
    [SerializeField]
    private GameObject point2;
*/

    public List<GameObject> listOfChunks = new List<GameObject>();
    public List<GameObject> listOfPoints = new List<GameObject>();
    public Dictionary<GameObject, bool> usedPoints = new Dictionary<GameObject, bool>();
    public List<int> listOfRandom = new List<int>();

    void Start()
    {
        for(int i=0; i<listOfPoints.Count; i++)
        {
            usedPoints[listOfPoints[i]] = false;
        }

        for (int i=0; i<listOfChunks.Count; i++)
        {
            int random = Random.Range(0, listOfPoints.Count);
            
            if (usedPoints[listOfPoints[random]] == false)
            {
                Debug.Log("t");
                if (!CheckIfExist(random))
                {
                    Debug.Log(random.ToString());
                    listOfChunks[i].transform.position = new Vector3(listOfPoints[random].transform.position.x, 0, listOfPoints[random].transform.position.z);
                    usedPoints[listOfPoints[random]] = true;
                    listOfRandom.Add(random);
                }
            }
            else
            {
                while (CheckIfExist(random))
                {
                    random = Random.Range(0, listOfPoints.Count);
                }
                if (!CheckIfExist(random))
                {
                    Debug.Log(random.ToString());
                    listOfChunks[i].transform.position = new Vector3(listOfPoints[random].transform.position.x, 0, listOfPoints[random].transform.position.z);
                    usedPoints[listOfPoints[random]] = true;
                    listOfRandom.Add(random);
                }
            }
        }
    }
    bool CheckIfExist(int random)
    {
        foreach (int oldRand in listOfRandom)
        {
            if (random == oldRand)
            {
                return true;
            }
        }
        return false;
    }
}

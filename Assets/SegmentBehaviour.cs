using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentBehaviour : MonoBehaviour
{
    [SerializeField] private Transform spots;

    public void SpawnContent(GameObject goal, GameObject balcony)
    {
        for (int i = 0; i < 3; i++)
        {
            int randomizer = Random.Range(0, 100);

            if(randomizer<=30)
                Instantiate(balcony, spots.GetChild(Random.Range(0, spots.childCount)));
            //else
            //    Instantiate(goal, spots.GetChild(Random.Range(0, spots.childCount)));


        }
    }

    public void DespawnContent()
    {
        foreach (Transform child in spots)
        {
            if(child.childCount > 0)
            {
                foreach  (Transform childchild in child)
                {
                    Destroy(childchild.gameObject);
                }
            }
        }
    }
}

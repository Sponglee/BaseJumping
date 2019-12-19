using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AltmeterBehaviour : MonoBehaviour
{

    public RectTransform yellowZone;
    public RectTransform redZone;

    public RectTransform fillArea;


    private void Start()
    {
        SetUpZones();
    }

    public void SetUpZones()
    {
        GameObject[] triggers = GameObject.FindGameObjectsWithTag("ParachuteTrigger");

                Debug.Log("S " + triggers.Length);
        foreach (var item in triggers)
        {
            if (item.GetComponent<ParachuteTrigger>().IsRedZone)
            {
                redZone.sizeDelta = new Vector2(fillArea.rect.width * ((LevelMover.Instance.groundHolder.transform.position.y - item.transform.position.y) / LevelMover.Instance.groundHolder.position.y), redZone.rect.height);
                Debug.Log("RED");
            }
            else
            {
                yellowZone.sizeDelta = new Vector2(fillArea.rect.width * ((LevelMover.Instance.groundHolder.transform.position.y - item.transform.position.y) / LevelMover.Instance.groundHolder.position.y)- redZone.rect.width, yellowZone.rect.height);
                Debug.Log("YELLOW");
            }
        }
    }

    public void AlarmGlowToggle(string target, bool toggle)
    {

        switch (target)
        {
            case "Yellow":
                yellowZone.GetComponent<Animator>().SetBool("Alert", toggle);
                break;
            case "Red":
                redZone.GetComponent<Animator>().SetBool("Alert",toggle);
                break;
            default:
                break;
        }
       
    }


   
}

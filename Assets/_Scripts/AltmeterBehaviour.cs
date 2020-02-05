using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AltmeterBehaviour : MonoBehaviour
{

    public Slider altmeter;

    public RectTransform yellowZone;
    public RectTransform redZone;

    public RectTransform fillArea;


    private void Start()
    {
        SetUpZones();
        transform.parent.gameObject.SetActive(false);
        LevelMover.altmeterUpdateEvent.AddListener(AltmeterUpdateSlider);
    }

    public void SetUpZones()
    {
        GameObject[] triggers = GameObject.FindGameObjectsWithTag("ParachuteTrigger");
                       
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
                {
                    if(!LevelMover.instance.ParachuteBool)
                        redZone.GetComponent<Animator>().SetBool("Alert",toggle);
                }
                break;
            default:
                break;
        }
       
    }

    public void AltmeterUpdateSlider ()
    {
        //Calculate arrow rotation depending on height from levelMover 

        //Debug.Log(altmeterScale * LevelMover.instance.altitudeRatio);

       altmeter.value  = LevelMover.instance.altitudeRatio;
    }


}

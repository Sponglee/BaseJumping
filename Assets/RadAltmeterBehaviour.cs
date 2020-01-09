using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadAltmeterBehaviour : MonoBehaviour
{

    public Image yellowZone;
    public Image redZone;

    public Transform arrow;
    public float altmeterScale = -360f;

    private void Start()
    {
        SetUpZones();
        transform.parent.gameObject.SetActive(false);

        LevelMover.altmeterUpdateEvent.AddListener(AltmeterUpdateArrow);
        arrow.eulerAngles = new Vector3 (0, 0, Mathf.Deg2Rad*altmeterScale);
    }

    public void SetUpZones()
    {
        GameObject[] triggers = GameObject.FindGameObjectsWithTag("ParachuteTrigger");

        foreach (var item in triggers)
        {
            if (item.GetComponent<ParachuteTrigger>().IsRedZone)
            {
                redZone.fillAmount = (LevelMover.Instance.groundHolder.transform.position.y - item.transform.position.y) / LevelMover.Instance.groundHolder.position.y;
            }
            else
            {
                yellowZone.fillAmount = ((LevelMover.Instance.groundHolder.transform.position.y - item.transform.position.y) / LevelMover.Instance.groundHolder.position.y) + redZone.fillAmount;
            }
        }
    }


    public void AltmeterUpdateArrow()
    {
        //Calculate arrow rotation depending on height from levelMover 

        Debug.Log(altmeterScale * LevelMover.instance.altitudeRatio);

        arrow.eulerAngles = new Vector3(0, 0, altmeterScale * LevelMover.instance.altitudeRatio);
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
                    if (!LevelMover.instance.ParachuteBool)
                        redZone.GetComponent<Animator>().SetBool("Alert", toggle);
                }
                break;
            default:
                break;
        }

    }



}

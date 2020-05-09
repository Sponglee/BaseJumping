using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeController : MonoBehaviour
{

    public Transform playerDollyHolder;
    public CinemachineVirtualCamera vcam;
    public CinemachineDollyCart cart;
    public float cartSpeed = 25f;


  

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTER " + other.tag);
        if(other.CompareTag("Player"))
        {
            PlayerMover.Instance.transform.SetParent(playerDollyHolder);
            PlayerMover.Instance.transform.localPosition = Vector3.zero;
            PlayerMover.Instance.charachterTransform.localPosition = Vector3.zero;
            PlayerMover.Instance.playerOffset = Vector3.zero;
            PlayerMover.Instance.inputManager.enabled = false;
            PlayerMover.Instance.inputManager = PlayerMover.Instance.inputManagers[2];
            LevelMover.Instance.startSpeed = 0f;
            LevelMover.Instance.LevelSpeed = 0f;
            vcam.Priority = 999;
            cart.m_Speed = cartSpeed;
            StartCoroutine(StartMoving());
        }
    }

    private IEnumerator StartMoving()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos =Vector3.zero;

        while (cart.m_Position < cart.m_Path.MaxPos)
        {
            transform.position = Vector3.Lerp(startPos, endPos, cart.m_Position / cart.m_Path.MaxPos);
            yield return null;
        }

        //transform.Translate(Vector3.up*55f);
        ReturnToNormal();
    }

    private void ReturnToNormal()
    {
        PlayerMover.Instance.transform.SetParent(GameManager.Instance.transform);
        PlayerMover.Instance.transform.localPosition = Vector3.zero;
        PlayerMover.Instance.charachterTransform.localPosition = Vector3.zero;
        PlayerMover.Instance.transform.rotation = Quaternion.Euler(Vector3.zero);
        PlayerMover.Instance.inputManager = PlayerMover.Instance.inputManagers[0];
        PlayerMover.Instance.inputManager.enabled = true;
        LevelMover.Instance.startSpeed = 1f;
        LevelMover.Instance.LevelSpeed = 1f;

        vcam.Priority = 0;
        CancelInvoke();
        transform.position += Vector3.up * 10f;
    }
}

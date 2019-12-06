using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform holder;

    private void Update()
    {
        holder.Translate(transform.localPosition);
    }

}

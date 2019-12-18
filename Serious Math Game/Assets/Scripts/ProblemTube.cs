using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemTube : MonoBehaviour
{
    public int tubeID;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.OnPlayerEnterTube(tubeID);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCollider : MonoBehaviour
{
    // Start is called before the first frame update
    bool isTrigged = false;
    private void OnTriggerEnter(Collider other)
    {
        if (isTrigged) return;
        isTrigged = true;
        if (other.GetComponent<CharacterController>())
        {
            EventController.Instance.m_PuzzleController.gameObject.SetActive(true);
            StartCoroutine(EventController.Instance.m_PuzzleController.BeginPuzzle());
        }
    }
}

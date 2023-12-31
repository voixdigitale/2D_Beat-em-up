using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    [SerializeField] private int _checkpointNumber;

    private bool _checkpointTriggered = false;

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("ENTERED CHECKPOINT");
        if (_checkpointTriggered)
            return;
        GameEvents.current.CheckPointEnter(_checkpointNumber);
        _checkpointTriggered = true;
        Destroy(gameObject);
    }
}
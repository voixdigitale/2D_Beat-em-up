using UnityEngine;

public interface IGrabbable {
    void GetGrabbed(int teamId, GameObject hitSource);
}
using UnityEngine;

public interface IHitable {
    void TakeHit(int teamId, Entity hitSource);
}
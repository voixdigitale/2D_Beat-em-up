using UnityEngine;

public class AnimationEvents : MonoBehaviour {
    public void AttackEvent() {
        GetComponentInParent<Attack>().OnAttackAnimation.Invoke(GetComponentInParent<Entity>());
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour {
    [SerializeField] private float _flashTime = .1f;

    private SpriteRenderer _spriteRenderer;
    private Entity _entity;

    private void Awake() {
        _entity = GetComponent<Entity>();
        _spriteRenderer = _entity.GetAnimator().gameObject.GetComponent<SpriteRenderer>();
    }

    public void StartFlash() {
        StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine() {
        
        _spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(_flashTime);

        _spriteRenderer.color = Color.white;
    }
}
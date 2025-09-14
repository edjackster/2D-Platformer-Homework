using UnityEngine;

public class VampireAttackView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void ShowAura(bool show)
    {
        _spriteRenderer.enabled = show;
    }
}

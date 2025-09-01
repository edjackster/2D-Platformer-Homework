using UnityEngine;

public class Gem : MonoBehaviour
{
    [field: SerializeField] public int Value { get; private set; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered Gem");

        if (other.TryGetComponent<GemCollector>(out var collector) == false)
            return;
        
        collector.AddGem(this);
        Destroy(gameObject);
    }
}

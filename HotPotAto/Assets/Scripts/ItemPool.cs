using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemPool", menuName = "ItemPool", order = 1)]
public class ItemPool : ScriptableObject
{
    [SerializeField] private Item[] pool;
    public Item[] Pool { get { return this.pool; }}

    public Item GetRandomItem(int difficulty) {
        return pool[Random.Range(0, pool.Length)];
    }
}

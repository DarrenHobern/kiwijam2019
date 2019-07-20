using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemPool", menuName = "ItemPool", order = 1)]
public class ItemPool : ScriptableObject
{
    [SerializeField] private Ingredient[] pool;
    public Ingredient[] Pool { get { return this.pool; }}

    public Ingredient GetRandomItem(int difficulty) {
        return pool[Random.Range(0, pool.Length)];
    }
}

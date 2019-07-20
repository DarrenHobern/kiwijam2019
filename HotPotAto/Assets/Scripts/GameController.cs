using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private int spawnDelay = 3;
    [SerializeField] private int spawnRate = 1;
    [SerializeField] private Transform lane1;
    [SerializeField] private Transform lane2;
    [SerializeField] private ItemPool itemPool;
    [SerializeField] private int difficulty = 0;
    private int laneIndex = 0;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Debug.LogWarning("Only one Game Controller can exist");
            Destroy(gameObject);
        }

        Debug.Assert(itemPool != null);
        StartGame();
    }

    public void StartGame() {
        InvokeRepeating("SpawnItem", spawnDelay, spawnRate);
    }

    public void SpawnItem() {
        laneIndex = (laneIndex + 1) % 2;
        Transform lane = laneIndex == 0 ? lane1 : lane2;
        GameObject item = Instantiate(itemPrefab, lane);
        item.GetComponent<Item>().SetIngredient(itemPool.GetRandomItem(difficulty));

    }
}

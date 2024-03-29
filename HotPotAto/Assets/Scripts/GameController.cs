﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private PlayerMovement player1;
    [SerializeField] private PlayerMovement player2;
    [SerializeField] private int spawnDelay = 3;
    [SerializeField] private float spawnRate = 1;
    [SerializeField] private Transform lane1;
    [SerializeField] private Transform lane2;
    [SerializeField] private ItemPool itemPool;
    [SerializeField] private int difficulty = 0;
    [SerializeField] private Image player1HealthBar;
    [SerializeField] private Image player2HealthBar;
    private int laneIndex = 0;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Debug.LogWarning("Only one Game Controller can exist");
            Destroy(gameObject);
        }

        Debug.Assert(itemPool != null);
        Debug.Assert(player1 != null);
        Debug.Assert(player2 != null);

        player1.OnHealthChange += UpdateHealthBars;
        player2.OnHealthChange += UpdateHealthBars;
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame() {
        InvokeRepeating("SpawnItem", spawnDelay, spawnRate);
        RecipeManager.Instance.NewRecipe();
    }

    public void SpawnItem() {
        laneIndex = (laneIndex + 1) % 2;
        Transform lane = laneIndex == 0 ? lane1 : lane2;
        GameObject item = Instantiate(itemPrefab, lane.transform.position, itemPrefab.transform.rotation, null);
        item.GetComponent<Item>().SetIngredient(itemPool.GetRandomItem(difficulty));
    }

    public PlayerMovement GetOtherPlayer(PlayerMovement me) {
        if (player1.name.Equals(me.name)) {
            return player2;
        }
        return player1;
    }

    private void UpdateHealthBars() {
        player1HealthBar.fillAmount = player1.GetHealth();
        player2HealthBar.fillAmount = player2.GetHealth();

        CheckIfGameOver();
    }

    public void HealPlayers(int amount) {
        player1.SetHealth(player1.GetHealth() + amount * 10);
        player2.SetHealth(player2.GetHealth() + amount * 10);
    }

    private void CheckIfGameOver() {
        if (player1.GetHealth() <= 0 || player2.GetHealth() <= 0) {
            this.GameOver();
        }
    }

    public void GameOver() {
        Debug.Log("Game over");
        MenuScript.Instance.ToEndOver();
    }
}

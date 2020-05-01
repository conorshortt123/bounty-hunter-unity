using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private AudioClip dieSound;
    [SerializeField] private int enemyHealth;
    [SerializeField] private int playerDamage = 50;
    public Transform heart1, heart2, heart3, heart4, heart5;
    public int enemyDamage;
    private int currentHealth;

    // == public fields ==
    // used from GameController enemy.ScoreValue
    public int ScoreValue { get { return scoreValue; } }

    // delegate type to use for event
    public delegate void EnemyKilled(Enemy enemy);

    // create static method to be implemented in the listener
    public static EnemyKilled EnemyKilledEvent;

    // == private fields ==
    [SerializeField] private int scoreValue = 10;

    void Start()
    {
        currentHealth = enemyHealth;
    }

    private void OnTriggerEnter2D(Collider2D whatHitMe)
    {
        // If I get hit by the player, destroy
        // Get component of the whatHitMe game object (which is the player game object)
        var player = whatHitMe.GetComponent<CharacterController2D>();
        var bullet = whatHitMe.GetComponent<Bullet>();

        if (player)
        {
            // Update players health by damage output of enemy.
            int health = player.UpdatePlayerHealth(enemyDamage);

            if(health <= 0)
            {
                Destroy(player.gameObject);
                player.setPlayerStatus(false);
            }
        }
        if(bullet)
        {
            Destroy(bullet.gameObject);
            currentHealth -= playerDamage;

            if(!(gameObject.name == "Tumbleweed(Clone)"))
            {
                UpdateHealth();
            }

            if(currentHealth <= 0)
            {
                Destroy(gameObject);

                PublishEnemyKilledEvent();
                currentHealth = enemyHealth;
            }
        }
    }

    private void PublishEnemyKilledEvent()
    {
        // make sure somebody is listening
        if (EnemyKilledEvent != null)
        {
            EnemyKilledEvent(this);
        }
    }

    public void UpdateHealth()
    {
        if (heart1)
        {
            heart1.GetComponent<Image>().enabled = (currentHealth > 0);
            heart2.GetComponent<Image>().enabled = (currentHealth > 50);
            heart3.GetComponent<Image>().enabled = (currentHealth > 100);
        }
        if (heart4 && heart5)
        {
            heart4.GetComponent<Image>().enabled = (currentHealth > 150);
            heart5.GetComponent<Image>().enabled = (currentHealth > 200);
        }
    }

}

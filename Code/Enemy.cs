using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health = 150f;

    public GameObject laser;
    public float lasersnelheid;
    public float shotsPerSeconds = 0.5f;

    public AudioClip FireSound;
    public AudioClip DeathSound;

    ScoreKeeperScript _scoreKeeper;
    public int ScoreValue = 10;
    // Use this for initialization

    void OnTriggerEnter2D(Collider2D col)
    {
        SpelerProjectile missile = col.GetComponent<SpelerProjectile>();
        if (missile)
        {
            health -= missile.GetDamage();
            if (health <= 0)
            {
                Die();
            }
            missile.Hit();
        }
    }

    void Start() {
        _scoreKeeper = GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeperScript>();
    }

    // Update is called once per frame
    void Update() {
        float mogelijkheid = Time.deltaTime * shotsPerSeconds;
        if (Random.value < mogelijkheid) {
            Fire();
        }
    }

    void Die() {
        AudioSource.PlayClipAtPoint(DeathSound, transform.position);
        _scoreKeeper.Score(ScoreValue);
        Destroy(gameObject);
    }

    void Fire() {
        GameObject beam = Instantiate(laser, transform.position, Quaternion.identity) as GameObject;
        beam.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -lasersnelheid);
        AudioSource.PlayClipAtPoint(FireSound, transform.position);
    }
}

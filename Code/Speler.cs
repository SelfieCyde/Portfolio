using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speler : MonoBehaviour {

    float stuur;
    float xmin;
    float xmax;

    public float padding = 0.7f;
    public float snelheid;

    public GameObject laser;
    public float straalsnelheid;
    public float vuurRate;

    public float health;
    public Slider Healthbar;

    public AudioClip FireSound;
    public AudioClip DeathSound;

    public LevelManager LevelManager;

    ScoreKeeperScript _scoreKeeper;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        EnemyProjectile missile = collider.gameObject.GetComponent<EnemyProjectile> ();
        if (missile) {
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0) {
                Die();
            }
        }
    }

    void Die() {
        AudioSource.PlayClipAtPoint(DeathSound, transform.position);
        Destroy(gameObject);
        LevelManager.LaadLevel("Lose");
    }

    // Use this for initialization
    void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 meestlinks = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 meestrechts = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = meestlinks.x + padding;
        xmax = meestrechts.x - padding;

        Healthbar.value = health;

        _scoreKeeper = GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeperScript>();
        _scoreKeeper.Reset();
    }
	
	// Update is called once per frame
	void Update () {
        stuur = Mathf.Clamp((stuur += (Input.GetAxis("Horizontal") * Time.deltaTime * snelheid)), xmin, xmax);
        transform.position = new Vector2(stuur, transform.position.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.000001f, vuurRate);
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            CancelInvoke ("Fire");
        }

        Healthbar.value = health;
    }

    void Fire() {
        Vector3 startPositie = transform.position + new Vector3(0, 1.2f, 0);
        GameObject straal = Instantiate(laser, startPositie, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(FireSound, transform.position);
        straal.GetComponent<Rigidbody2D>().velocity = new Vector3(0, straalsnelheid, 0);
    }
}

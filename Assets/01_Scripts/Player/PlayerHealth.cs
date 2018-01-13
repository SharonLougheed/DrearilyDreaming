using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int currentHealth,    //amount of damage player takes before dying
               maxHealth;       //set max limit of players health(not a const variable because this leaves it open to upgrading
    //public AudioClip awwClip,
    //                 ouchClip,      //clip of "Ouch" when the player gets hurt
    //                 deathClip;

    //[HideInInspector] public Transform respawnPoint;
    //[HideInInspector] public static bool isPlayerDead;
    //[HideInInspector] public static int damageTaken, damageHealed;

    //private AudioSource source;
    private const int DEAD = 0;

    //void Awake() {
    //    source = GetComponent<AudioSource>();
    //}
    //void Start() {
    //    respawnPoint = gameObject.transform;
    //    isPlayerDead = false;
    //}
    //public void HealPlayer(int h) {
    //    StartCoroutine(Aww(h));
    //}
    //public void DamagePlayer(int d) {
    //        StartCoroutine(Ouch(d));
    //    if (currentHealth <= DEAD)
    //        StartCoroutine(Death());
    //}
    //    IEnumerator Death() {
    //        //play death sound clip
    //        Time.timeScale = 0.75f;
    //        source.clip = deathClip;
    //        source.Play();
    //        yield return new WaitForSeconds(5f);
    //        isPlayerDead = true;
    //        Time.timeScale = 0f;
    //        source.Stop();
    //        source.clip = null;
    //    }
    //    IEnumerator Ouch(int d) {
    //        currentHealth -= d;
    //        source.clip = ouchClip;
    //        source.Play();
    //        yield return new WaitForSeconds(ouchClip.length);
    //        source.Stop();
    //        source.clip = null;
    //    }
    //    IEnumerator Aww(int h) {
    //        currentHealth += h;
    //        source.clip = awwClip;
    //        source.Play();
    //        yield return new WaitForSeconds(source.clip.length);
    //        source.Stop();
    //        source.clip = null;
    //    }    
}
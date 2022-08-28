using UnityEngine;

public class Player : MonoBehaviour
{
    public float BounceSpeed;
    public Rigidbody Rigidbody;
    public Platform CurrentPlatform;
    public Game Game;
    private AudioSource audio;

    [SerializeField]
    private ParticleSystem _loseParticleSystem;

    [SerializeField]
    private ParticleSystem _winParticleSystem;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Bounce()
    {
        audio.Play();
        Rigidbody.velocity = new Vector3(0, BounceSpeed, 0);
    }

    public void ReachFinish()
    {
        Game.OnPlayerReachFinish();

        Rigidbody.velocity = Vector3.zero;
        _winParticleSystem.Play();
    }

    public void Die()
    {
        Game.OnPlayerDied();
        Rigidbody.velocity = Vector3.zero;
        _loseParticleSystem.Play();
    }
}
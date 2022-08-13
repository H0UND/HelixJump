using UnityEngine;

public class Sector : MonoBehaviour
{
    public bool IsGood = true;
    public Material GoodMaterial;
    public Material BadMaterial;
    private Rigidbody rb;
    private MeshCollider collider;
    private AudioSource audio;

    private void Awake()
    {
        UpdateMaterial();
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<MeshCollider>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
        audio = GetComponent<AudioSource>();
    }

    private void UpdateMaterial()
    {
        var sectorRenderer = GetComponent<Renderer>();
        sectorRenderer.sharedMaterial = IsGood ? GoodMaterial : BadMaterial;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision == null)
        {
            return;
        }

        if (!collision.collider.TryGetComponent(out Player player))
        {
            return;
        }

        Vector3 normal = -collision.contacts[0].normal.normalized;
        float dot = Vector3.Dot(normal, Vector3.up);
        if (dot < 0.5)
        {
            return;
        }

        if (IsGood)
        {
            player.Bounce();
        }
        else
        {
            player.Die();
        }
    }

    public void DestroySection()
    {
        audio.Play();
        rb.constraints = RigidbodyConstraints.None;
        collider.enabled = false;
        rb.AddForce(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f), ForceMode.Impulse);
        rb.AddTorque(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f), ForceMode.Impulse);
        
    }

    private void OnValidate()
    {
        UpdateMaterial();
    }
}
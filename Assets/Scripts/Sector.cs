using UnityEngine;

public class Sector : MonoBehaviour
{
    public bool IsGood = true;
    public Material GoodMaterial;
    public Material BadMaterial;
    private Rigidbody rb;
    private MeshCollider collider;
    private AudioSource audio;
    private bool IsDestroyed = false;
    private float _dissolveValue = 1f;
    [SerializeField]
    private Material _dissolveMaterial ;
    private Renderer _renderer;

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
        _renderer = GetComponent<Renderer>();
        _renderer.material = IsGood ? GoodMaterial : BadMaterial;
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
        IsDestroyed = true;
    }

    private void Update()
    {
        if (IsDestroyed)
        {
            if (_dissolveValue >= 0)
            {
                _dissolveValue -= 0.5f * Time.deltaTime;
                if (IsGood)
                {
                    _renderer.material.SetFloat("Vector1_bc88ab5321164720bec72f25548014c2", _dissolveValue);
                    Debug.Log($"SetFloat {_dissolveValue}");
                }
                else
                {
                    _renderer.material.SetFloat("Vector1_59d089c58b7e4ffaae71c35202e7e163", _dissolveValue);
                }
            }
        }
    }

    private void OnValidate()
    {
        UpdateMaterial();
    }
}
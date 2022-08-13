using UnityEngine;

public class Platform : MonoBehaviour
{
    private Sector[] _sectors;

    [SerializeField]
    private Transform SectorsTransform;

    private void Awake()
    {
        _sectors = SectorsTransform.GetComponentsInChildren<Sector>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.CurrentPlatform = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(gameObject.name);
        foreach (var sector in _sectors)
        {
            if (sector == null)
            {
                continue;
            }

            sector.DestroySection();
        }
    }
}
using UnityEngine;
using System.Collections;

public class PortalHandeler : MonoBehaviour
{
    [SerializeField]
    private GameObject connectedPortal;

    private Transform spawnPoint;

    private bool oneWay = false;

    private PortalHandeler connectedPortalHandler;

    private bool justSpawned = false;

    void Awake()
    {
        if (connectedPortal.GetComponent<PortalHandeler>() != null)
            oneWay = false;
        else
            oneWay = true;

        if (!oneWay)
            connectedPortalHandler = connectedPortal.GetComponent<PortalHandeler>();

        spawnPoint = transform.GetChild(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.BALL.ToString()) && justSpawned == false)
        {
            if (!oneWay)
                connectedPortalHandler.spawned = true;

            other.transform.position = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y + 0.8f, spawnPoint.transform.position.z);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Tags.BALL.ToString()) && !oneWay)
        {
            justSpawned = false;
        }
    }

    public bool spawned
    {
        get { return justSpawned; }
        set { justSpawned = value; }
    }
}

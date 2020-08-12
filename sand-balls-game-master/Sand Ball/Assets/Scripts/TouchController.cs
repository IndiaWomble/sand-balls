using UnityEngine;

[RequireComponent(typeof(Camera))]
public class TouchController : MonoBehaviour
{
    public GameObject cylinderPrefab;
    public float planeDistance;
    public GameObject board;
    public GameObject StartScreen;
    private PlaneDeformer[] sandPlanes;
    private Vector3[] planeCenters;
    private Ray ray;
    private RaycastHit hit;
    private Camera cam;
    private bool startTouching;

    void Awake()
    {
        cam = this.transform.GetComponent<Camera>();
        sandPlanes = board.GetComponentsInChildren<PlaneDeformer>();
        planeCenters = new Vector3[sandPlanes.Length];
        for (int i = 0; i < planeCenters.Length; i++)
        {
            planeCenters[i] = sandPlanes[i].gameObject.transform.GetComponent<Renderer>().bounds.center;
        }
        startTouching = false;
    }

    private void Update()
    {
        startTouching = !StartScreen.activeSelf;
    }

    private void FixedUpdate()
    {
        if (startTouching && Input.GetMouseButton(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            doformMesh();
        }
    }


    private void doformMesh()
    {
        if (Physics.Raycast(ray, out hit))
        {
            for (int i = 0; i < planeCenters.Length; i++)
            {
                if ((planeCenters[i] - hit.point).sqrMagnitude < planeDistance)
                {
                    sandPlanes[i].deformThePlane(hit.point);
                }
            }
            if (hit.transform.tag == "Ring")
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }

    public void defromToHoles(Vector3 position, float radius)
    {
        for (int i = 0; i < planeCenters.Length; i++)
        {
            if ((planeCenters[i] - position).sqrMagnitude < planeDistance)
            {
                sandPlanes[i].puthole(position, radius);
            }
        }
    }
}
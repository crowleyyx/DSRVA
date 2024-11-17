using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using TMPro;


[RequireComponent(typeof(ARRaycastManager))]
public class MeasureDistances : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Instantiates this prefab on a plane at the touch location.")]
    GameObject m_PlacedPrefab;


    public GameObject placedPrefab
    {
        get { return m_PlacedPrefab; }
        set { m_PlacedPrefab = value; }
    }
    public GameObject spawnedObject { get; private set; }
    public Camera FirstPersonCamera;
    public GameObject pointPrefab;
    public GameObject linePrefab;
    public TMP_Text textPrefab;
    public Canvas parent;
    public List<GameObject> points = new List<GameObject>();
    public List<TMP_Text> distances = new List<TMP_Text>();
    public TMP_Text totalDistance;
    void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
    }
    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        Touch touch;
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            touchPosition = default;
            return false;
        }
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;
        if (m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = s_Hits[0].pose;
            spawnedObject = Instantiate(m_PlacedPrefab, hitPose.position, hitPose.rotation);
            points.Add(spawnedObject);
        }
    }
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
    ARRaycastManager m_RaycastManager;
}

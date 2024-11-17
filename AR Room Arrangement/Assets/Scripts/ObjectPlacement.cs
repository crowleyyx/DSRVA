using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using TMPro;


[RequireComponent(typeof(ARRaycastManager))]
public class ObjectPlacement : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Instantiates this prefab on a plane at the touch location.")]

    public static ObjectPlacement instance;

    public GameObject placedPrefab;

    public GameObject spawnedObject { get; private set; }
    public Camera FirstPersonCamera;
    void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
        instance = this;
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
            spawnedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
        }

        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    Debug.Log(placedPrefab.name);
        //    Instantiate(placedPrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        //}    
    }
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
    ARRaycastManager m_RaycastManager;
}

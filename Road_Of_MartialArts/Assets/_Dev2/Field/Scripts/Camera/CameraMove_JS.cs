using UnityEngine;

public class CameraMove_JS : MonoBehaviour
{
    public Transform target;
    public Vector2 minBounds; // 카메라 이동 가능 최소 좌표
    public Vector2 maxBounds; // 카메라 이동 가능 최대 좌표
    private Vector3 offset; 

    private bool justSnapped = false;
    
    public static CameraMove_JS instance;

    void Start()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;

        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
        //desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);

        if (justSnapped)
        {
            transform.position = desiredPosition;
            justSnapped = false;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 3f);
        }

    }

    public void SnapToTarget()
    {
        if (target == null) return;

        Vector3 snapPosition = target.position + offset;
        snapPosition.x = Mathf.Clamp(snapPosition.x, minBounds.x, maxBounds.x);
        // snapPosition.y = Mathf.Clamp(snapPosition.y, minBounds.y, maxBounds.y);

        transform.position = snapPosition;
        justSnapped = true;
    }
}

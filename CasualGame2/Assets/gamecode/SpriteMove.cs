using UnityEngine;

// This script is responsible for sprite movement (left or right), timed lifetime
// based on specified lifetime or at certain X value, and mouse interaction
public class SpriteMove : MonoBehaviour
{
    public enum moveDirectionSelection
    {
        Right, Left
    }
    //default movement
    public moveDirectionSelection moveDirection = moveDirectionSelection.Left;
    public float moveSpeed = 3f;
    public bool isPickedUp = false;

    Vector3 movement = Vector3.zero;

    //lifetime
    public bool isTimedLife = true;
    public float lifetime = 5f;
    float elapsedlifetime = 0f;
    public bool despawnAtPoint = true; // if this is used, despawning will not be determined based on lifetime.
    public Transform despawnPoint;     // but based on offset position of this object.

    //mouse interaction
    Vector3 screenPoint, offset;
    float firstY;

    void OnEnable()
    {
        // Randomly rotate the object when activated
        float z = Random.Range(0, 180);
        Quaternion _rotation = Quaternion.Euler(0, 0, z);
        transform.rotation = _rotation;
    }

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed *= moveDirection == moveDirectionSelection.Right ? 1f : -1f;

        if (!despawnPoint)
        {
            GameObject _despawn = GameObject.FindGameObjectWithTag("despawnpoint");
            if (_despawn)
            {
                despawnPoint = _despawn.transform;
                _despawn = null;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // When the object is active and not picked up then it should move
        if (!isPickedUp || gameObject.activeInHierarchy)
        {
            float x = transform.position.x;
            x += moveSpeed * Time.deltaTime;
            movement = new Vector3(x, transform.position.y, transform.position.z);

            transform.position = movement;
        }

        // Despawning either by timer or position
        // done when the object is not picked up by the mouse
        if (isTimedLife && !isPickedUp)
        {
            if (despawnAtPoint)
            {
                if (transform.position.x < despawnPoint.position.x)
                {
                    Deactivate();
                    Data.Missed += 1;
                }
            }
            else
            {
                elapsedlifetime += Time.deltaTime;
                if (elapsedlifetime > lifetime)
                {
                    elapsedlifetime = 0f;
                    Deactivate();
                }
            }
        }
    }

    public void Deactivate()
    {
        isPickedUp = false; // set false to stop movement
        gameObject.SetActive(false);
    }

    //mouse interaction
    void OnMouseDown()
    {
        firstY = transform.position.y;
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        float _mx = Input.mousePosition.x, _my = Input.mousePosition.y;
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(_mx, _my, screenPoint.z));

        isPickedUp = true;
    }
    void OnMouseDrag()
    {
        float _mx = Input.mousePosition.x, _my = Input.mousePosition.y;
        Vector3 _cursorScreenPoint = new Vector3(_mx, _my, screenPoint.z);
        Vector3 _cursorposition = Camera.main.ScreenToWorldPoint(_cursorScreenPoint) + offset;

        transform.position = _cursorposition;
    }
    void OnMouseUp()
    {
        transform.position = new Vector3(transform.position.x, firstY, transform.position.z);

        isPickedUp = false;
    }
}

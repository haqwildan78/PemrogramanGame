using UnityEngine;

///////////////////////////////////////////////////////////////////
///                     PadActor.cs
///             Logic for pad entity/actor.
/// Controls for pad from axis defined in the project settings.
/// Or by mouse Y position if `m_MouseTakeover` is true.
///////////////////////////////////////////////////////////////////
public class PadActor : MonoBehaviour
{
    public float m_Speed = 128.0f;
    public float m_MaxSpeed = 0.02f;
    public string m_AxisController;
    public bool m_MouseTakeover = false;
    
    private const float arenaHeightMax = 3.6f;
    private float moveVelocity;

    void Update()
    {
        if (!m_MouseTakeover)
        {
            moveVelocity = Input.GetAxis(m_AxisController) * m_Speed * Time.deltaTime;
            float nextPosition = transform.position.y + moveVelocity;

            // Vibe check: Check arena boundary
            if (nextPosition > arenaHeightMax || nextPosition < arenaHeightMax * -1f)
            {
                moveVelocity = 0f;
            }

            moveVelocity = Mathf.Clamp(moveVelocity, m_MaxSpeed * -1, m_MaxSpeed);

            // Move
            transform.position += new Vector3(0, moveVelocity, 0);
        }
        if (m_MouseTakeover)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 move = new Vector3(transform.position.x, mousePosition.y, transform.position.z);
            transform.position = move;
        }
    }
}
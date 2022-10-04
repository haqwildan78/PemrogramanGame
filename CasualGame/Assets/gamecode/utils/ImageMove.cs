using UnityEngine;

public class ImageMove : MonoBehaviour
{
    int[] posX = new int[] { 0, -18, -36, -54 };
    int index = 0;
    public AudioSource[] AudioFX;

    // Start is called before the first frame update
    void Start()
    {
        AudioFX[index].Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (index < posX.Length - 1)
            {
                index++;
                AudioFX[index].Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (index > 0)
            {
                index--;
                AudioFX[index].Play();
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(posX[index], transform.position.y), 50 * Time.deltaTime);
    }
}

using UnityEngine;

public class Cloud : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 3.8) {
            transform.position += new Vector3(0.02f, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -3.8) {
            transform.position += new Vector3(-0.02f, 0, 0);
        }
    }
}

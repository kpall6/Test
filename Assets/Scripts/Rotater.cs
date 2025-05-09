using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField] float speed = 4f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 360f * speed * Time.deltaTime));
    }
}
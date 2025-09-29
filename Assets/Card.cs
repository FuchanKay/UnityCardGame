using UnityEditor.ShaderGraph.Internal;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UIElements;

public class Card : MonoBehaviour
{
    private Vector2 point;
    private float speed = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        point = new Vector2(this.transform.position.x, this.transform.position.y);
    }

    // Update is called once per frame  
    void Update()
    {
        float dx = this.point.x - this.transform.position.x;
        float dy = this.point.y - this.transform.position.y;

        float magnitude = Mathf.Sqrt(dx * dx + dy * dy);

        dx *= this.speed / magnitude;
        dy *= this.speed / magnitude;

        this.transform.SetPositionAndRotation(new Vector3(this.transform.position.x + dx, this.transform.position.y + dx, 0), new Quaternion());
    }

    public void onDrag()
    {
        point = Mouse.current.position.ReadValue();
    }
}

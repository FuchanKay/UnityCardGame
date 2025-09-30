using UnityEditor.ShaderGraph.Internal;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UIElements;

public class CardBehavior : MonoBehaviour
{
    private Vector2 point;
    public float speed = 0.25f;
    public bool isSelected = false;
    const float MOVEMENT_BUFFER = 0.01f;
    const float UNSELECTED_SCALE = 0.5f;
    const float SELECTED_SCALE = 0.6f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        point = new Vector2(this.transform.position.x, this.transform.position.y);
    }

    // Update is called once per frame  
    void Update()
    {
        if (this.isSelected) this.point = Mouse.current.position.ReadValue();
        float dx = this.point.x - this.transform.position.x;
        float dy = this.point.y - this.transform.position.y;

        float magnitude = Mathf.Pow((dx * dx + dy * dy), 0.25f);

        if (magnitude >= 0.01)
        {
            dx *= this.speed / magnitude;
            dy *= this.speed / magnitude;
        }
        if (Mathf.Abs(dx) < MOVEMENT_BUFFER) dx = 0;
        if (Mathf.Abs(dy) < MOVEMENT_BUFFER) dy = 0;

        this.transform.position = new Vector3(this.transform.position.x + dx, this.transform.position.y + dy, 0);
    }

    public void onDrag()
    {
        point = Mouse.current.position.ReadValue();
    }

    public void select()
    {
        Debug.Log("hello");
        isSelected = !isSelected;
        float scale = isSelected ? SELECTED_SCALE : UNSELECTED_SCALE;
        this.transform.localScale = new Vector3(scale, scale, 0.5f);
    }
}

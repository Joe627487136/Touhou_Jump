using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_script : MonoBehaviour {

    public float movement_offset = 5.0f;
    private float left_offset;
    private float right_offset;

	void Start () {
        float origin_x = transform.position.x;
        left_offset = transform.position.x - 5.0f;
        right_offset = transform.position.x + 5.0f;
    }


    void Movement() {
        float current_transform_horizontal_pos = transform.position.x;
        // if too right, want to move to right, then disable right
        float hor_movement_scale = Input.GetAxis("Horizontal") * Time.deltaTime * 15.0f;
        if ((current_transform_horizontal_pos >= right_offset) && hor_movement_scale > 0){
        }
        // if too left, want to move to left, then disable left
        else if ((current_transform_horizontal_pos <= left_offset) && hor_movement_scale < 0){
        }
        else {
            transform.Translate(hor_movement_scale, 0, 0);
        }
    }
    void Update()
    {
        Movement();
    }
}

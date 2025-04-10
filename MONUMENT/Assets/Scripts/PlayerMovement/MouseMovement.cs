﻿using UnityEngine;

namespace MONUMENT
{
    public class MouseMovement : MonoBehaviour
    {
        private const float MIN_CAM_ANGLE = -90f;
        private const float MAX_CAM_ANGLE = 90f;

        [SerializeField] private Transform cam = null;

        private float sensitvity = SensWriter.DEFAULT_SENS;
        private Vector2 mouseDirection;
        private float mouseX;
        private float mouseY;

        private void Start()
        {
            SaveData data = SaveSystem.Load();

            if (data != null)
            {
                sensitvity = data.sens;
                print($"sens : {sensitvity}");
            }
        }

        private void Update()
        {
            /*if (Input.GetKey(KeyCode.LeftArrow)) { mouseDirection.x -= Time.deltaTime * 180f; }
            if (Input.GetKey(KeyCode.RightArrow)) { mouseDirection.x += Time.deltaTime * 180f; }
            if (Input.GetKey(KeyCode.UpArrow)) { mouseDirection.y += Time.deltaTime * 180f; }
            if (Input.GetKey(KeyCode.DownArrow)) { mouseDirection.y -= Time.deltaTime * 180f; }*/

            mouseX = Input.GetAxisRaw("Mouse X");
            mouseY = Input.GetAxisRaw("Mouse Y");

            Vector2 mouseDirectionChange = new Vector2(mouseX, mouseY);

            mouseDirection += mouseDirectionChange * sensitvity;

            mouseDirection.y = Mathf.Clamp(mouseDirection.y, MIN_CAM_ANGLE, MAX_CAM_ANGLE);

            cam.localRotation = Quaternion.AngleAxis(-mouseDirection.y, Vector3.right);
            transform.localRotation = Quaternion.AngleAxis(mouseDirection.x, Vector3.up);
        }
    }
}
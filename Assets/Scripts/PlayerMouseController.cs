using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    public Camera mainCamera;
    public ScoreController scoreController;

    // Header
    [Header("Ball Movement")]
    public float speed;
    public float rotaionOffset;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotaionOffset));

        Vector3 targerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targerPos.z = 0;
        transform.position = Vector3.MoveTowards(transform.position, targerPos, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            scoreController.IncreaseCurrentScore(1);
            Destroy(collision.gameObject);
        }
    }
}

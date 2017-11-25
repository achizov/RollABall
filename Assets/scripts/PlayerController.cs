using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

  public Text textCount;
  public Text textWin;
  public int speed = 5;

  private Rigidbody _rigidBody;
  private int _count;
  private Vector2 touchOrigin = -Vector2.one;

  void Start () {
    _rigidBody = GetComponent<Rigidbody>();
    textWin.gameObject.SetActive(false);
    PickupObj();
  }


  public void FixedUpdate() {
    float horizontal = 0;
    float vertical = 0;
    #if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0f, vertical);
        move *= speed;

        _rigidBody.AddForce(move);

    #elif UNITY_ANDROID
    if (Input.touchCount > 0) {
      Touch myTouch = Input.touches[0];

      if (myTouch.phase == TouchPhase.Began) {
        touchOrigin = myTouch.position;

      } else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0) {
        Vector2 touchEnd = myTouch.position;
        float x = touchEnd.x - touchOrigin.x;
        float y = touchEnd.y - touchOrigin.y;
        touchOrigin.x = -1;
        if (Mathf.Abs(x) > Mathf.Abs(y)) {
          horizontal = x > 0 ? 1 : -1;
        } else {
          vertical = y > 0 ? 1 : -1;
        }
        
        Vector3 move = new Vector3(horizontal, 0f, vertical);
        move *= speed;

        _rigidBody.AddForce(move);
      }
    }
#endif
  }

  public void OnTriggerEnter(Collider other) {
    if (other.CompareTag("pickup")) {
      other.gameObject.SetActive(false);
      _count++;
      PickupObj();
      if (_count == 7) {
        GameWin();
      }
    }
  }

  private void PickupObj() {
    textCount.text = "Count: " + _count;
  }

  private void GameWin() {
    textWin.text = "Win!!!";
    textWin.gameObject.SetActive(true);
  }
}

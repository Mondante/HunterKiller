using UnityEngine;

public class Detection_Ctrl : MonoBehaviour
{
    Unit_Controller ctrl;
    void Start()
    {
        ctrl = this.gameObject.GetComponentInParent<Unit_Controller>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("detected");
            //Unit_Controller ctrl = this.gameObject.GetComponentInParent<Unit_Controller>();

            if (ctrl != null)
            {
                ctrl.DetectedorNot(1);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Unit_Controller ctrl = this.gameObject.GetComponent<Unit_Controller>();

            if (ctrl != null)
            {
                ctrl.DetectedorNot(0);
            }
        }
    }
}

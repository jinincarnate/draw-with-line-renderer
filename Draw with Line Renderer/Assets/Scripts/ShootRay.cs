using UnityEngine;

public class ShootRay : MonoBehaviour {

    public GameObject linePoint;
    public GameObject parent;
    public float threshold;

    private Vector3 lastPoint;
    private GameObject currentLine;

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            lastPoint = Vector3.zero;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000.0f)) {
                currentLine = Instantiate(parent, hit.point, Quaternion.identity);
            }
        }
        if (Input.GetMouseButton(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000.0f)) {
                Debug.Log(hit.point);
                Vector3 currentPoint = hit.point;
                if (IsNewPointAboveTHreshold(lastPoint, currentPoint)) {
                    GameObject obj = Instantiate(linePoint, currentPoint, Quaternion.identity, currentLine.transform);
                    lastPoint = currentPoint;
                }
            }
        }
    }

    private bool IsNewPointAboveTHreshold(Vector3 oldPoint, Vector3 newPoint) {
        bool above = false;
        above = (newPoint - oldPoint).magnitude > threshold;
        return above;
    }
}

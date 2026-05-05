using UnityEngine;

public class DrawBoxCollider : MonoBehaviour
{
    public Color boxColor = Color.green;

    private BoxCollider box;

    void OnDrawGizmos()
    {
        box = GetComponent<BoxCollider>();
        if (box == null) return;

        Gizmos.color = boxColor;

        // ‰Õ›Ÿ «· ÕÊÌ· «·Õ«·Ì
        Matrix4x4 oldMatrix = Gizmos.matrix;

        // ‰÷»ÿ «·„’›Ê›… Õ”» „ﬂ«‰ Ê œÊ—«‰ «·Ã”„
        Gizmos.matrix = transform.localToWorldMatrix;

        // ‰—”„ «·’‰œÊﬁ
        Gizmos.DrawWireCube(box.center, box.size);

        // ‰—Ã⁄ «·„’›Ê›… «·√’·Ì…
        Gizmos.matrix = oldMatrix;
    }
}

using UnityEngine;

public class DropZone3D : MonoBehaviour
{
    public string expectedShape; // Nom de la forme attendue (ex: "Cube")
    public Transform snapPoint;  // L'endroit exact où placer la forme

    private void OnTriggerEnter(Collider other)
    {
        Renderer objRenderer = other.GetComponent<Renderer>();

        if (other.CompareTag(expectedShape))
        {
            // ✅ Bonne forme
            other.transform.position = snapPoint.position;
            other.transform.rotation = snapPoint.rotation;
            if (objRenderer != null)
                objRenderer.material.color = Color.green;

            Debug.Log("✅ Bonne forme placée : " + expectedShape);
        }
        else
        {
            // ❌ Mauvaise forme
            if (objRenderer != null)
                objRenderer.material.color = Color.red;

            // Retour à la position initiale
            Draggable3D dragScript = other.GetComponent<Draggable3D>();
            if (dragScript != null)
                dragScript.ResetPosition();

            Debug.Log("❌ Mauvaise forme !");
        }
    }
}

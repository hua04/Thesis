using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AppDrag : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

 
    public Transform obj;
    public Camera cam;

    Vector2 objPos;
    Vector2 mousePos;
    float mousePosY, mousePosX;
    public GameObject FileToOpen;


    public void DragHandler(BaseEventData data)
    {
        int lastPosition = AppClickOpen.openFiles.IndexOf(FileToOpen);
        AppClickOpen.openFiles.RemoveAt(lastPosition);
        AppClickOpen.openFiles.Add(FileToOpen);
        Debug.Log("works");
        //update file order
        for (int index = 0; index < AppClickOpen.openFiles.Count; index++)
        {
            GameObject current = AppClickOpen.openFiles[index];
            Canvas myCanvas = current.GetComponent<Canvas>();
            myCanvas.sortingOrder = index;
            Debug.Log(AppClickOpen.openFiles);
        }

        //directs attention towards pointer
        PointerEventData pointerData = (PointerEventData)data;

        //gets pointer movement
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform, pointerData.position, canvas.worldCamera, out position);

        /*NOT WORKING, NEED TO FIX
         * //offsets position of mouse
        objPos = obj.transform.position;//gets player position
        mousePos = Input.mousePosition;//gets mouse postion
        mousePos = cam.ScreenToWorldPoint(mousePos);
        float offsetX = mousePos.x - objPos.x; // Horizontal distance between object and mouse
        float offsetY = mousePos.y - objPos.y; // Vertical distance between object and mouse


        //updates position
        Vector3 newPos = new Vector3(position.x - offsetX, position.y - offsetY, 0); // Apply offset to the new position

        transform.position = canvas.transform.TransformPoint(newPos); // Convert the local position back to world position*/
        transform.position = canvas.transform.TransformPoint(position.x , position.y, 0);
    }
}

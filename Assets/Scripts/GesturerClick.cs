using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GesturerClick : MonoBehaviour, IPointerEnterHandler
{
    public event UnityAction<Vector3> OnClick;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (OnClick != null)
            OnClick.Invoke(eventData.pointerCurrentRaycast.worldPosition);
    }
}
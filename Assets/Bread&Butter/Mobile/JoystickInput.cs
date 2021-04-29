using UnityEngine;
using UnityEngine.EventSystems;


namespace BreadAndButter.Mobile
{

    public enum JoystickAxis
    {
        None,
        Horizontal,
        Vertical
    }
    public class JoystickInput : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        /// <summary>
        /// Tahe input axis value that the joystick represents. 
        /// Both the directions and amount on each axis
        /// </summary>
        public Vector2 Axis { get; private set; } = Vector2.zero;

        [SerializeField]
        private RectTransform handle;
        [SerializeField]
        private RectTransform background;
        [SerializeField, Range(0, 1)]
        private float deadzone = 0.25f;

        private Vector3 initialPosition = Vector3.zero;

        // Start is called before the first frame update
        void Start() => initialPosition = handle.transform.position;
              
        public void OnDrag(PointerEventData _eventData)
        {
            float xDifference = ((background.rect.size.x - handle.rect.size.x) * 0.5f);
            float yDifference = ((background.rect.size.y - handle.rect.size.y) * 0.5f);
            // calculate the Axis of thr input based on the event data and the release position to the backgrounds center
            Axis = new Vector2(
                (_eventData.position.x - background.position.x) / xDifference,
                (_eventData.position.y - background.position.y) / yDifference);
            Axis = (Axis.magnitude > 1.0f) ? Axis.normalized : Axis;

            //Apply the axis position to the handle
            handle.transform.position = new Vector3(
                (Axis.x * xDifference + background.position.x),
                (Axis.y * yDifference + background.position.y));

            Axis = (Axis.magnitude < deadzone) ? Vector2.zero : Axis;
            // Ternary Operator -> Condition ? True : False -> 
        }

        public void OnEndDrag(PointerEventData _eventData)
        {
            // we have let go so reset the Axis and set the original position
            Axis = Vector2.zero;
            handle.transform.position = initialPosition;
        }
        public void OnPointerDown(PointerEventData _eventData) => OnDrag(_eventData);
        public void OnPointerUp(PointerEventData _eventData) => OnEndDrag(_eventData);
    }
}

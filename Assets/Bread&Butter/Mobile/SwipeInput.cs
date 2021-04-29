using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeInput : MonoBehaviour
{
    /// <summary>
    /// Contains all the information about this specific swipe, such as points along the swipe
    /// </summary>
    public class Swipe
    {
        /// <summary>
        /// The list of points along the swipe, added to each frame.
        /// </summary>
        public List<Vector2> positions = new List<Vector2>();
        /// <summary>
        /// The position the swipe started from.
        /// </summary>
        public Vector2 initialPosition = new Vector2();
        /// <summary>
        /// The finger id associated with this swipe.
        /// </summary>
        public int fingerId = 0;

        public Swipe(Vector2 _initialPos, int _fingerId)
        {
            initialPosition = _initialPos;
            fingerId = _fingerId;
            positions.Add(_initialPos);
        }
    }

    /// <summary>
    /// The direction that the flick last occured, positive infinity means no flick occurred
    /// </summary>
    public  Vector2 FlickDirection { get; private set; } = Vector2.positiveInfinity;
    /// <summary>
    /// How hard and far the player flicked, positive infinity means no flick
    /// </summary>
    public  float FlickPower { get; private set; } = float.PositiveInfinity;
    /// <summary>
    /// The count of how many swipes are in progress.
    /// </summary>
    public  int SwipeCount => swipes.Count;

    // Contains all the swipes currently being processed, each key is the corresponding fingerId
    private  Dictionary<int, Swipe> swipes = new Dictionary<int, Swipe>();

    // How long the swipe has been running for
    private float flickTime = 0;
    // The origin point for the occuring swipe
    private Vector2 flickOrigin = Vector2.positiveInfinity;
    // The initiating finger index
    private int initialFingerIndex = -1;

    /// <summary>
    /// Attempts to retrieve the relevant swipe information relating the the passed ID.
    /// </summary>
    /// <param name="_index">The fingerID we are attempting to get the swipe for.</param>
    /// <returns>The corresponding swipe if it exists, otherwise null.</returns>
    public  Swipe GetSwipe(int _index)
    {
        Swipe temp;
        // Out paramater assigns the passed variable to the corresponding key if it exists
        swipes.TryGetValue(_index, out temp);
        return temp;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if there is any touches
        if (Input.touchCount > 0)
        {
            // Loop through all swipes
            foreach (Touch touch in Input.touches)
            {
                // Is this the first frame there was a touch
                if (touch.phase == TouchPhase.Began && flickOrigin.Equals(Vector2.positiveInfinity))
                {
                    flickOrigin = touch.position;
                    initialFingerIndex = touch.fingerId;
                }
                // Is this a completed flick
                else if (touch.phase == TouchPhase.Ended && touch.fingerId == initialFingerIndex && flickTime < 1)
                {
                    CalculateFlick(touch.position);
                }

                // -- Begin Swipe Storage -- //
                if (touch.phase == TouchPhase.Began)
                {
                    swipes.Add(touch.fingerId, new Swipe(touch.position, touch.fingerId));
                }
                else if (touch.phase == TouchPhase.Moved && swipes.TryGetValue(touch.fingerId, out Swipe swipe))
                {
                    // We have a swipe for this finger, so add the new position to the list
                    swipe.positions.Add(touch.position);
                }
                else if ((touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) && swipes.TryGetValue(touch.fingerId, out swipe))
                {
                    // The swipe has ended so remove it
                    swipes.Remove(swipe.fingerId);
                }
                // -- End Swipe Storage -- //
            }

            // Increment the time that this swipe has been running
            flickTime += Time.deltaTime;
        }
        // There isn't so reset swipe data
        else
        {
            ResetSwipe();
        }
    }

    /// <summary>
    /// Calculates the flick based on the origin and the final touch position.
    /// </summary>
    /// <param name="_endTouchPos">The position the touch was when it was ended.</param>
    private void CalculateFlick(Vector2 _endTouchPos)
    {
        // Calculate the flick and flick power
        Vector2 heading = flickOrigin - _endTouchPos;
        FlickPower = heading.magnitude;
        FlickDirection = heading.normalized;

        // Reset the swipe origin
        flickOrigin = Vector2.positiveInfinity;
    }

    /// <summary>
    /// Sets the swipe data back to positive infinity
    /// </summary>
    private void ResetSwipe()
    {
        FlickDirection = Vector2.positiveInfinity;
        FlickPower = float.PositiveInfinity;
        flickOrigin = Vector2.positiveInfinity;
        flickTime = 0;
        initialFingerIndex = -1;
    }
}

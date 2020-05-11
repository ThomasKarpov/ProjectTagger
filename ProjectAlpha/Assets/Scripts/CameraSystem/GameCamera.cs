/*
 * Project Name: Project Alpha
 *       Author: RZU-7
 *         Date: 2020/05/10
 *  Description: Controls the main camera movement and zoom
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class GameCamera : MonoBehaviour
{
    public List<Transform> targets;     // The list of players to keep in focus
    public Vector3 offset;              // The offset from the focus point of the camera
    [Range(0f, 1f)]
    public float smoothingFactor = 0.5f; // The smoothing factor of the camera movement (larger value is slower)

    public float zoomOutBoundary = 40f;         // Zoom out boundary
    public float zoomInBoundary = 10f;          // Zoom in boundary
    public float maxSceneHorizontalDist = 50f; // The maximum horizontal distance the players will be from each other
    private Camera cam;

    private Vector3 velocity;           // Needed for the Vector3.SmoothDamp function

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        // Exit if there is no target
        if (targets.Count == 0)
        {
            return;
        }

        Move();
        Zoom();
    }

    /*
     * @brief Move the camera based on the centered position between the players.
     */
    private void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothingFactor);
    }

    /*
     * @brief Zoom the camera based on the distance between the players
     */
    void Zoom()
    {
        //Debug.Log("Greatest Distance: " + GetGreatestDistance());
        float newZoom = Mathf.Lerp(zoomInBoundary, zoomOutBoundary, GetGreatestDistance() / maxSceneHorizontalDist);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    /*
     * @brief Gets the center point from all the player positions.
     */
    Vector3 GetCenterPoint()
    {
        IsTargetCountZero();

        // For one player, focus on the player
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = EncapsulateAllTargets();

        return bounds.center;
    }

    /*
     * @brief Gets the distance between the players that are furthest away from each other.
     */
    float GetGreatestDistance()
    {
        IsTargetCountZero();

        // Create a new bounds based on the player positions
        var bounds = EncapsulateAllTargets();

        return bounds.size.x;
    }

    /*
     * @brief Checks if the target count is zero
     */
    bool IsTargetCountZero()
    {
        // Exit if there is no target
        if (targets.Count == 0)
        {
            return true;
        }

        return false;
    }

    /*
     * @brief Encapsulates all targets and returns a Bounds object.
     */
    Bounds EncapsulateAllTargets()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
	// configuration parameters
	WaveConfig waveConfig;
	List<Transform> waypoints;
	int waypointIndex = 0;

	// Use this for initialization
	void Start()
	{
		waypoints = waveConfig.GetWaypoints();
		transform.position = waypoints[waypointIndex].transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		Move();
	}

	public void SetWaveConfig(WaveConfig waveConfig)
	{
		this.waveConfig = waveConfig;
	}

	private void Move()
	{
		if (waypointIndex <= waypoints.Count - 1)
		{
			var targetPosition = waypoints[waypointIndex].transform.position;
			var movementSpeed = waveConfig.GetMovementSpeed() * Time.deltaTime;
			transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementSpeed);

			if (transform.position == targetPosition)
			{
				waypointIndex++;
			}
		}
		else
		{
			Destroy(gameObject);
		}
	}
}

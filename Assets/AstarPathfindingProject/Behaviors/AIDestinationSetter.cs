using UnityEngine;
using System.Collections;

namespace Pathfinding {

	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
	public class AIDestinationSetter : VersionedMonoBehaviour {

		public Transform target;
		public float colidableDist;
		private Vector3 spawnPos;
		IAstarAI ai;

		void OnEnable () {
			ai = GetComponent<IAstarAI>();
			spawnPos = transform.position;
			target = GameObject.FindGameObjectWithTag("herobody").transform;
			target.position = new Vector3(target.position.x , target.position.y + 1f, target.position.z);


			if (ai != null) ai.onSearchPath += Update;
		}

		void OnDisable () {
			if (ai != null) ai.onSearchPath -= Update;
		}

		void Update () {
			if (target != null && ai != null)
			{
				if (Mathf.Abs((transform.position - target.position).magnitude) < colidableDist)
					ai.destination = target.position;
				else if (Mathf.Abs((transform.position - target.position).magnitude) >= colidableDist)
					ai.destination = spawnPos;
			}
			else if(target==null)
			{
				target = GameObject.FindGameObjectWithTag("Player").transform;
				ai.destination = transform.position;
			}

		}
	}
}

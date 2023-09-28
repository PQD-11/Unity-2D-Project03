using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace SVS.AI
{
    public class PatrolFlyingPath : MonoBehaviour
    {
        [SerializeField] private List<Transform> patrolPoints = new List<Transform>();
        public int Lenght { get => patrolPoints.Count; }

        [Header("Gizmos parameters")]
        public Color pointColor = Color.blue;
        public float pointSize = 1;
        public Color lineColor = Color.magenta;
        public bool showGizmo = true;

        public struct PathPoint
        {
            public int Index;
            public Vector2 Position;
        }

        public PathPoint GetClosestPathPoint(Vector3 agentPosition)
        {
            var result = patrolPoints
                .Select((point, index) => new { Index = index, Position = (Vector2)point.position, Distance = Vector2.Distance(agentPosition, point.position) })
                .Aggregate((p1, p2) => p1.Distance < p2.Distance ? p1 : p2);
            return new PathPoint { Index = result.Index, Position = result.Position };
        }

        public PathPoint GetNextPathPoint(int index)
        {
            var newIndex = (index + 1) % patrolPoints.Count;
            return new PathPoint { Index = newIndex, Position = patrolPoints[newIndex].position };
        }

        private void OnDrawGizmos()
        {
            if (!showGizmo) { return; }

            if (patrolPoints.Count == 0) { return; }

            for (int i = patrolPoints.Count - 1; i >= 0; i--)
            {
                if (patrolPoints[i] == null) { return; }

                Gizmos.color = pointColor;
                Gizmos.DrawSphere(patrolPoints[i].position, pointSize);

                if (patrolPoints.Count == 1 || i == 0) { break; }

                Gizmos.color = lineColor;
                Gizmos.DrawLine(patrolPoints[i].position, patrolPoints[i - 1].position);
            }

            if (patrolPoints.Count > 2)
            {
                Gizmos.color = lineColor;
                Gizmos.DrawLine(patrolPoints[patrolPoints.Count - 1].position, patrolPoints[0].position);
            }
        }
    }
}


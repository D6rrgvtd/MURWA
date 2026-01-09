using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public ProceduralTerrain terrain;
    public float chaseRange = 20f;
    public float moveSpeed = 3f;
    public float returnSpeed = 2f;
    public float heightOffset = 0.5f;
    public float heightSmoothSpeed = 5f;
    public float avoidRadius = 1f; // 他の敵との距離

    private Vector3 startPosition;
    private Rigidbody rb;

    void Start()
    {
        startPosition = transform.position;

        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = false; // 衝突を有効にする

        CapsuleCollider col = GetComponent<CapsuleCollider>();
        col.height = 2f;
        col.radius = 0.5f;
        col.center = Vector3.up; // 足元から立ち上がるように
    }

    void FixedUpdate()
    {
        if (player == null || terrain == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        // 目標位置
        Vector3 target = (distance < chaseRange) ? player.position : startPosition;

        // 移動
        MoveTowards(target, (distance < chaseRange) ? moveSpeed : returnSpeed);

        // 他の敵との回避
        AvoidOtherEnemies();
    }

    void MoveTowards(Vector3 target, float speed)
    {
        Vector3 direction = (target - transform.position).normalized;
        Vector3 nextPos = rb.position + direction * speed * Time.fixedDeltaTime;

        // 地形の高さを追従
        float terrainHeight = terrain.GetHeightAtPosition(nextPos.x, nextPos.z) + heightOffset;
        float smoothY = Mathf.Lerp(rb.position.y, terrainHeight, Time.fixedDeltaTime * heightSmoothSpeed);
        nextPos.y = smoothY;

        rb.MovePosition(nextPos);

        // 向きもスムーズに補間
        Vector3 flatDir = new Vector3(direction.x, 0, direction.z);
        if (flatDir.sqrMagnitude > 0.001f)
        {
            Quaternion targetRot = Quaternion.LookRotation(flatDir);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRot, Time.fixedDeltaTime * 5f));
        }
    }

    void AvoidOtherEnemies()
    {
        Collider[] hits = Physics.OverlapSphere(rb.position, avoidRadius);
        Vector3 push = Vector3.zero;

        foreach (var h in hits)
        {
            if (h.gameObject != gameObject && h.CompareTag("Enemy"))
            {
                push += rb.position - h.transform.position;
            }
        }

        if (push.sqrMagnitude > 0.001f)
        {
            Vector3 newPos = rb.position + push.normalized * 0.05f; // 微調整
            rb.MovePosition(newPos);
        }
    }
}

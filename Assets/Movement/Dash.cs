using UnityEngine;

public class Dash : MonoBehaviour
{
    
    public int DashCount;
    public float WaitTime = 1f;
    public float DashSpeed= 10f;
    public float DashTime = 1f;
    public float DashDampingRatio = 0.9f;

    public bool isTest = false;
    float _dashStartTime;
    float _waitStartTime;
    Rigidbody2D rb;
    private void Awake() {
        rb =GetComponent<Rigidbody2D>();
        _dashStartTime = 0;
        _waitStartTime = 0;
    }
    public void GoDash(Vector2 dir)
    {
        rb.velocity = DashSpeed * dir;
        _dashStartTime = Time.time;
    }
    
    Vector2 GetInputVec()
    {
            var up = Input.GetKeyDown(KeyCode.W) ? 1f : 0f;
            var down = Input.GetKeyDown(KeyCode.S) ? -1f : 0f;
            var left = Input.GetKeyDown(KeyCode.A) ? -1f : 0f;
            var right = Input.GetKeyDown(KeyCode.D) ? 1f : 0;
            Vector2 inputVec = new Vector2(left+right,up + down);
            return inputVec;
    }

    void FixedUpdate()
    {
        if(DashCount>0 && Time.time > _dashStartTime + DashTime)
        {
            var inputVec = GetInputVec();
            if(inputVec.magnitude >= 1f)
            {
                GoDash(inputVec.normalized);
                DashCount--;
            }
        }

        if(Time.time < _dashStartTime + DashTime)
        {
            rb.velocity *= DashDampingRatio;
        }

        if(isTest)
            Test();

    }
    void Test()
    {
        if(Input.GetKeyDown(KeyCode.Q))
            DashCount++;
    }
}

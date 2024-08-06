using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeNode : MonoBehaviour
{
    
    [SerializeField] Sprite _normalSprite;
    [SerializeField] GameObject _nodePrefab;
    SpriteRenderer _spriteRenderer;

    Rigidbody2D _rigidBody;
    SnakeNode _nextNode = null;
    SnakeNode _prevNode = null;
    Vector2 _curDir;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer.sprite = _normalSprite;
    }
    
    public void Move()
    {
        if(_prevNode != null)
            _prevNode.Move();
        var size = _spriteRenderer.sprite.bounds.size;
    }
    public void SetDir(Vector2 vec)
    {
        _curDir = vec;
    }
    public void Grow()
    {
        if(_prevNode == null)
        {
            var nodeGo = Instantiate(_nodePrefab);
            var size = _spriteRenderer.sprite.bounds.size;
            var pos = new Vector3(transform.position.x - _curDir.x * size.x / 2, transform.position.y - _curDir.y * size.y / 2, 0);
            nodeGo.transform.position = pos;
            _prevNode = nodeGo.GetComponent<SnakeNode>();
            _prevNode.SetDir(_curDir);
        }
        else
        {
            _prevNode.Grow();
        }
    }
}

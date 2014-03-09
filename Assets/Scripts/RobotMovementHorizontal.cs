using UnityEngine;
using System.Collections;

public class RobotMovementHorizontal : MonoBehaviour
{

    private Player _player;
    private bool _detectedPlayer = false;
    private bool _stopForever = false;
    private float _moveToPlayer;

    // We use inspector. For level design
    public int _idleTime = 1; // waiting time before going up val * 100
    public int _speed = 2; // speed if it follows player
	public float _length = 10;
    public bool _followPlayer = true;
    public bool _masterBoss = false;

    // Use this for initialization
    void Start()
    {
        _player = Player.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        _CheckPlayer();
        _CanMove();
    }

    #region custom
    private void _CheckPlayer()
    {
        if (!_stopForever)
        {
			if (transform.position.y > _player.transform.position.y - _length)
            {
                if (!_detectedPlayer)
                {
                    _detectedPlayer = true;
                    _moveToPlayer = (Time.time * 1000) + (_idleTime * 100);
                }

            }
        }
    }

    private void _CanMove()
    {
        if (_detectedPlayer)
        {

            int _followX = -(_speed);
            if (transform.position.x < _player.transform.position.x) _followX = _speed;

            if (!_followPlayer)
            {
                _followX = 0;
            }

			transform.position = new Vector2(transform.position.x + (_followX * Time.deltaTime), _player.transform.position.y - _length);


            if (!_masterBoss)
            {
                // I like to use Time x) sorry
                if (_moveToPlayer < Time.time * 1000)
                {
                    _detectedPlayer = false;
                    _stopForever = true;
                }
            }
        }
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCPlayerController : MonoBehaviour
{
    public GameObject ProgressBar;
    LineRenderer _projectedTrajectory;
    const float MINX = -9f, MAXX = 0f;
   
    Vector3 _deltaPos, _mousePosition;
    float _speedX = 20f, _triggerSpeed = 30f, _triggerAngle, _barValue;
    public GameObject CannonBallPrefab;
    const int _trajectoryVertx = 20;
    private void Awake()
    {
        _projectedTrajectory = GetComponent<LineRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        _deltaPos = new Vector3();
        _projectedTrajectory.positionCount = _trajectoryVertx;
    }

    // Update is called once per frame
    void Update()
    {
        _deltaPos.y = _deltaPos.z = 0;
        _deltaPos.x = Input.GetAxis("Horizontal") * _speedX * Time.deltaTime;
        gameObject.transform.Translate(_deltaPos);
        gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, MINX, MAXX), gameObject.transform.position.y, gameObject.transform.position.z);


        //calculating angle
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _deltaPos.y = _mousePosition.y - gameObject.transform.position.y;
        _deltaPos.x = _mousePosition.x - gameObject.transform.position.x;
        

        if(_deltaPos.x < 0)
            _triggerAngle = Mathf.PI/2;
        else if (_deltaPos.y < 0)
            _triggerAngle = 0;
        else
            _triggerAngle = Mathf.Atan(_deltaPos.y / _deltaPos.x);

        if (Input.GetButton("Fire1"))
        {
            _barValue = Mathf.PingPong(Time.time, 1) * 100f;
            ProgressBar.GetComponent<ProgressBar>().BarValue = _barValue;
            
        }

        else if (Input.GetButtonUp("Fire1"))
        {
            Instantiate(CannonBallPrefab, gameObject.transform.position, Quaternion.identity).GetComponent<CannonBallBehaviour>().Invoked(_triggerSpeed * (_barValue/100), _triggerAngle);
        }
        //Debug.Log(_triggerAngle);

    }

    Vector3 GetPosition(float resolutionProportion, float xMax)
    {
        float xRelative = resolutionProportion * xMax;
        float yRelative = xRelative * Mathf.Tan(_triggerAngle) - (Mathf.Abs(Physics.gravity.y) * Mathf.Pow(xRelative, 2)) / (2 * (_triggerSpeed * (_barValue / 100)) * (_triggerSpeed * (_barValue / 100)) * Mathf.Cos(Mathf.Pow(_triggerAngle, 2)));

        return new Vector3(xRelative, yRelative);
    }
}

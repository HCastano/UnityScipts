using UnityEngine;
using System.Collections;
using System.Resources;
using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;


public class MoveBox : MonoBehaviour
{
	public GameObject myo = null;
    float moveSpeed = 0f;
    float moveAccel = 6.0f;

    // Use this for initialization
    void Start()
    {


    }
	//private Pose _lastPose = Pose.Unknown;


    // Update is called once per frame
    void Update()
    {
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

        //a = v/t
        //v = a * t 

        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (thalmicMyo.pose == Pose.Fist) {
            moveSpeed += moveAccel * Time.deltaTime;
        }


        if (thalmicMyo.pose == Pose.FingersSpread) {
            moveSpeed -= moveAccel * Time.deltaTime;
        }

        double d = (System.Math.Acos(1 / System.Math.Sqrt(2)));

        // Debug.Log("MATH: " + d);

        double x = transform.eulerAngles.x;
        double xx = transform.position.z; 
        double y = transform.eulerAngles.y;
        double z = transform.eulerAngles.z;
        
        Debug.Log("X: " + xx + " Y: " + y + " Z: " + z);
        //onOrientationData(quat); 

        
    }

    void onOrientationData(Quaternion quat)
    {
        double roll = System.Math.Atan2(2.0f * (quat.w * quat.x + quat.y * quat.z), 
            1.0f - 2.0f * (quat.x * quat.x + quat.y * quat.y));

        float pitch = (float)System.Math.Asin(System.Math.Max(-1.0f, 
            System.Math.Min(1.0f, 2.0f * (quat.w * quat.y - quat.z * quat.x))));

        float yaw = (float)System.Math.Atan2(2.0f * (quat.w * quat.z + quat.x * quat.y),
                    1.0f - 2.0f * (quat.y * quat.y + quat.z * quat.z));

        Debug.Log("Roll: " + roll + " Pitch: " + pitch + " Yaw: " + yaw); 
    }


    /*
    // onOrientationData() is called whenever the Myo device provides its current orientation, which is represented
    // as a unit quaternion.
    void onOrientationData(myo::Myo* myo, uint64_t timestamp, const myo::Quaternion<float>& quat)
    {
        using std::atan2;
        using std::asin;
        using std::sqrt;
        using std::max;
        using std::min;
        // Calculate Euler angles (roll, pitch, and yaw) from the unit quaternion.
        float roll = atan2(2.0f * (quat.w() * quat.x() + quat.y() * quat.z()),
                           1.0f - 2.0f * (quat.x() * quat.x() + quat.y() * quat.y()));
    float pitch = asin(max(-1.0f, min(1.0f, 2.0f * (quat.w() * quat.y() - quat.z() * quat.x()))));
    float yaw = atan2(2.0f * (quat.w() * quat.z() + quat.x() * quat.y()),
                    1.0f - 2.0f * (quat.y() * quat.y() + quat.z() * quat.z()));
    // Convert the floating point angles in radians to a scale from 0 to 18.
    roll_w = static_cast<int>((roll + (float)M_PI)/(M_PI* 2.0f) * 18);
        pitch_w = static_cast<int>((pitch + (float)M_PI/2.0f)/M_PI* 18);
        yaw_w = static_cast<int>((yaw + (float)M_PI)/(M_PI* 2.0f) * 18);
    }

    */

    
  
}

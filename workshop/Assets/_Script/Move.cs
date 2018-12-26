using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Move : MonoBehaviour
{

    /// <summary>
    /// 鼠标点击的位置
    /// </summary>
    public GameObject mousePos;
    /// <summary>
    /// 动画
    /// </summary>
    public Animator walkanimation;
    /// <summary>
    /// 摄像机位置
    /// </summary>
    public GameObject camera;
    /// <summary>
    /// 摄像机与人物之间的偏移量
    /// </summary>
    public Vector3 offset;
    public Transform Cube;
    /// <summary>
    /// 
    /// </summary>
    static Move instance;
    public Vector3 targetPos;
    public static Move Instance
    {
        get
        {
            return instance;
        }
    }

    private void Start()
    {
        offset = camera.gameObject.transform.position - Cube.position;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //从鼠标当前位置发射一条射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //声明保存射线检测结果的变量
            RaycastHit hit;
            //进行射线检测
            if (Physics.Raycast(ray, out hit))
            {
                //开启动画
                walkanimation.SetBool("isWalk", true);
                //获取射线与地面的碰撞点
                targetPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                //向目标位置进行移动
                transform.DOMove(targetPos, 10f).OnComplete(OnClickWalk);
                transform.forward = (Cube.position - transform.position).normalized;
            }
            Cube.transform.LookAt(targetPos);




        }

        camera.gameObject.transform.position = Cube.position + offset;
    }
    public void OnClickWalk()
    {
        walkanimation.SetBool("isWalk", false);
    }
    /*void RayControl()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//向屏幕发射一条射线
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 200)) //射线长度为200 和地面的碰撞盒做检测
        {
            GameObject targetPos = GameObject.CreatePrimitive(PrimitiveType.Sphere);//实例化一个Sphere
            targetPos.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            tar = hit.point;//获取碰撞点坐标
            mousePos.y = transform.position.y;
            targetPos.transform.position = mousePos;//Sphere放到鼠标点击的地方
            targetDir = mousePos - transform.position;//计算出朝向
            Vector3 tempDir = Vector3.Cross(transform.forward, targetDir.normalized);//用叉乘判断两个向量是否同方向
            float dotValue = Vector3.Dot(transform.forward, targetDir.normalized);//点乘计算两个向量的夹角，及角色和目标点的夹角
            float angle = Mathf.Acos(dotValue) * Mathf.Rad2Deg;
            if (tempDir.y < 0)//这块 说明两个向量方向相反，这个判断用来确定假如两个之间夹角30度 到底是顺时 还是逆时针旋转。
            {
                angle = angle * (-1);
            }
            print(tempDir.y);
            print("2:" + angle);
            transform.RotateAround(transform.position, Vector3.up, angle);
            flagMove = true;
        }
    }*/
}

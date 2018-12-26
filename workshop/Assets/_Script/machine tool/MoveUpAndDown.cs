using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MoveUpAndDown : MonoBehaviour
{

    /// <summary>
    /// 移动按钮
    /// </summary>
    public Button upDownBtn;
    /// <summary>
    /// 移动到的位置
    /// </summary>
    public Transform translations;

    public Transform cube;
    void Update()
    {
        upDownBtn.onClick.AddListener(OnClickUpDown);
    }
    public void OnClickUpDown()
    {
        cube.transform.DOMove(translations.position, 2f);
        
        
    }
}

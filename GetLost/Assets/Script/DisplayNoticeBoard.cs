using UnityEngine;
using System.Collections;

public class DisplayNoticeBoard : MonoBehaviour
{
    private GameObject NoticeBoard;

    // Use this for initialization
    void Start()
    {
        NoticeBoard = GameObject.Find("NoticeBoard");
        NoticeBoard.SetActive(false);
    }

    public void ShowNoticeBoard()
    {
        NoticeBoard.SetActive(true);
    }

    public void CloseNoticeBoard()
    {
        NoticeBoard.SetActive(false);
    }
}

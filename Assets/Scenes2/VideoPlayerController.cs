using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private Dictionary<KeyCode, string> keyToVideoPath = new Dictionary<KeyCode, string>();

    private void Start()
    {
        // Mapeie as teclas do alfabeto para os caminhos absolutos dos videos.
        keyToVideoPath[KeyCode.A] = "file://E:/Projetos Unity/Projeto_RV_Libras/Cenas/Video/a.mp4";
        keyToVideoPath[KeyCode.B] = "file://E:/Projetos Unity/Projeto_RV_Libras/Cenas/Video/b.mp4";
        keyToVideoPath[KeyCode.C] = "file://E:/Projetos Unity/Projeto_RV_Libras/Cenas/Video/c.mp4";
        keyToVideoPath[KeyCode.D] = "file://E:/Projetos Unity/Projeto_RV_Libras/Cenas/Video/d.mp4";
        keyToVideoPath[KeyCode.E] = "file://E:/Projetos Unity/Projeto_RV_Libras/Cenas/Video/e.mp4";
        keyToVideoPath[KeyCode.F] = "file://E:/Projetos Unity/Projeto_RV_Libras/Cenas/Video/f.mp4";
        keyToVideoPath[KeyCode.G] = "file://E:/Projetos Unity/Projeto_RV_Libras/Cenas/Video/g.mp4";
        keyToVideoPath[KeyCode.H] = "file://E:/Projetos Unity/Projeto_RV_Libras/Cenas/Video/h.mp4";
        keyToVideoPath[KeyCode.I] = "file://E:/Projetos Unity/Projeto_RV_Libras/Cenas/Video/i.mp4";
        keyToVideoPath[KeyCode.J] = "file://E:/Projetos Unity/Projeto_RV_Libras/Cenas/Video/j.mp4";
        keyToVideoPath[KeyCode.K] = "file://E:/Projetos Unity/Projeto_RV_Libras/Cenas/Video/k.mp4";
        keyToVideoPath[KeyCode.L] = "file://E:/Projetos Unity/Projeto_RV_Libras/Cenas/Video/l.mp4";
        keyToVideoPath[KeyCode.M] = "file://E:/Projetos Unity/Projeto_RV_Libras/Cenas/Video/m.mp4";
        keyToVideoPath[KeyCode.N] = "file://E:/Projetos Unity/Projeto_RV_Libras/Cenas/Video/n.mp4";
        keyToVideoPath[KeyCode.O] = "file://E:/Projetos Unity/Projeto_RV_Libras/Cenas/Video/o.mp4";
        keyToVideoPath[KeyCode.P] = "file://E:/Projetos Unity/Projeto_RV_Libras/Cenas/Video/p.mp4";
        keyToVideoPath[KeyCode.Q] = "file://E:/Projetos Unity/Projeto_RV_Libras/Cenas/Video/q.mp4";
        keyToVideoPath[KeyCode.R] = "file://E:/Projetos Unity/Projeto_RV_Libras/Cenas/Video/r.mp4";
        keyToVideoPath[KeyCode.S] = "file://E:/Projetos Unity/Projeto_RV_Libras/Cenas/Video/s.mp4";
        keyToVideoPath[KeyCode.T] = "file://E:/Projetos Unity/Projeto_RV_Libras/Cenas/Video/t.mp4";
        keyToVideoPath[KeyCode.U] = "file://E:/Projetos Unity/Projeto_RV_Libras/Cenas/Video/u.mp4";
        keyToVideoPath[KeyCode.V] = "file://E:/Projetos Unity/Projeto_RV_Libras/Cenas/Video/v.mp4";
        keyToVideoPath[KeyCode.W] = "file://E:/Projetos Unity/Projeto_RV_Libras/Cenas/Video/w.mp4";
        keyToVideoPath[KeyCode.X] = "file://E:/Projetos Unity/Projeto_RV_Libras/Cenas/Video/x.mp4";
        keyToVideoPath[KeyCode.Y] = "file://E:/Projetos Unity/Projeto_RV_Libras/Cenas/Video/y.mp4";
        keyToVideoPath[KeyCode.Z] = "file://E:/Projetos Unity/Projeto_RV_Libras/Cenas/Video/z.mp4";

        videoPlayer = GetComponent<VideoPlayer>();
    }

    private void Update()
    {
        if (videoPlayer == null)
        {
            Debug.LogError("O VideoPlayer não está atribuído. Atribua-o no Unity Inspector.");
            return;
        }

        foreach (var key in keyToVideoPath.Keys)
        {
            if (Input.GetKeyDown(key))
            {
                PlayVideoForKey(key);
                break;
            }
        }
    }

    private void PlayVideoForKey(KeyCode key)
    {
        if (keyToVideoPath.ContainsKey(key))
        {
            videoPlayer.Stop();
            videoPlayer.url = keyToVideoPath[key];
            videoPlayer.Play();
        }
    }
}

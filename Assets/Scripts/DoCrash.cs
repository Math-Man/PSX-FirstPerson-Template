using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;


public class DoCrash : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private void Start()
    {
        Debug.Log("I am from skeleton");
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 2f)
        {
            Crash();
        }
    }

    private void Crash()
    {
        NativeWinAlert.Error("lmao dead", "skeleton'd");
        Application.OpenURL("www.dumpypoop.com");
        Application.Quit();
    }
    
    /// <see>https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-messagebox</see>
    public static class NativeWinAlert
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern System.IntPtr GetActiveWindow();

        public static System.IntPtr GetWindowHandle()
        {
            return GetActiveWindow();
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern int MessageBox(IntPtr hwnd, String lpText, String lpCaption, uint uType);

        /// <summary>
        /// Shows Error alert box with OK button.
        /// </summary>
        /// <param name="text">Main alert text / content.</param>
        /// <param name="caption">Message box title.</param>
        public static void Error(string text, string caption)
        {
            try
            {
                MessageBox(GetWindowHandle(), text, caption, (uint)(0x00000000L | 0x00000010L));
            }
            catch (Exception ex) { }
        }
    }
}




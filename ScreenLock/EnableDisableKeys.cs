﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenLock
{
    internal class EnableDisableKeys
    {
        // Structure contain information about low-level keyboard input event
        [StructLayout(LayoutKind.Sequential)]
        private struct KBDLLHOOKSTRUCT
        {
            public Keys key;
            public int scanCode;
            public int flags;
            public int time;
            public IntPtr extra;
        }

        //System level functions to be used for hook and unhook keyboard input
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int id, LowLevelKeyboardProc callback, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hook);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hook, int nCode, IntPtr wp, IntPtr lp);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string name);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern short GetAsyncKeyState(Keys key);


        //Declaring Global objects
        private IntPtr ptrHook;
        private LowLevelKeyboardProc objKeyboardProcess;

        public void KeyHook()
        {
            ProcessModule objCurrentModule = Process.GetCurrentProcess().MainModule;
            objKeyboardProcess = new LowLevelKeyboardProc(captureKey);
            ptrHook = SetWindowsHookEx(13, objKeyboardProcess, GetModuleHandle(objCurrentModule.ModuleName), 0);
        }

        private IntPtr captureKey(int nCode, IntPtr wp, IntPtr lp)
        {
            if (nCode >= 0)
            {
                KBDLLHOOKSTRUCT objKeyInfo = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lp, typeof(KBDLLHOOKSTRUCT));

                if (objKeyInfo.key == Keys.RWin || objKeyInfo.key == Keys.LWin) // Disabling Windows keys
                {
                    return (IntPtr)1;
                }
                if (objKeyInfo.key == Keys.Alt || objKeyInfo.key == Keys.Tab) // Disabling Windows keys
                {
                    return (IntPtr)1;
                }
                if (objKeyInfo.key == Keys.LControlKey || objKeyInfo.key == Keys.Alt || objKeyInfo.key == Keys.Delete) // Disabling Windows keys
                {
                    return (IntPtr)1;
                }
                if (objKeyInfo.key == Keys.RControlKey || objKeyInfo.key == Keys.Alt || objKeyInfo.key == Keys.Delete) // Disabling Windows keys
                {
                    return (IntPtr)1;
                }
                if (objKeyInfo.key == Keys.Control || objKeyInfo.key == Keys.Alt || objKeyInfo.key == Keys.Delete) // Disabling Windows keys
                {
                    return (IntPtr)1;
                }
                if (objKeyInfo.key == Keys.Alt || objKeyInfo.key == Keys.F4) // Disabling Windows keys
                {
                    return (IntPtr)1;
                }
                if (objKeyInfo.key == Keys.LWin || objKeyInfo.key == Keys.R) // Disabling Windows keys
                {
                    return (IntPtr)1;
                }
                if (objKeyInfo.key == Keys.RWin || objKeyInfo.key == Keys.R) // Disabling Windows keys
                {
                    return (IntPtr)1;
                }
                if (objKeyInfo.key == Keys.RWin ) // Disabling Windows keys
                {
                    return (IntPtr)1;
                }
                if (objKeyInfo.key == Keys.LWin) // Disabling Windows keys
                {
                    return (IntPtr)1;
                }
                if (objKeyInfo.key == Keys.Alt || objKeyInfo.key == Keys.R) // Disabling Windows keys
                {
                    return (IntPtr)1;
                }
                if (objKeyInfo.key == Keys.Alt || objKeyInfo.key == Keys.F2) // Disabling Windows keys
                {
                    return (IntPtr)1;
                }
                if (objKeyInfo.key == Keys.Alt || objKeyInfo.key == Keys.Z) // Disabling Windows keys
                {
                    return (IntPtr)1;
                }
                

            }
            return CallNextHookEx(ptrHook, nCode, wp, lp);
        }
    }
}

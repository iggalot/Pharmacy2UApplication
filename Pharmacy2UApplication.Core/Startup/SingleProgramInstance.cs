using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;

namespace Pharmacy2UApplication.Core
{
    /// <summary>
    /// A class for ensuring that only one copy of a process is running
    /// at a particular time.  IT also allows for UI identification of the initial process by
    /// brining that window to the foreground. From CodeProject.Com "Single Process Instance Object"
    /// </summary>
    public class SingleProgramInstance : IDisposable
    {
        // Win32 API calls necessary to raise an unowned process main window
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);

        private const int SW_RESTORE = 9;

        // private members
        private Mutex _processSync;
        private bool _owned = false;

        #region Constructors and Destructors

        /// <summary>
        /// Parameterless default constructor
        /// </summary>
        public SingleProgramInstance()
        {
            // Initialize a named mutex and attempt to get ownership immediately
            _processSync = new Mutex(
                true,   // desire initial ownership
                Assembly.GetExecutingAssembly().GetName().Name,
                out _owned);
        }

        /// <summary>
        /// Constructor that takes a string identifier
        /// </summary>
        public SingleProgramInstance(string identifier)
        {
            // Initialize a named mutex and attempt to get ownership immediately
            // Use an additional identifier to lower our chances
            // of another process creating a mutex with the same name
            _processSync = new Mutex(
                true,   // desire initial ownership
                Assembly.GetExecutingAssembly().GetName().Name + identifier,
                out _owned);
        }

        ~SingleProgramInstance()
        {
            // Release the mutex (if necessary)
            // Theoretically this should be accomplised by Dispose() function, but just in case...
            Release();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// If we dont own the mutex, then we are not the first instance
        /// </summary>
        public bool IsSingleInstance { get => _owned; }

        #endregion


        #region Public Methods

        public void  RaiseOtherProcess()
        {
            Process proc = Process.GetCurrentProcess();

            // Normal we could use Process.ProcessName, but this doesnt always function properly when the
            // actual name exceeds 15 characters.  We will use the assembly name instead -- though this has issues since 
            // the class is located in Pharmacy2UApplication.Core and not  Pharmacy2UApplication.
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            int processCount = 0;
            foreach (Process otherProc in Process.GetProcessesByName(assemblyName))
//            foreach (Process otherProc in Process.GetProcesses())
            {
                // Look for matching process names.
                if (otherProc.ProcessName == proc.ProcessName)
                {
                    processCount++;

                    // Ignore "this" process, and look for another "same named process".
                    // Use the Win32 API to bring it to the foreground.
                    if (proc.Id != otherProc.Id)
                    {
                        IntPtr hWnd = otherProc.MainWindowHandle;
                        if (IsIconic(hWnd))
                        {
                            ShowWindowAsync(hWnd, SW_RESTORE);
                        }
                        SetForegroundWindow(hWnd);
                        break;
                    }
                }
            }
            MessageBox.Show(processCount.ToString() + " processes active");
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Releases the mutex if it is owned by the current thread.
        /// </summary>
        private void Release()
        {
            // If we own the mutex then release it so that other "same name processes" can now start
            if(_owned)
            {
                _processSync.ReleaseMutex();
                _owned = false;
            }
        }

        #endregion

        #region IDisposable Interface Implementation

        /// <summary>
        /// Release mutex (if necessary) and notify the garbage collector to ignore the destructor
        /// </summary>
        public void Dispose()
        {
            Release();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}

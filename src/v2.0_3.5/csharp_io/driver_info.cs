/*
 *    Filename: <drive_info.cs>
 *
 * Description: Exposing the DriveInfo class
 *
 *      Author: Adorno <adorno@protonmail.com>
 *
 *     Version: v1.0
 *
 *     Changes: None
 *
 */

using System;
using System.Collections;
using System.IO;

namespace CSharp.IO
{
    public partial class IO 
    {
        public DriveInfo[] GetDrivers()
        {
            return DriveInfo.GetDrives();
        }

        public void DisplayDrivers()
        {
            DriveInfo[] drivers = this.GetDrivers();
            IEnumerator reader = drivers.GetEnumerator();

            while (reader.MoveNext())
            {
                var info = (DriveInfo) reader.Current;
                
                Console.WriteLine(LOGICAL_DRIVE_INFO,
                                  info.Name,
                                  info.DriveType,
                                  info.TotalFreeSpace,
                                  info.DriveFormat,
                                  info.VolumeLabel);
            }                              
        }
    }
}
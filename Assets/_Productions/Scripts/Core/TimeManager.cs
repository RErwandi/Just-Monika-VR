using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace JustMonika.VR
{
    public class TimeManager : MonoBehaviour
    {
        [ShowInInspector]
        private int day;
        public int Day => day;
        
        [ShowInInspector]
        private int month;
        public int Month => month;
        
        [ShowInInspector]
        private int year;
        public int Year => year;

        private void Start()
        {
            var date = DateTime.Now;
            day = date.Day;
            month = date.Month;
            year = date.Year;
        }
    }
}
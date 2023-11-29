using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JourneyJoy.Models
{
    public enum ResponseCode
    {
        SUCCESS = 0,
        PENDING = 777,
        FAILED = 100,
        ERROR = 1,
        WARINIG = 2,
        EXCEPTION = 999
    }
    public class CommonModel
    {
        public string ID { get; set; }
        public ResponseCode Code { get; set; }
        public string Message { get; set; }
        public string ExtraField1 { get; set; }
        public string ExtraField2 { get; set; }
        public string ExtraField3 { get; set; }
        public object Data { get; set; }
    }
}
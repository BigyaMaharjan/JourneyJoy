using System;
using System.Collections.Generic;
using System.Data;
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
    public class BaseModel
    {
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set;}
    }
    public class CommonModel
    {
        public string ID { get; set; }
        public ResponseCode Code { get; set; }
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public string ExtraField1 { get; set; }
        public string ExtraField2 { get; set; }
        public string ExtraField3 { get; set; }
        public object Data { get; set; }
        public void SetMessage(int Code, string Message, string Extra1 = "", String Extra2 = "", string Extra3 = "",  DataTable dt = null, DataRow row = null)
        {
            switch (Code)
            {
                case 1:
                    this.Code = ResponseCode.FAILED;
                    break;
                case 2:
                    this.Code = ResponseCode.WARINIG;
                    break;
                case 0:
                    this.Code = ResponseCode.SUCCESS;
                    break;
                default:
                    this.Code = ResponseCode.EXCEPTION;
                    break;
            }

            this.ErrorCode = Code;
            this.Message = Message;
            this.ExtraField1 = Extra1 ?? "";
            this.ExtraField2 = Extra2 ?? "";
            this.ExtraField3 = Extra3 ?? "";
            if (dt != null)
                this.Data = dt;
            else
                this.Data = row;
        }
        public void SetMessages(string Code, string Message, string Extra1 = "", String Extra2 = "", string Extra3 = "", DataTable dt = null, DataRow row = null)
        {
            int _code = 0;
            if (int.TryParse(Code.Trim(), out _code))
            {
                SetMessage(_code, Message, Extra1, Extra2, Extra3);
            }
            else
                SetMessage(9, "Invalid Response Code", Extra1, Extra2, Extra3);
            if (dt != null)
                this.Data = dt;
            else
                this.Data = row;
        }
    }
}
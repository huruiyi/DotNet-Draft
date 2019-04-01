﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Token.Models
{
    public class HttpResponseMsg
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// 操作信息
        /// </summary>
        public string Info { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public object Data { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDingActive.Model.Params.DifferentPlaces
{
  public  class UserInfoDifferentParam
    {/// <summary>
        /// 身份标识
        /// </summary>
        public string PI_SFBZ { get; set; }
        /// <summary>
        /// 身份标志1为公民身份号码 2为个人编号
        /// </summary>
        public string PI_CRBZ { get; set; }
    }
}

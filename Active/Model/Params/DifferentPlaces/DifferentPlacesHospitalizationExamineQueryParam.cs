﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenDingActive.Model.Params.DifferentPlaces
{
   public class DifferentPlacesHospitalizationExamineQueryParam
    {
        //    <baa008>参保地统筹区编号</baa008>
        //<aaz217>就诊登记号</aaz217>
        /// <summary>
        /// 参保地统筹区编号
        /// </summary>
        public string baa008 { get; set; }
        /// <summary>
        /// 就诊登记号
        /// </summary>
        public string aaz217 { get; set; }
    }
}

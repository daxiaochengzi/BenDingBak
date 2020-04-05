﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BenDing.Domain.Models.Dto.Web;
using BenDing.Domain.Models.Params.Base;

namespace BenDing.Domain.Models.Params.UI
{
   public class WorkerBirthHospitalizationRegisterUiParam: UiBaseDataParam
    {///<summary>
     /// 身份标识 （身份证号或者个人编号）
     /// </summary>

        [Display(Name = "身份标识")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string IdentityMark { get; set; }
        /// <summary>
        ///传入标志  (1为公民身份号码 2为个人编号)
        /// </summary>
        [Display(Name = "传入标志")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string AfferentSign { get; set; }
        /// <summary>
        /// 医疗类别71：顺产72：剖宫产
        /// </summary>
        [Display(Name = " 医疗类别")]
        [Required(ErrorMessage = "{0}不能为空!!!")]
        public string MedicalCategory { get; set; }
        /// <summary>
        /// 胎儿数
        /// </summary>
       
        public int FetusNumber { get; set; }
       
        /// <summary>
        /// 配偶身份证号码
        /// </summary>
        
        public string SpouseIdCardNo { get; set; }
        /// <summary>
        /// 配偶姓名
        /// </summary>
      
        public string SpouseName { get; set; }
        /// <summary>
        /// 诊断
        /// </summary>

        public List<InpatientDiagnosisDto> DiagnosisList { get; set; } = null;
    }
}

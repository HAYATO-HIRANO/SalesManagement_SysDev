﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev
{
    public class TOrder
    {
        public int OrID { get; set; }           //受注ID		
        public int SoID { get; set; }           //営業所ID		
        public int EmID { get; set; }           //社員ID		
        public int ClID { get; set; }           //顧客ID
        public String ClCharge { get; set; }    //顧客担当者名
        public DateTime OrDate { get; set; }    //受注年月日
        public int? OrStateFlag { get; set; }    //受注状態フラグ
        public int OrFlag { get; set; } //受注管理フラグ
        public String OrHidden { get; set; }    //非表示理由

    }
}
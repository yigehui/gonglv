﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 公式类
/// </summary>
namespace WindowsFormsApplication1
{
    public enum cell {
        gailv = 1,
        kaili = 2,
        peilv = 3,
        peifulv = 4,
        peilvchazhi = 5,
        xiangduipeilv = 6,
        gailvchazhi1 = 7,
        gailvchazhi2 = 8
    }
    public class Gongshi
    {
        public string id { get; set; }

        public string groupid { get; set; }

        public double gailv { get; set; } //概率

        public double kaili { get; set; }//凯利

        public double peilv { get; set; }//赔率

        public double peifulv { get; set; }//赔付率

        public double peilvchazhi { get; set; } //赔率差值

        public double xiangduipeilv { get; set; }//相对赔付率

        public double gailvchazhi1 { get; set; }//概率差值1

        public double gailvchazhi2 { get; set; }//概率差值2

        public string color { get; set; }

        public string result { get; set; }//结果 2018-05-28
        public Gongshi() {
        }

        public Gongshi(double gailv, double kaili, double peilv, double peifulv)
        {
            this.gailv = gailv;
            this.kaili = kaili;
            this.peilv = peilv;
            this.peifulv = peifulv;
            this.peilvchazhi = getPeilvchazhi();
            this.xiangduipeilv = getXiangduipeilv();
            this.gailvchazhi1 = getGailvchazhi1();
            this.gailvchazhi2 = getGailvchazhi2();
            this.color = "0";
        }

        public double getPeilvchazhi()
        {
            double f = (kaili - peifulv) / gailv * 100;
                
            return Math.Round(f, 2);
        }
        public double getXiangduipeilv()
        {
            double f = peilv / kaili * gailv / 100;
            return Math.Round(f, 2);
        }
        public double getGailvchazhi1()
        {
            double f = 100 / peilv * (kaili - peifulv);
            return Math.Round(f, 2);
        }
        public double getGailvchazhi2()
        {
            double f = gailv - 100 / peilv * peifulv;
            return Math.Round(f, 2);
        }


      

    }
}

using System;
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
        Gailv = 1,
        Kaili = 2,
        Peilv = 3,
        Peifulv = 4,
        Peilvchazhi = 5,
        Xiangduipeilv = 6,
        Gailvchazhi1 = 7,
        Gailvchazhi2 = 8
    }
    public class Gonshi
    {
        private double gailv; //概率

        private double kaili;//凯利

        private double peilv;//赔率

        private double peifulv;//赔付率

        private double peilvchazhi; //赔率差值

        private double xiangduipeilv;//相对赔付率

        private double gailvchazhi1;//概率差值1

        private double gailvchazhi2;//概率差值2

        public Gonshi(double gailv, double kaili, double peilv, double peifulv)
        {
            this.gailv = gailv;
            this.kaili = kaili;
            this.peilv = peilv;
            this.peifulv = peifulv;
            this.peilvchazhi = getPeilvchazhi();
            this.xiangduipeilv = getXiangduipeilv();
            this.gailvchazhi1 = getGailvchazhi1();
            this.gailvchazhi2 = getGailvchazhi2();
        }

        public double getPeilvchazhi()
        {
            return (kaili - peifulv)/gailv*100;
        }
        public double getXiangduipeilv()
        {
            return peilv/kaili*gailv/100;
        }
        public double getGailvchazhi1()
        {
            return 100/ peilv*(kaili- peifulv);
        }
        public double getGailvchazhi2()
        {
            return gailv-100/ peilv* peifulv;
        }


        public double Gailv
        {
            get
            {
                return gailv;
            }

            set
            {
                gailv = value;
            }
        }

        public double Kaili
        {
            get
            {
                return kaili;
            }

            set
            {
                kaili = value;
            }
        }

        public double Peilv
        {
            get
            {
                return peilv;
            }

            set
            {
                peilv = value;
            }
        }

        public double Peifulv
        {
            get
            {
                return peifulv;
            }

            set
            {
                peifulv = value;
            }
        }

        public double Peilvchazhi
        {
            get
            {
                return peilvchazhi;
            }

            set
            {
                peilvchazhi = value;
            }
        }

        public double Xiangduipeilv
        {
            get
            {
                return xiangduipeilv;
            }

            set
            {
                xiangduipeilv = value;
            }
        }

        public double Gailvchazhi1
        {
            get
            {
                return gailvchazhi1;
            }

            set
            {
                gailvchazhi1 = value;
            }
        }

        public double Gailvchazhi2
        {
            get
            {
                return gailvchazhi2;
            }

            set
            {
                gailvchazhi2 = value;
            }
        }





    }
}

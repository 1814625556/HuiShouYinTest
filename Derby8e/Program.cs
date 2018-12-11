using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Derby8e
{
    class Program
    {
        static void Main(string[] args)
        {

            demo();

            Console.ReadKey();
        }

        static void demo()
        {
            DataTable dt = new DataTable("Data");
            var list = zaihui.dbs.derby.derbynet.GetData("SELECT ID,USERID,MEMBERID,PACKAGEID FROM ORDER_DETAIL", "F:\\derby\\db-derby-10.14.2.0-bin-success\\bin\\db");
            var count = list.size();
            for (var i = 0; i < count; i++)
            {
                var strList = list.get(i).ToString().Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);
                if (i == 0)
                {
                    foreach (var str in strList)
                    {
                        dt.Columns.Add(str, Type.GetType("System.String"));
                    }
                }
                else
                {         
                    dt.Rows.Add(strList); 
                }
            }
            Console.WriteLine($"rows:{dt.Rows.Count}");
            Console.WriteLine("转化完毕~~~~");
        }

        static void strSplitTest()
        {
            string str = "ID,USERID,MEMBERID,PACKAGEID,PRODUCTID,CATEGORYID,PRODUCTMAKEID,ORDERID,PARENTID,POINT,ISBOOKING,PRODUCTTYPE,COUNT,ISCOOKED,ISCOOKING,COOKINGTIME,COOKINGFIRE,DELIVERCOUNT,CANCELCOUNT,REMINDCOUNT,PRINTCOUNT,ISSELFGIFT,ISORDERDISCOUNT,ISSELFDISCOUNT,ISSUPERPOSEDDISCOUNT,APPLYCANCELCOUNT,ISPACKAGE,ORDERMETHOD,SALETYPE,STATUS,COUPONTYPE,DISCOUNTTYPE,RECOMMENDTYPE,STAR,MAKETYPE,PACKAGETYPE,MODULEKEY,PRICETYPEKEY,PRODUCTNAME,PRODUCTCODE,UNIT,WEIGHTUNIT,ISPICKPRODUCT,ISHANDCHANGED,REMARK,CANCELREASONID,CANCELREASONTEXT,PROPERTYTEXT,METHODTEXT,COST,BASEPRICE,TIMEPRICE,PACKAGEPRICE,BASECOUPON,BASEDISCOUNT,METHODPRICE,PROPERTYPRICE,WEIGHT,TRUEPRICE,TRUEAMOUNT,ORDERDISCOUNTAMOUNT,REMINDLASTTIME,DEFAULTPRICE,GIFTREASONID,GIFTREASONTEXT,COOKINGTIMESECOND,RETURNTIME,REFUNDCOUNT,UPDATETIME,CREATETIME,ISUPLOAD,ISDELETE,";
            //var str = list.get(0).ToString();
            var arr = str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        }


    }
}

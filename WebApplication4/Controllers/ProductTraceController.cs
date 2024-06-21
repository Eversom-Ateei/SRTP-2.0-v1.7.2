using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Context;
using WebApplication4.DAO;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class ProductTraceController : Controller
    {
        private TemplateContext _context;
        private static User user;

        public ProductTraceController(TemplateContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductTrace(string serialNumber , int rout,int docEntry)
        {          
            if (HttpContext.Session.GetString("user") == null)
            {
                ViewBag.userSession = "false";
            }
            else
            {
                var userInfo2 = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));
                user = userInfo2;
                ViewBag.userSession = userInfo2.EmpID.ToString();
                ViewBag.userName = userInfo2.FirstName.ToString();

                SQLConnection conn = new SQLConnection(_context);


                conn.SqlNonQuery(" if (select COUNT(*) from ATEEI_SRTP_PRODUCT_TRACE_WO where SerialNumber = '" + serialNumber + "')< 1 begin " +
                                                 " insert ATEEI_SRTP_PRODUCT_TRACE_WO (ItemCode,PosId,DocEntry,SerialNumber,Quantity,AssemblyRout) " +
                                                 " select T1.ItemCode,U_Pos_id,t1.DocEntry,'" + serialNumber + "',T1.BaseQty,U_AssemblyRout from OWOR T0 " +
                                                 " INNER JOIN WOR1 T1 ON T0.DocEntry = T1.DocEntry " +
                                                 " WHERE T0.DocEntry = " + docEntry + " " +
                                                 " AND(U_alternativo_linha = U_Pos_id OR(U_alternativo_linha IS NULL AND U_Pos_id IS NOT NULL)) AND ItemType = 4 " +
                                                 " end ");


                List<ItemMasterData> items = new List<ItemMasterData>();
                ItemMasterData item = new ItemMasterData();

                var result = conn.Connect("SELECT t1.* FROM ATEEI_SRTP_PRODUCT_TRACE_WO t0 left join WOR1 t1 on t0.DocEntry = t1.DocEntry and t0.PosId = t1.U_alternativo_linha and t1.ItemType = 4 where SerialNumber='"+serialNumber+"' and t1.ItemCode is not null order by PosId asc");
              
                while (result.Read())
                {

                    items.Add(new ItemMasterData { ItemCode = result["ItemCode"].ToString(), PosId = result["U_alternativo_linha"].ToString() });

                }
                result.Close();

                ViewBag.query = "SELECT t1.* FROM ATEEI_SRTP_PRODUCT_TRACE_WO t0 left join WOR1 t1 on t0.DocEntry = t1.DocEntry and t0.PosId = t1.U_alternativo_linha and t1.ItemType = 4 where SerialNumber = '" + serialNumber + "' and t1.ItemCode is not null order by PosId asc";
                ViewBag.optionItems = items;
                ViewBag.serial = serialNumber;
                ViewBag.docEntry = docEntry;
                //old code using only in separate sector   ViewBag.data = conn.Connect("SELECT * FROM ATEEI_SRTP_PRODUCT_TRACE_WO T0 LEFT JOIN OITM T1 ON T0.ItemCode = T1.ItemCode  where SerialNumber='"+serialNumber+"' and AssemblyRout = "+rout+"");
                               
                ViewBag.data = conn.Connect("SELECT * FROM ATEEI_SRTP_PRODUCT_TRACE_WO T0 LEFT JOIN OITM T1 ON T0.ItemCode = T1.ItemCode  where SerialNumber='"+serialNumber+"' ");
                             
            }
            return View();
        }

        public ActionResult ProductTraceSerialBatch(int ProductTraceId, int docEntry,string itemCode,int posId,decimal baseQty)
        {                                                 

            if (HttpContext.Session.GetString("user") == null)
            {
                ViewBag.userSession = "false";
            }
            else
            {
                var userInfo2 = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));

                user = userInfo2;

                ViewBag.posId = posId;
                ViewBag.userSession = userInfo2.EmpID.ToString();
                ViewBag.userName = userInfo2.FirstName.ToString();
                SQLConnection conn = new SQLConnection(_context);

                var oitm = conn.Connect("SELECT ItemName FROM OITM WHERE ItemCode='" + itemCode + "'");
                while (oitm.Read())
                {
                    ViewBag.itemName = oitm["ItemName"].ToString();
                }
                oitm.Close();
                
                List<SerialBatchNum> optionsbatch = new List<SerialBatchNum>();
                    
                   var res = conn.Connect((@"SELECT t4.ItemCode as ItemCode, 
                                                    t4.ItemName,
                                                    (case when t6.UomCode IS null then 'Manual' else t6.UomCode end) as UomCode,
                                                    t4.InvntryUom,
                                                    (CASE WHEN t3.DistNumber IS null THEN(CASE WHEN t7.batchnum is null THEN 0 ELSE t7.Quantity  END) ELSE t3.Quantity END) as Quantity,
                                         (CASE WHEN t3.DistNumber IS null THEN(CASE WHEN t7.batchnum is null THEN '' ELSE t7.batchnum  END) ELSE t3.distnumber END) AS BatchNum                                        
                                         from dbo.B1_SnBAllocateDocView t0 
                                         left join OWOR t1 on t0.SnBAllocateViewDocEntry = t1.DocEntry and t0.SnBAllocateViewDocType = 202                                    
                                         left join OITM t4 on t0.SnBAllocateViewItemCode = t4.ItemCode 
                                         left join OSRn t3 on t0.SnBAllocateViewSnbSysNum = t3.SysNumber and t3.ItemCode = t4.ItemCode 
                                         left join WOR1 t6 on t1.DocEntry = t6.DocEntry and t6.LineNum = t0.SnBAllocateViewDocLine 
                                         left join OIBT t7 on t0.SnBAllocateViewSnbSysNum = t7.SysNumber and t7.ItemCode = t4.ItemCode and t7.WhsCode = t0.SnBAllocateViewLocCode 
                                         where SnBAllocateViewDocEntry = " + docEntry+ " and SnBAllocateViewDocType = 202 and t0.SnBAllocateViewAllocQty > 0 and t6.U_Pos_id  = "+posId+" and t4.ItemCode ='"+ itemCode+"' "));
                                                      
                while (res.Read())
                {
                    optionsbatch.Add(new SerialBatchNum{ BatchNum = res["BatchNum"].ToString(), Quantity = decimal.Parse(res["Quantity"].ToString()), UomCode = res["UomCode"].ToString(), UomName = res["InvntryUom"].ToString() });
                }
                res.Close();     
                
                 res = conn.Connect(@" select t1.ItemCode,
                                      (case when t4.UomCode IS null then 'Manual' else t4.UomCode end) as UomCode ,                 
                                      t1.Dscription,                                   
                                      t0.DocEntry, " +
                                      //(select t2.BatchNum from ibt1 t2 where t1.DocEntry = t2.BaseEntry and t1.LineNum = t2.BaseLinNum and Direction = 1 AND T2.ItemCode = T1.ItemCode) as 'BatchNum'," +
                                      @" t2.BatchNum ,
                                      t1.Quantity ,
                                      t3.InvntryUom
                                      from OWTR t0 
                                      inner join WTR1 t1 on t0.DocEntry = t1.DocEntry 
                                      inner join oitm t3 on t3.itemCode = t1.ItemCode 
                                      INNER join wor1 t4 on t4.DocEntry =  t1.U_SRTP_BaseOrd and t4.U_Pos_id = t1.U_Pos_id
                                      LEFT join IBT1 t2 on t1.DocEntry = t2.BaseEntry and t1.LineNum = t2.BaseLinNum and Direction = 1 AND T2.ItemCode = T1.ItemCode
 
                                     where t1.U_SRTP_BaseOrd = " + docEntry + " and t1.U_Pos_id=" + posId + " and t1.ItemCode='"+itemCode+"'");

                 if (res.HasRows) {
                     while (res.Read())
                     {
                       optionsbatch.Add(new SerialBatchNum { BatchNum = res["BatchNum"].ToString(), Quantity = decimal.Parse(res["Quantity"].ToString()), UomCode = res["UomCode"].ToString(), UomName = res["InvntryUom"].ToString() });
                     }
                 }
                   res.Close();
               var  optionsbatch_ = (from p in optionsbatch.AsEnumerable() group p by new { p.BatchNum, p.UomCode,p.UomName } 
                                     into r
                                     select new  {   BatchNum = r.Key.BatchNum, UomCode = r.Key.UomCode, UomName = r.Key.UomName, Quantity = r.Sum((s) => decimal.Parse(s.Quantity.ToString())) }).ToList();

                optionsbatch.Clear();

                foreach (var opt in optionsbatch_)
                {
                    optionsbatch.Add(new SerialBatchNum { BatchNum  = opt.BatchNum, Quantity = opt.Quantity, UomCode = opt.UomCode, UomName = opt.UomName});

                }

                ViewBag.itemCode = itemCode;                

                ViewBag.optionsbatch = optionsbatch;

                ViewBag.ProductTraceId = ProductTraceId;

                ViewBag.total = optionsbatch.Count();

                ViewBag.baseQty = baseQty;

                ViewBag.data = conn.Connect("SELECT t1.* FROM ATEEI_SRTP_PRODUCT_TRACE_WO T0 LEFT JOIN ATEEI_SRTP_PRODUCT_TRACE_BATCH T1 ON T0.ID = T1.ID_PRODUCT_TRACE_WO WHERE T1.ID_PRODUCT_TRACE_WO = " + ProductTraceId + "");

            }
                return View();            
        }
        public string ChgItemProdTrace(int id,string itemCode)
        {
            try
            {  
                SQLConnection conn = new SQLConnection(_context);

                var result = conn.Connect("SELECT top 1 ID FROM ATEEI_SRTP_PRODUCT_TRACE_BATCH  where ID_PRODUCT_TRACE_WO ="+id);

                if (!result.HasRows) {
                    conn.SqlNonQuery("UPDATE ATEEI_SRTP_PRODUCT_TRACE_WO SET ItemCode = '" + itemCode + "' where ID = " + id + " ");
                    result.Close();
                    return "true";                  
                }
                else
                {
                    result.Close();
                    return "Já existe rastreabilidade nesse item! Adicione mais uma linha para Alternativos!" ;
                }            
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
        public string LoadDetail(int docEntry, string serial, string code)
        {
            return code;
        }
        public string ScanTraceWO(int docEntry,string itemCode,string serial,string batchNum, decimal quantity,int posId)
        {
            try
            {
                SQLConnection conn = new SQLConnection(_context);
                string id ="";
                string query = "SELECT * FROM ATEEI_SRTP_PRODUCT_TRACE_WO where ItemCode = '" + itemCode + "' AND SerialNumber = '" + serial + "' AND DocEntry =" + docEntry+" AND PosId="+posId;
                var result = conn.Connect(query);
                
                                while (result.Read())
                                {
                                    id = result["ID"].ToString();
                                }

                                result.Close();

                string qr = @" declare @ProdWO int, @itemcode nvarchar(200), @batchNum nvarchar(200), @quantity numeric(19,6)  
                                                        set @ProdWO = " + id.ToString() + " set @itemcode = '" + itemCode + "' set @batchNum = '" + batchNum + "' set @quantity =" + quantity.ToString().Replace(",", ".") + "" +
                                                        " INSERT INTO ATEEI_SRTP_PRODUCT_TRACE_BATCH(ID_PRODUCT_TRACE_WO, ItemCode, BatchNum, Quantity,DateAssembly,AssemblyRout ,UserAssembly) VALUES(@ProdWO, @itemcode, @batchNum, @quantity, getdate(),"+posId+" ,"+user.EmpID+")";
                result = conn.Connect(qr);


                return "true";


            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
        public string SaveTableProductTraceSerialBatch(string query)
        {
            SQLConnection conn = new SQLConnection(_context);
            conn.SqlNonQuery(query);
            return "true";
        }

        public string AutoTraceBySerial(int docEntry, string serial )
        {
            try 
            {   SQLConnection conn = new SQLConnection(_context);
                List<SerialBatchNum> optionsbatch = new List<SerialBatchNum>();

                var res = conn.Connect((@"SELECT t4.ItemCode as ItemCode, 
                                                    t4.ItemName,
                                                    (case when t6.UomCode IS null then 'Manual' else t6.UomCode end) as UomCode,
                                                    t4.InvntryUom,
                                                    (CASE WHEN t3.DistNumber IS null THEN(CASE WHEN t7.batchnum is null THEN 0 ELSE t7.Quantity  END) ELSE t3.Quantity END) as Quantity,
                                         (CASE WHEN t3.DistNumber IS null THEN(CASE WHEN t7.batchnum is null THEN '' ELSE t7.batchnum  END) ELSE t3.distnumber END) AS BatchNum                                        
                                         from dbo.B1_SnBAllocateDocView t0 
                                         left join OWOR t1 on t0.SnBAllocateViewDocEntry = t1.DocEntry and t0.SnBAllocateViewDocType = 202                                    
                                         left join OITM t4 on t0.SnBAllocateViewItemCode = t4.ItemCode 
                                         left join OSRn t3 on t0.SnBAllocateViewSnbSysNum = t3.SysNumber and t3.ItemCode = t4.ItemCode 
                                         left join WOR1 t6 on t1.DocEntry = t6.DocEntry and t6.LineNum = t0.SnBAllocateViewDocLine 
                                         left join OIBT t7 on t0.SnBAllocateViewSnbSysNum = t7.SysNumber and t7.ItemCode = t4.ItemCode and t7.WhsCode = t0.SnBAllocateViewLocCode 
                                         where SnBAllocateViewDocEntry = " + docEntry + " and SnBAllocateViewDocType = 202 and t0.SnBAllocateViewAllocQty > 0 "));

                while (res.Read())
                {
                    optionsbatch.Add(new SerialBatchNum { ItemCode= res["ItemCode"].ToString(), BatchNum = res["BatchNum"].ToString(), Quantity = decimal.Parse(res["Quantity"].ToString()), UomCode = res["UomCode"].ToString(), UomName = res["InvntryUom"].ToString() });
                }
                res.Close();

                res = conn.Connect(@" select t1.ItemCode,
                                      (case when t4.UomCode IS null then 'Manual' else t4.UomCode end) as UomCode ,                 
                                      t1.Dscription,                                   
                                      t0.DocEntry,
                                      t2.BatchNum ,
                                      t1.Quantity ,
                                      t3.InvntryUom
                                     from OWTR t0 
                                     inner join WTR1 t1 on t0.DocEntry = t1.DocEntry 
                                     inner join oitm t3 on t3.itemCode = t1.ItemCode 
                                     INNER join wor1 t4 on t4.DocEntry =  t1.U_SRTP_BaseOrd and t4.U_Pos_id = t1.U_Pos_id
                                     LEFT join IBT1 t2 on t1.DocEntry = t2.BaseEntry and t1.LineNum = t2.BaseLinNum and Direction = 1 AND T2.ItemCode = T1.ItemCode

                                     where t1.U_SRTP_BaseOrd = " + docEntry + " ");

                if (res.HasRows)
                {
                    while (res.Read())
                    {
                        optionsbatch.Add(new SerialBatchNum { ItemCode = res["ItemCode"].ToString(), BatchNum = res["BatchNum"].ToString(), Quantity = decimal.Parse(res["Quantity"].ToString()), UomCode = res["UomCode"].ToString(), UomName = res["InvntryUom"].ToString() });
                    }
                }
                res.Close();
                var optionsbatch_ = (from p in optionsbatch.AsEnumerable()
                                     group p by new { p.ItemCode,p.BatchNum, p.UomCode, p.UomName }
                                      into r
                                     select new { ItemCode =r.Key.ItemCode, BatchNum = r.Key.BatchNum, UomCode = r.Key.UomCode, UomName = r.Key.UomName, Quantity = r.Sum((s) => decimal.Parse(s.Quantity.ToString())) }).ToList();

                optionsbatch.Clear();               
                
             
              List<SerialBatchNum> batchNumAllocated = new List<SerialBatchNum>();
                var batchList = conn.Connect("select DocEntry,T1.ItemCode,BatchNum,SUM(t1.Quantity) AS Quantity from  ATEEI_SRTP_PRODUCT_TRACE_WO T0 LEFT JOIN ATEEI_SRTP_PRODUCT_TRACE_BATCH T1 ON T0.ID = T1.ID_PRODUCT_TRACE_WO WHERE T0.DocEntry = "+docEntry+" AND T1.ID IS NOT NULL GROUP BY DocEntry,T1.ItemCode,BatchNum");

                while (batchList.Read())
                {
                   batchNumAllocated.Add(new SerialBatchNum { BatchNum = batchList["BatchNum"].ToString(), Quantity = decimal.Parse(batchList["Quantity"].ToString()),  ItemCode = batchList["ItemCode"].ToString() });
                }

                batchList.Close();


                var result = conn.Connect("SELECT * FROM ATEEI_SRTP_PRODUCT_TRACE_WO T0 LEFT JOIN OITM T1 ON T0.ItemCode = T1.ItemCode  where SerialNumber='" + serial + "' and NOT EXISTS(select * from  ATEEI_SRTP_PRODUCT_TRACE_BATCH WHERE ID_PRODUCT_TRACE_WO = T0.ID) ");


                string command = "";
                int feed = 0;
                string noFeedItems = "";

                while (result.Read()) 
                {
                    feed = 0;
                   /// command = command + result["ItemCode"].ToString();
                    foreach (var opt in optionsbatch_.FindAll(x => x.ItemCode == result["ItemCode"].ToString() && x.Quantity > decimal.Parse(result["Quantity"].ToString())))
                    {
                        ///command = command + opt.BatchNum;
                        decimal qty = opt.Quantity;
                        foreach (var batch in batchNumAllocated.FindAll(x => x.ItemCode == opt.ItemCode  && x.BatchNum == opt.BatchNum))
                        {
                           
                            qty = opt.Quantity - batch.Quantity;
                            ///command = command +qty.ToString();
                        }
                     
                        if (qty > decimal.Parse(result["Quantity"].ToString())) 
                        {

                            command = command + @" INSERT INTO ATEEI_SRTP_PRODUCT_TRACE_BATCH(ID_PRODUCT_TRACE_WO, ItemCode, BatchNum, Quantity) VALUES(" + result["ID"].ToString() + ",'" + opt.ItemCode + "','" + opt.BatchNum + "'," + result["Quantity"].ToString().Replace(",", ".") + ") ";
                            feed = 1;

                        }
                    }
                    if (feed == 0)
                    {
                        noFeedItems = " Item:" + result["ItemCode"].ToString()+" - Pos: "+ result["PosId"].ToString() + noFeedItems;
                    }                  
                }


                result.Close();

                conn.SqlNonQuery(command);


                return noFeedItems;
            }
            catch (Exception e)
            {
                return e.Message;

            }
           
        }


        public string DeleteSerialBatch(int id)
        {
            try
            {
                string query = " DELETE FROM ATEEI_SRTP_PRODUCT_TRACE_BATCH WHERE ID =" + id;


                SQLConnection con = new SQLConnection(_context);

               

                System.Data.Common.DbDataReader data = con.Connect(query);
             /*   while (data.Read())
                {
                    html = html + "<tr>" +
                                    "<td>" + data["ItemCode"] + "</td>" +
                                    "<td>" + data["BatchNum"] + "</td> " +
                                    "<td>" + data["Quantity"] + "</td>" +
                                    "<td>" + data["PosId"] + "</td>" +
                                    "<td><div onclick=\"DeleteSetItems(" + data["ID"] + ", " + data["ID_RG_SETUP"] + " )\"> Excluir<div></td>" +
                                  "</tr> ";
                }
             */


                return "true";
            }
            catch (Exception e)
            {
                return e.Message;

            }


        }





    }
}

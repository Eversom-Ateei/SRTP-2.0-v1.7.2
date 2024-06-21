using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using WebApplication4.Context;
using WebApplication4.DAO;
using WebApplication4.Models;
using WebApplication4.Util;

namespace WebApplication4.Controllers
{   
    public class QualityControlController : Controller
    {
        private TemplateContext _context;

        private static SAPbobsCOM.Company company;
        // GET: QualityControl
        public QualityControlController(TemplateContext context)
        {

            _context = context;

        }
        public ActionResult Index()
        {
          
            if (HttpContext.Session.GetString("user") == null)
            {
                ViewBag.userSession = "false";
            }
            else
            {
                ViewBag.userSession = HttpContext.Session.GetString("user").ToString();
                ViewBag.userName = HttpContext.Session.GetString("userName").ToString();
            }
            return View();
        }
        //Product Inspect
        
        public ActionResult ProductInspect()
        {
            try
            {

                if (HttpContext.Session.GetString("user") == null)
                {
                    ViewBag.userSession = "false";
                }
                else
                {
                    ViewBag.userSession = HttpContext.Session.GetString("user").ToString();
                    ViewBag.userName = HttpContext.Session.GetString("userName").ToString();

                    ProductInspect productInspect = new ProductInspect();
                    List<ProductInspect> productInspects = new List<ProductInspect>();


                    ViewBag.userSession = HttpContext.Session.GetString("user").ToString();
                    ViewBag.userName = HttpContext.Session.GetString("userName").ToString();

                    string query = "select T0.ORDEM as DocEntry,ID_RG_TEMPO as TimeRegisterID,ItemCode,ItemName,TERMINO as EndTimeRegister,cast(sum(T0.QUANTIDADE) as numeric(19,6) )as OpenQty,cast((select SUM(QUANTIDADE) from ATEEI_SRTP_PLACAS_INSPECIONADAS ST0 where ST0.ID_RG_TEMPO = T0.ID_RG_TEMPO) as numeric(19,6)) as Quantity from ATEEI_SRTP_PLACAS_INSPECIONADAS T0 INNER JOIN OITM T1 ON T0.ITEM = T1.ItemCode LEFT JOIN ATEEI_SRTP_RG_TEMPO T2 ON T2.ID = T0.ID_RG_TEMPO where ID_RG_TEMPO is not null and TERMINO is not null group by ID_RG_TEMPO,T0.ORDEM, ItemCode, ItemName,TERMINO order by termino desc";

                    productInspects = _context.ProductInspects.FromSqlRaw(query).ToList();

                    ViewBag.data = productInspects;

                }

            }catch(Exception e)
            {
                


            }
            return View();
        }
        
        //Product Inspect Lines
        public ActionResult ProductInspectLines(int timeRegisterID)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                ViewBag.userSession = "false";
            }
            else
            {
                ViewBag.userSession = HttpContext.Session.GetString("user").ToString();
                ViewBag.userName = HttpContext.Session.GetString("userName").ToString();

                SQLConnection conn = new SQLConnection(_context);
                 var result = conn.Connect("SELECT U_MOTIVO FROM \"@MOT_BLOQ_L\"");
                
                 List<BlockReason> reason = new List<BlockReason>();
                 BlockReason block = new BlockReason();
                 while (result.Read())
                 {
                     block.Reason = result["U_MOTIVO"].ToString();
                     reason.Add(block);
                 }
                 ViewBag.reason = reason;
                 
                result.Close();
                string query = "SELECT t0.*,t1.*,t2.*,H0.QUANTIDADE,H0.N_SERIE FROM ATEEI_SRTP_PLACAS_INSPECIONADAS H0 INNER JOIN  ATEEI_SRTP_PLACAS_INSPECIONADAS_PARAMETRO T0 ON H0.ID = T0.ID_PLACAS_INSPECIONADAS LEFT JOIN OITM T1 ON H0.ITEM = T1.ItemCode left join ohem t2 on t0.usuario = t2.empID WHERE ID_PLACAS_INSPECIONADAS =" + timeRegisterID + " ";
               
                result = conn.Connect(query);

                while (result.Read())
                {
                    if (result["N_SERIE"].ToString() == "NENHUM")
                    {

                        ViewBag.itemCode = result["ItemCode"];
                        ViewBag.itemName = result["ItemName"];
                        ViewBag.serial = "--";

                    }
                    else
                    {
                        ViewBag.itemCode = result["ItemCode"];
                        ViewBag.itemName = result["ItemName"];
                        ViewBag.serial = result["N_SERIE"];
                    }
                }

                result.Close();           
                ViewBag.data = conn.Connect(query);
                

            }

            return View();
        }
        public string ApproveAll(int timeRegisterId, string status)
        {
            try
            {
                SQLConnection conn = new SQLConnection(_context);
              
                var user= JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));


                string query = (" UPDATE t1 " +
                                 " SET t1.APROVADO = '" + status + "', " +
                                 " T1.QUANTIDADE_BLOQUEADA = 0,   " +
                                 " t1.MOTIVO_STATUS = '', " +
                                 " T1.DATA = GETDATE(), " +
                                 " T1.USUARIO = " + user.EmpID + " " +
                                 " FROM ATEEI_SRTP_PLACAS_INSPECIONADAS t0 " +
                                 " inner join ATEEI_SRTP_PLACAS_INSPECIONADAS_PARAMETRO t1 on t0.ID = t1.ID_PLACAS_INSPECIONADAS " +
                                 " where ID_RG_TEMPO =" + timeRegisterId + " and t1.Aprovado = 'N' ");

                
                conn.SqlNonQuery(query);

                query = (" UPDATE t0 " +
                                 " SET t0.APROVADO = '" + status + "', " +
                                 " T0.MOTIVO_STATUS = '', " +
                                 " T0.DATA = GETDATE(), " +
                                 " T0.USUARIO = " + user.EmpID + " " +
                                 " FROM ATEEI_SRTP_PLACAS_INSPECIONADAS t0 " +
                                 " INNER JOIN ATEEI_SRTP_PLACAS_INSPECIONADAS_PARAMETRO t1 on t0.ID = t1.ID_PLACAS_INSPECIONADAS " +
                                 " WHERE ID_RG_TEMPO = " + timeRegisterId + "  and t0.Aprovado not in ('Y','B') ");


                conn.SqlNonQuery(query);




                return "true";

            }
            catch (Exception e)
            {

                return e.Message;
            }


        }
        public ActionResult ProductInspectByTimeRegister(int timeRegisterID)
        {
            try
            {
                if (HttpContext.Session.GetString("user") == null)
                {
                    ViewBag.userSession = "false";
                }
                else
                {
                    ViewBag.userSession = HttpContext.Session.GetString("user").ToString();
                    ViewBag.userName = HttpContext.Session.GetString("userName").ToString();

                    string query = " SELECT ID,ORDEM,ITEM,ItemName,N_SERIE,QUANTIDADE,APROVADO,USUARIO,DATA, FirstName,LastName FROM ATEEI_SRTP_PLACAS_INSPECIONADAS t0 inner join OITM t1 on t0.ITEM = t1.ItemCode left join ohem t2 on t0.usuario = t2.empID WHERE ID_RG_TEMPO=" + timeRegisterID + " ";

                    SQLConnection conn = new SQLConnection(_context);
                    ViewBag.timeRegisterId = timeRegisterID;
                    ViewBag.data = conn.Connect(query);

                }
            }
            catch (Exception e)
            {



            }            
            return View();
        }
        //Online Inspect
        public ActionResult OnlineInspect()
        {
            if (HttpContext.Session.GetString("user") == null)
            {
               
               
                ViewBag.userSession = "false";
            }
            else
            {
                var userInfo2 = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));

                ViewBag.userSession = userInfo2.EmpID.ToString();
                ViewBag.userName = userInfo2.FirstName.ToString();

                string query = " select t0.DocEntry,t0.ItemCode,t2.ItemName ,t1.ItemCode as 'Resource', (ROW_NUMBER() OVER(PARTITION BY T0.docentry ORDER BY T1.U_Pos_id ASC)) as Sequence  from OWOR t0 inner join WOR1 t1 on t0.DocEntry = t1.DocEntry inner join OITM t2 on t0.ItemCode = t2.ItemCode where t1.ItemType = 290 and t0.Status = 'R' ";

                SQLConnection con = new SQLConnection(_context);
                var data = con.Connect(query);
                ViewBag.data = data;
                ViewBag.query = query.ToUpper();

            }
                return View();
        }
        //Online Inspect
        public ActionResult OnlineInspectLines(int id)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                ViewBag.userSession = "false";
            }
            else
            {
                ViewBag.userSession = HttpContext.Session.GetString("user").ToString();
                ViewBag.userName = HttpContext.Session.GetString("userName").ToString();
                string query = "SELECT * FROM ATEEI_SRTP_PRIMEIRA_INSPECAO_PARAMETRO WHERE ID_PRIMEIRA_INSPECAO="+id+"";

                SQLConnection con = new SQLConnection(_context);
               var data = con.Connect(query);
                ViewBag.data = data;
            }
            return View();
        }




     

        //Material Inspect


        public ActionResult MaterialInspect(int docEntry)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                ViewBag.userSession = "false";
            }
            else
            {
                ViewBag.userSession = HttpContext.Session.GetString("user").ToString();
                ViewBag.userName = HttpContext.Session.GetString("userName").ToString();

                BlockReason blockReason = new BlockReason();
                List <BlockReason> blockReasons = new List<BlockReason>();
                MaterialInspect materialInspect = new MaterialInspect();
                List<MaterialInspect> materialInspects = new List<MaterialInspect>();

                string query= ("SELECT U_MOTIVO FROM \"@MOT_BLOQ_L\"");
/*
                blockReasons = _context.BlockReasons.FromSqlRaw(query).ToList();             
*/
                ViewBag.data1 = blockReasons;

                query = "SELECT T2.Itemcode, "+
" T2.ItemName, "+
" LOTE_SERIAL as SerialNumber,"+
" (case when OBS is null then '' else obs end) as Comments,"+
" APROVADO as Status,"+
" COD_PARCEIRO_DE_NEGOCIO as CardCode,"+
" (case when ID_COD_INSP is null then '' else id_cod_insp end) as ParamCode,"+
" (case when MOTIVO_STATUS is null then '' else motivo_status end) as BlockReason, "+
" (CAse when SampleQty is null then 0 else SampleQty END) as SampleQty," +
" Quantidade as Quantity," +
" T1.ID as Id," +
" NOTA_FISCAL AS Invoice,"+
" DOCUMENTO_SAP as DocEntry,"+
" SEQUENCIA as LineNum,"+
" (case when DATA is null then '' else  data end) as DateRelease," +
" (case when FirstName is null then '' else FirstName end) as FirstName,"+
" (case when middleName is null then '' else middleName end) as MiddleName,"+
" (case when lastName is null then '' else LastName end) as LastName,"+
" (case when empID is null then 0 else empId end) as empID, "+
"  cast(cast((case when ExpDate is null then '01-01-1900' else ExpDate end) as DATE) as Nvarchar(10)) as ExpDate ," +
" (CASE WHEN NI IS NULL THEN '' ELSE NI END) AS NI ,"+
" (Case when PAS is null then '' else PAS END) AS PAS, "+
" (CASE when Justify is null then '' else justify end) AS Justify"+
" FROM ATEEI_SRTP_INSPECAO_RECEBIMENTO T1 LEFT JOIN OITM T2 ON T1.ITEM = T2.ItemCode LEFT JOIN OHEM t3 on USUARIO = empID" +
" LEFT JOIN OBTN T4 ON T2.ItemCode = T4.ItemCode AND T4.DistNumber = T1.LOTE_SERIAL " +
" left join OPDN t5 on t5.docEntry = DOCUMENTO_SAP  " +
" Left join PDN1 t6 on t6.docEntry = t5.docEntry and t6.LineNum = SEQUENCIA" +


" WHERE DOCUMENTO_SAP = " +docEntry+" order by documento_sap desc";


             
                
                materialInspects = _context.MaterialInspects.FromSqlRaw(query).ToList();

                ViewBag.data = materialInspects;
            }
            
            return View();
        }
        //Material Inspect




        public string teste()
        {

            return "{ "+
   " \"cep\": \"01001-000\", "+
  " \"logradouro\": \"Praça da Sé\" "+
" } ";

        }
        public ActionResult MaterialInspectByDoc(int status)
        {
           
            if (HttpContext.Session.GetString("user") == null)
            {
                ViewBag.userSession = "false";
            }
            else
            {
                ViewBag.userSession = HttpContext.Session.GetString("user").ToString();
                ViewBag.userName = HttpContext.Session.GetString("userName").ToString();

                string query = "";
             
               
                if ((DocStatus)status == DocStatus.Close)
                {
                   query = "SELECT t1.*,t1.Serial as Invoice, (select firstName from OHEM where OwnerCode = empID) as FirstName , (select LastName from OHEM where OwnerCode = empID) as LastName  FROM OPDN T1   order by t1.docentry desc";
                }
                else
                {

                    query = "SELECT t1.*,t1.Serial as Invoice, (select firstName from OHEM where OwnerCode = empID) as FirstName , (select LastName from OHEM where OwnerCode = empID) as LastName  FROM OPDN T1  WHERE (SELECT TOP 1 1 FROM ATEEI_SRTP_INSPECAO_RECEBIMENTO WHERE DOCUMENTO_SAP = T1.DocEntry AND APROVADO = 'N') IS NOT NULL  order by t1.docentry desc";

                }


                List<ReceiptOfGoods> receiptOfGoods = new List<ReceiptOfGoods>();
                receiptOfGoods = _context.ReceiptOfGoods.FromSqlRaw(query).ToList();

                ViewBag.data = receiptOfGoods;
                ViewBag.status = status;

            }

            return View();
        }
        //Material Inspect
        public ActionResult MaterialInspectLines(int materialInspectId)
        {
            try
            {

                if (HttpContext.Session.GetString("user") == null)
                {
                    ViewBag.userSession = "false";
                }
                else
                {
                    ViewBag.userSession = HttpContext.Session.GetString("user").ToString();
                    ViewBag.userName = HttpContext.Session.GetString("userName").ToString();


                    string query = "SELECT t0.ID_INSPECAO_RECEBIMENTO as Id_MaterialInspect ,t0.ID as Id,t0.COD_PARAMETRO as ParamId, "+
" (case when t0.Measurement IS null then '' else t0.Measurement end) as Measurement, "+
" (case when t0.OBS IS null then '' else t0.OBS end) as Comments, "+
" t0.APROVADO as Status, "+
" (Case when t0.MOTIVO_STATUS is null then '' else t0.MOTIVO_STATUS end) Reason, "+
" t0.VALOR as Description, " +
" (case when T2.SampleQty is null then 0 else t2.SampleQty end) as SampleQty, " +
" (case when T2.QUANTIDADE is null then 0 else t2.QUANTIDADE end) as Quantity, " +
" (case when QUANTIDADE_BLOQUEADA is null then 0 else quantidade_bloqueada end) as BlockQty ,  "+
" (case when t1.FirstName IS null then '' else t1.firstName end)as FirstName, "+
" (case when t1.MiddleName IS null then '' else t1.middleName end)as MiddleName, "+
" (case when t1.LastName IS null then '' else t1.lastName end ) LastName,  "+
" (case when t0.data is null then '' else t0.DATA end)as DateRelease, "+
" (case when t0.ToolCod is null then '' else t0.ToolCod end)as ToolCod," +
" (case when t0.SampleNumber is null then 0 else t0.SampleNumber end)+1 as SampleNumber," +
" (case when t0.Minimun is null then '' else t0.Minimun end) as Minimun , "+
" (case when t0.Maximun is null then '' else t0.Maximun end) as Maximun , "+
" (case when t0.Mark is null then '' else t0.Mark end) as Mark " +

" FROM ATEEI_SRTP_INSPECAO_RECEBIMENTO_PARAMETRO T0 INNER JOIN ATEEI_SRTP_INSPECAO_RECEBIMENTO T2 ON T0.ID_INSPECAO_RECEBIMENTO = T2.ID LEFT JOIN OHEM T1 ON T0.USUARIO = T1.empID " +


"WHERE ID_INSPECAO_RECEBIMENTO = " +materialInspectId+ " order by  (case when t0.SampleNumber is null then 0 else t0.SampleNumber end) asc ";
                    List<MaterialInspectLine> materialInspectLine = new List<MaterialInspectLine>();
                    materialInspectLine =  _context.MaterialInspectLines.FromSqlRaw(query).ToList();
                    ViewBag.data = materialInspectLine;
                    ///reasons
                    List<BlockReason> blockReasons = new List<BlockReason>();
                    query = ("SELECT U_MOTIVO as Reason FROM \"@MOT_BLOQ_L\"");
                    blockReasons = _context.BlockReasons.FromSqlRaw(query).ToList();
                   
                    ViewBag.Reason = blockReasons;

                   



                    List<ProductionTool> productionTools = new List<ProductionTool>();
                    productionTools = _context.ProductionTools.FromSqlRaw(" SELECT ID, (CASE when ToolCod IS null then '' else ToolCod end)as ToolCod  , "+
	                                                                      " (CASE when Dscription IS null then '' else Dscription end)as Dscription , "+
	                                                                      " (CASE when Department IS null then '' else Department end)as Department , "+
	                                                                      " (CASE when SttsMntnance IS null then '' else SttsMntnance end)as SttsMntnance "+
                                                                          " FROM ATEEI_SRTP_ADDON_TOOLS_REG T0").ToList();

                    ViewBag.Tools = productionTools;


                 query = ("Select T0.*,t1.ItemCode,T1.ItemName,T1.U_PARTNUMBER as PartNumber, T1.U_OBS_ITEM as Comments,T2.FirmName,t1.ManBtchNum,t1.ManSerNum,'0' as PosId from ATEEI_SRTP_INSPECAO_RECEBIMENTO T0 INNER JOIN OITM T1 ON T0.ITEM = T1.ItemCode LEFT JOIN OMRC T2 ON T1.FirmCode = T2.FirmCode   where ID = " + materialInspectId + "");

                    List<ItemMasterData> itemMasterDatas = new List<ItemMasterData>();
                    itemMasterDatas= _context.ItemMasterDatas.FromSqlRaw(query).ToList() ;
                

                    foreach (ItemMasterData data in itemMasterDatas)
                    {
                        ViewBag.itemName = data.ItemName;
                        ViewBag.itemCode = data.ItemCode;
                        ViewBag.manufacturer = data.FirmName;
                        ViewBag.comments = data.Comments;
                        ViewBag.partNumber = data.PartNumber;

                    }                    
                }

            }
            catch (Exception e)
            {
                ViewBag.itemCode = e.Message;


                ///Console.WriteLine(e.Message);
               
            }
            return View();
        }
       
        public string UpdateCommentsMaterialInspect(int materialInspectId, string comments)
        {

            try
            {
                SQLConnection conn = new SQLConnection(_context);
               conn.SqlNonQuery("UPDATE ATEEI_SRTP_INSPECAO_RECEBIMENTO SET OBS = '" + comments + "' WHERE ID = " + materialInspectId + "");

                return "true";

            }
            catch (Exception e)
            {

                return e.Message;

            }

        }


        public string UpdateSampleMaterialInspect(string ni,int materialInspectId,string pas,string justify,double quantity)
        {
            string ret = "";
            try
            {
                SQLConnection conn = new SQLConnection(_context);
                if (!conn.Connect("select * from ATEEI_SRTP_INSPECAO_RECEBIMENTO_PARAMETRO WHERE ID_INSPECAO_RECEBIMENTO = " + materialInspectId + " and APROVADO = 'Y' ").HasRows) 
                {
               

                    if (pas != "100" &&  ni != "100")
                    {

                        string noquery = ("UPDATE ATEEI_SRTP_INSPECAO_RECEBIMENTO SET NI = '" + ni + "', PAS = '" + pas + "', justify = '" + justify + "'" +
                   ", SampleQty = (select(case when " +
" (select top 1 Samplesize from ATEEI_SRTP_ADDON_IL xt1 inner join ATEEI_SRTP_ADDON_AQL xt2 on xt2.SampleCode = xt1.SampleCode where xt2.CodeAQL = '" + pas + "' and CodePas = '" + ni + "' and xt1.\"From\" <= " + quantity.ToString().Replace(",", ".") + " order by \"to\" desc) is null then 1 else " +
" (select top 1 Samplesize from ATEEI_SRTP_ADDON_IL xt1 inner join ATEEI_SRTP_ADDON_AQL xt2 on xt2.SampleCode = xt1.SampleCode where xt2.CodeAQL = '" + pas + "' and CodePas = '" + ni + "' and xt1.\"From\" <= " + quantity.ToString().Replace(",", ".") + " order by \"to\" desc) end)) " +

                   " WHERE ID = " + materialInspectId + "");



                        conn.SqlNonQuery(noquery);
                    }
                    else
                    {

                        string noquery = ("UPDATE ATEEI_SRTP_INSPECAO_RECEBIMENTO SET NI = '" + ni + "', PAS = '" + pas + "', justify = '" + justify + "'" +               
               " WHERE ID = " + materialInspectId + "");



                        conn.SqlNonQuery(noquery);


                    }





                    /////precisa validar
                    conn.SqlNonQuery(" declare @I int; declare @mtId int; set @mtId = "+materialInspectId+"; "+
                                     " declare @tb table(  [ID_INSPECAO_RECEBIMENTO][int] NULL,    [COD_PARAMETRO][nvarchar](50) NULL,    [PARAMETRO][nvarchar](50) NULL,    [APROVADO][varchar](3) NULL,    [OBS][text] NULL,    [DATA][datetime] NULL,    [USUARIO][int] NULL,    [QUANTIDADE_BLOQUEADA][numeric](19, 6) NULL,    [MOTIVO_STATUS][nvarchar](50) NULL, "+
                                     " [RELEVANTE][nvarchar](10) NULL,  [VALOR][ntext] NULL,   [Measurement][nvarchar](36) NULL,    [ToolCod][nvarchar](100) NULL) "+                        
                                     " insert into @tb(ID_INSPECAO_RECEBIMENTO, COD_PARAMETRO, PARAMETRO, APROVADO, OBS, DATA, USUARIO, QUANTIDADE_BLOQUEADA, MOTIVO_STATUS, RELEVANTE, VALOR, Measurement, ToolCod) "+
                                     " select distinct ID_INSPECAO_RECEBIMENTO,	COD_PARAMETRO,	PARAMETRO,	APROVADO,	cast(OBS as varchar(max)),	NULL ,	NULL,	0,	'',	RELEVANTE,	cast(VALOR as nvarchar(max)),'','' from ATEEI_SRTP_INSPECAO_RECEBIMENTO_PARAMETRO WHERE ID_INSPECAO_RECEBIMENTO = @mtId; "+
                                     " delete from ATEEI_SRTP_INSPECAO_RECEBIMENTO_PARAMETRO where ID_INSPECAO_RECEBIMENTO = @mtId "+
                                     " set @I = (select SampleQty from ATEEI_SRTP_INSPECAO_RECEBIMENTO WHERE ID = @mtId) "+
                                     " DECLARE @C INT; SET @C = 0; "+
                                     " while @I > @C "+
                                     " begin "+
                                     " insert into ATEEI_SRTP_INSPECAO_RECEBIMENTO_PARAMETRO(ID_INSPECAO_RECEBIMENTO, COD_PARAMETRO, PARAMETRO, APROVADO, OBS, DATA, USUARIO, QUANTIDADE_BLOQUEADA, MOTIVO_STATUS, RELEVANTE, VALOR, Measurement, ToolCod, SampleNumber) "+
                                     " select ID_INSPECAO_RECEBIMENTO, COD_PARAMETRO, PARAMETRO, APROVADO, OBS, DATA, USUARIO, QUANTIDADE_BLOQUEADA, MOTIVO_STATUS, RELEVANTE, VALOR, Measurement, ToolCod, @C from @tb WHERE ID_INSPECAO_RECEBIMENTO = @mtId "+
                                     " set @C = @C + 1; "+
                                     " end; ");
                    





                    ret = "Parâmetros Atualizados!";

                }
                else
                {
                    ret = "Material inspecionado! Impossivel mudar os parâmetros!";
                }


                return ret;

            }
            catch (Exception e)
            {

                return e.Message;

            }

        }


        public string UpdateDueDateMaterialInspect(string itemCode, string batchNum, DateTime duedate)
        {
            ///refer ---- https://blogs.sap.com/2016/07/13/sample-code-to-update-existing-item-batches-properties-via-di-api/

            try
            {

                company = ConnectionSAP.Connect();

                if (company.Connected)
                {
                    SAPbobsCOM.CompanyService oCompanyService;

                    oCompanyService = company.GetCompanyService();

                    /////////////////////////

                    SAPbobsCOM.BatchNumberDetailsService oBatchNumbersService;

                    oBatchNumbersService = (BatchNumberDetailsService)oCompanyService.GetBusinessService(SAPbobsCOM.ServiceTypes.BatchNumberDetailsService);

                    SAPbobsCOM.BatchNumberDetailParams oBatchNumberDetailParams;

                    oBatchNumberDetailParams = (BatchNumberDetailParams)oBatchNumbersService.GetDataInterface(SAPbobsCOM.BatchNumberDetailsServiceDataInterfaces.bndsBatchNumberDetailParams);

                    /////////////////////
                    int docentry = int.Parse(DocEntryFromBatchNum(itemCode, batchNum));

                    oBatchNumberDetailParams.DocEntry = docentry;

                    SAPbobsCOM.BatchNumberDetail oBatchNumberDetail;

                    oBatchNumberDetail = oBatchNumbersService.Get(oBatchNumberDetailParams);

                    oBatchNumberDetail.ExpirationDate = duedate;

                    /// oBatchNumberDetail.UserFields.Item("U_PalletID").Value = “45109 - 07”;

                    oBatchNumbersService.Update(oBatchNumberDetail);

                    ////stop used serviços on function
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oBatchNumberDetail);

                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompanyService);

                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oBatchNumbersService);

                    System.Runtime.InteropServices.Marshal.ReleaseComObject(oBatchNumberDetailParams);

                    company.Disconnect();
                  
                    return "Vencimento Alterado! " + company.GetLastErrorDescription();
                    
                }
                else
                {
                    ///  return Startup.cfs.GetSection("ConnectionSAP").GetSection("CompanyDB").Value + Startup.cfs.GetSection("ConnectionSAP").GetSection("DbServerType").Value;
                    return company.GetLastErrorDescription() + "--" + company.DbUserName + "--" + company.DbPassword + "--" + company.Password + "--" + company.LicenseServer + "--" + company.UserName + company.CompanyDB + "--" + company.DbServerType;
                }
            }

            catch (Exception e)

            {

                return e.Message;

            }          

        }
        public string VerifyUserFunction()
        {
            string ret = "M";
            
            User userInfo2 = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));

            string userSession = userInfo2.EmpID.ToString();
            SQLConnection conn  = new SQLConnection(_context);
            System.Data.Common.DbDataReader data = conn.Connect("select * from HTM1 where empID ="+userSession);
            while (data.Read())
            {
                if (data["role"].ToString() == "L") {
                    ret = data["role"].ToString();
                }
            }
            
            return ret;
        }


        /*
        public string UpdateCommentsMaterialInspectLines(int materialInspectLineId, string comments)
        {
         
            try{

                SQLConnection.SqlNonQuery("UPDATE ATEEI_SRTP_INSPECAO_RECEBIMENTO_PARAMETRO SET OBS = '" + comments + "' WHERE ID = " + materialInspectLineId + "");

                return "true";

            } catch(Exception e)
            {

                return e.Message;

            }
            
        }
        public string UpdateReasonMaterialInspectLines(int materialInspectLineId, string reason)
        {

            try
            {

                SQLConnection.SqlNonQuery("UPDATE ATEEI_SRTP_INSPECAO_RECEBIMENTO_PARAMETRO SET MOTIVO_STATUS = '" + reason + "' WHERE ID = " + materialInspectLineId + "");

                return "true";

            }
            catch (Exception e)
            {

                return e.Message;

            }

        }
            public string UpdateBlockQtyMaterialInspectLines(int materialInspectLineId, double blockQty, string status)
        {
            try
            {




                SQLConnection.SqlNonQuery("UPDATE ATEEI_SRTP_INSPECAO_RECEBIMENTO_PARAMETRO SET QUANTIDADE_BLOQUEADA = " + blockQty.ToString().Replace(",",".") + " ,APROVADO = '"+status+"' WHERE ID = " + materialInspectLineId + "");

                return "true";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }


        public string UpdateMeasurementMaterialInspectLines(int materialInspectLineId, string measurement)
        {
            try
            {
                SQLConnection.SqlNonQuery("UPDATE ATEEI_SRTP_INSPECAO_RECEBIMENTO_PARAMETRO SET Measurement = '"+measurement+"'  WHERE ID = " + materialInspectLineId + "");

                return "true";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        public string UpdateStatusMaterialInspectLines(int materialInspectLineId, string status, int materialInspectId, double quantity)
        {
            try
            {
                if (status == "Y")
                {

                    SQLConnection.SqlNonQuery("UPDATE ATEEI_SRTP_INSPECAO_RECEBIMENTO_PARAMETRO SET APROVADO = '" + status + "', DATA = GETDATE() ,USUARIO = " + HttpContext.Session.GetString("user").ToString()+ ", QUANTIDADE_BLOQUEADA=0   WHERE ID = " + materialInspectLineId + "");

                }
                else
                {
                    if (status == "B")
                    {


                        SQLConnection.SqlNonQuery("UPDATE ATEEI_SRTP_INSPECAO_RECEBIMENTO_PARAMETRO SET APROVADO = '" + status + "' , DATA = GETDATE(),USUARIO = " + HttpContext.Session.GetString("user").ToString() + ", QUANTIDADE_BLOQUEADA="+quantity+"  WHERE ID = " + materialInspectLineId + "");


                    }

                    else
                    {

                         SQLConnection.SqlNonQuery("UPDATE ATEEI_SRTP_INSPECAO_RECEBIMENTO_PARAMETRO SET APROVADO = '" + status + "', DATA = GETDATE(), QUANTIDADE_BLOQUEADA=0 WHERE ID = " + materialInspectLineId + "");

                    }

                }



                if (SQLConnection.Connect("SELECT COUNT(*) FROM ATEEI_SRTP_INSPECAO_RECEBIMENTO_PARAMETRO WHERE ID_INSPECAO_RECEBIMENTO = "+materialInspectLineId+" AND RELEVANTE = 'sim' AND APROVADO = 'N' ").HasRows)
                {


                    ////RESGATAR O ID DA TABELA PRINCIPAL
                   SQLConnection.SqlNonQuery("UPDATE ATEEI_SRTP_INSPECAO_RECEBIMENTO SET APROVADO = 'Y' WHERE ID = "+materialInspectId );



                }

                return "true";

            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
         */
        //Tests Inspect
        public ActionResult ProductTest(string serialNumber, int rout, int docEntry, int timeRegisterId)
        {
            if (HttpContext.Session.GetString("user") == null)
            {
                ViewBag.userSession = "false";                
            }
            else
            {
                ViewBag.userSession = HttpContext.Session.GetString("user").ToString();
                ViewBag.userName = HttpContext.Session.GetString("userName").ToString();

                List<ProductionTool> productionTools = new List<ProductionTool>();
                productionTools = _context.ProductionTools.FromSqlRaw(" SELECT ID, (CASE when ToolCod IS null then '' else ToolCod end)as ToolCod  , " +
                                                                      " (CASE when Dscription IS null then '' else Dscription end)as Dscription , " +
                                                                      " (CASE when Department IS null then '' else Department end)as Department , " +
                                                                      " (CASE when SttsMntnance IS null then '' else SttsMntnance end)as SttsMntnance " +
                                                                      " FROM ATEEI_SRTP_ADDON_TOOLS_REG T0").ToList();

                ViewBag.Tools = productionTools;


                List<BlockReason> blockReasons = new List<BlockReason>();
                blockReasons = _context.BlockReasons.FromSqlRaw("SELECT U_MOTIVO as Reason FROM \"@MOT_BLOQ_L\"").ToList();


                ViewBag.reason = blockReasons;

                ViewBag.serial = serialNumber;

                SQLConnection conn = new SQLConnection(_context);

                var head = conn.Connect("SELECT * FROM OWOR T0 INNER JOIN OITM T1 ON T0.ItemCode = T1.ItemCode where t0.DocEntry = " + docEntry + "");

                while (head.Read())
                {

                    ViewBag.itemCode = head["ItemCode"];
                    ViewBag.itemName = head["ItemName"];

                }

                head.Close();
                

                string query = CreateProductTest(serialNumber, rout, docEntry, timeRegisterId);
                


                ViewBag.data = conn.Connect(query);
                

            }
            return View();
        }

        public string SaveTableProductTestLines (string query)
        {
            try
            {
                var userInfo2 = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));

                string user = userInfo2.EmpID.ToString();

                SQLConnection con = new SQLConnection(_context);

                con.SqlNonQuery(query.Replace("{USER}",user));

                return query;


            }
            catch (Exception e)
            {
                return e.Message;


            }


        }

        public string SaveTableMaterialInspectLines(string query, int materialInspectId)
        {
            try
            {
                var userInfo2 = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));

                string user = userInfo2.EmpID.ToString();

                _context.Database.OpenConnection();
                _context.Database.ExecuteSqlCommand(query.Replace("{USER}", userInfo2.EmpID.ToString()));
                _context.Database.CloseConnection();

                var command = _context.Database.GetDbConnection().CreateCommand();                
                    command.CommandText = "SELECT top 1 * FROM ATEEI_SRTP_INSPECAO_RECEBIMENTO_PARAMETRO WHERE ID_INSPECAO_RECEBIMENTO = " + materialInspectId+" AND APROVADO = 'N' ";
                    _context.Database.OpenConnection();
                    var result = command.ExecuteReader().HasRows;
                    _context.Database.CloseConnection();               

                if (result)
                {
                    _context.Database.OpenConnection();
                    _context.Database.ExecuteSqlCommand("UPDATE ATEEI_SRTP_INSPECAO_RECEBIMENTO SET APROVADO = 'N' WHERE ID = " + materialInspectId);
                    _context.Database.CloseConnection();
                }
                else
                {
                   
                 var command1 = _context.Database.GetDbConnection().CreateCommand();
                     command1.CommandText = "SELECT top 1 1 FROM ATEEI_SRTP_INSPECAO_RECEBIMENTO_PARAMETRO WHERE ID_INSPECAO_RECEBIMENTO = " + materialInspectId + " AND RELEVANTE = 'sim' AND APROVADO = 'B' ";
                     _context.Database.OpenConnection();
                     var result1 = command1.ExecuteReader().HasRows;
                     _context.Database.CloseConnection();

                    if (result1)
                    {
                        _context.Database.OpenConnection();
                        _context.Database.ExecuteSqlCommand("UPDATE ATEEI_SRTP_INSPECAO_RECEBIMENTO SET APROVADO = 'B' , USUARIO="+userInfo2.EmpID+",DATA=GETDATE() WHERE ID = " + materialInspectId);
                        _context.Database.CloseConnection();
                    }
                    else
                    {
                        _context.Database.OpenConnection();
                        _context.Database.ExecuteSqlCommand("UPDATE ATEEI_SRTP_INSPECAO_RECEBIMENTO SET APROVADO = 'Y' , USUARIO=" + userInfo2.EmpID + ",DATA=GETDATE() WHERE ID = " + materialInspectId);
                        _context.Database.CloseConnection();
                    }                    
                }

                return "true";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }


        
        public string SaveTableProductInspectLines(string query, int productInspectId)
        {
            try
            {
                var userInfo2 = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));

                string user = userInfo2.EmpID.ToString();

                //Update Paramaters
                SQLConnection conn = new SQLConnection(_context);
                conn.SqlNonQuery(query.Replace("{USER}",user));

                var data = conn.Connect("SELECT top 1 1 FROM  ATEEI_SRTP_PLACAS_INSPECIONADAS_PARAMETRO WHERE ID_PLACAS_INSPECIONADAS = " + productInspectId + " AND APROVADO = 'N' ");

                if (data.HasRows)
                {                    
                    conn.SqlNonQuery("UPDATE ATEEI_SRTP_PLACAS_INSPECIONADAS SET APROVADO = 'N' WHERE ID = " + productInspectId);                
                }
                else
                {
                    data.Close();
                    var data1 = conn.Connect("SELECT top 1 1 FROM  ATEEI_SRTP_PLACAS_INSPECIONADAS_PARAMETRO WHERE ID_PLACAS_INSPECIONADAS = " + productInspectId + " AND RELEVANTE = 'sim' AND APROVADO = 'B' ");
                    if (data1.HasRows)
                    {                      
                       ////RESGATAR O ID DA TABELA PRINCIPAL
                        conn.SqlNonQuery("UPDATE  ATEEI_SRTP_PLACAS_INSPECIONADAS  SET APROVADO = 'B' , USUARIO=" + user + ",DATA=GETDATE() WHERE ID = " + productInspectId);
                    }
                    else
                    {
                        conn.SqlNonQuery("UPDATE  ATEEI_SRTP_PLACAS_INSPECIONADAS  SET APROVADO = 'Y' , USUARIO=" + user + ",DATA=GETDATE() WHERE ID = " + productInspectId);
                    }

                    data1.Close();

                }
                return "true";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        public string DocEntryFromBatchNum(string itemCode, string batchNum)
        {
            SQLConnection con = new SQLConnection(_context);
            var data = con.Connect("select * from obtn where ItemCode = '" + itemCode + "' and DistNumber = '" + batchNum + "'");
            string docEntry = "0";
            while (data.Read())
            {
              docEntry =  data["AbsEntry"].ToString();                
            }
            return docEntry;

        }

        public string CreateProductTest(string serial, int rout,int docEntry,int timeRegisterId)
        {
            try
            {
                string query =$@" DECLARE @ProductTestId INT ,
                                 @PosId INT,
                                 @Serial nvarchar(36),
                                 @TimeRegisterId INT,
                                 @DocEntry INT;
 
                                set @DocEntry = {docEntry}
                                set @TimeRegisterId = {timeRegisterId}
                                set @Serial = '{serial}';
                                set @PosId = {rout};
                                IF NOT EXISTS(SELECT TOP 1 T0.ID FROM  ATEEI_SRTP_ProductTest T0 INNER JOIN ATEEI_SRTP_ProductTestLines T1 on T0.Id = T1.ProductTestId  where DocEntry = @DocEntry and TimeRegisterId = @TimeRegisterId and serial = @Serial)
                                BEGIN
                                INSERT INTO ATEEI_SRTP_ProductTest(DocEntry,ItemCode,Serial,Status,DateRealese,PlanInspCode,UserRealese,Quantity,TimeRegisterId,AdmSerialType,Comments)
                                SELECT t0.DocEntry,t0.ItemCode,@Serial,'N',null,t3.Code,null,1,@TimeRegisterId,(CASE WHEN T5.ManSerNum = 'Y' THEN 'SERIE' ELSE (CASE WHEN T5.ManBtchNum = 'Y' THEN 'LOTE' ELSE 'NENHUM' END ) END),t3.Comments 
                                FROM OWOR T0 
                                INNER JOIN ITT1 T2 ON T0.ItemCode = T2.Father AND  T2.U_Pos_id = @PosId and t2.Type = 290
                                INNER JOIN ATEEI_SRTP_ADDON_TestPlans T3 ON T3.Code = T2.U_TestPlan
                                INNER JOIN ATEEI_SRTP_ADDON_TestPlansLines T4 ON T3.Id = T4.TestPlansId
                                INNER JOIN OITM t5 on t0.ItemCode = t5.ItemCode
                                WHERE T0.DocEntry = @DocEntry

                                SET @ProductTestId = (SELECT SCOPE_IDENTITY());

                                INSERT INTO ATEEI_SRTP_ProductTestLines(ProductTestId,ParamId,ParamCode,Status,Comments,DateRealese,UserRealese,BlockQty,Justify,Mandatory,Description,Measurement,Minimun,Maximun)

                                SELECT @ProductTestId, (ROW_NUMBER() OVER(PARTITION BY @ProductTestId ORDER BY T4.id ASC)), t4.ParamCod,'N',t4.Comments,NULL,NULL,0,NULL ,'Y',t4.Dscription,null ,T4.MinVal,T4.MaxVal FROM OWOR T0
                                INNER JOIN ITT1 T2 ON T0.ItemCode = T2.Father AND T2.U_Pos_id = @PosId and t2.Type = 290
                                INNER JOIN ATEEI_SRTP_ADDON_TestPlans T3 ON T3.Code = T2.U_TestPlan
                                INNER JOIN ATEEI_SRTP_ADDON_TestPlansLines T4 ON T3.Id = T4.TestPlansId
                                WHERE T0.DocEntry = @DocEntry
                                END 
                                SELECT t1.*,t0.Quantity ,t3.FirstName,t2.ItemName FROM  ATEEI_SRTP_ProductTest T0 
                                 INNER JOIN ATEEI_SRTP_ProductTestLines T1 on T0.Id = T1.ProductTestId 
                                 left  JOIN OITM T2 ON T0.ItemCode = T2.ItemCode
                                 left join ohem t3 on t1.UserRealese = t3.EmpId

                                 where t0.DocEntry = @DocEntry and t0.TimeRegisterId = @TimeRegisterId and t0.serial = @Serial
                                 ";

              
                return query;

            }catch(Exception e)
            {

                return e.Message;

            }

        }


    }
}
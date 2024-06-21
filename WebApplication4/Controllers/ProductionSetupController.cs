using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebApplication4.Context;
using WebApplication4.DAO;

namespace WebApplication4.Controllers
{
    public class ProductionSetupController : Controller
    {
        private TemplateContext _context;
       
        public ProductionSetupController(TemplateContext context)
        {
            _context = context;
        }

        public void CreateSetup(int docEntry,string resource, int createdByUser,int sequence, int PosId)
        {
            string query = "INSERT INTO ATEEI_SRTP_RG_SETUP(DocEntry,Resource,CompltQty,StartDate,CreatedByUser,Sequence,PosId) values("+docEntry+",'"+resource+"',0,GETDATE(),"+createdByUser+","+sequence+","+PosId+")";
            SQLConnection conn = new SQLConnection(_context);
            conn.SqlNonQuery(query);

        }

        public bool IsOpenedBySetup(int setupId)
        {
            bool ret = false;
            try
            {
                SQLConnection conn = new SQLConnection(_context);
                string query = "SELECT TOP 1 1 from ATEEI_SRTP_RG_TEMPO WHERE TERMINO IS NOT NULL AND ID_RG_SETUP ="+ setupId ;
                var data = conn.Connect(query);
                if (data.HasRows)
                {   
                    ret = true;
                }
                data.Close();
            }
            catch(Exception e)
            {
                ret = true;
            }

            return ret;
        }
        public string CloseSetup(int id )
        {           
            try
            {
                string ret = "false";

                if (!IsOpenedBySetup(id))
                {
                    SQLConnection conn = new SQLConnection(_context);
                    conn.SqlNonQuery("UPDATE ATEEI_SRTP_RG_SETUP SET EndDate = getdate()  WHERE ID = " + id + "");
                    ret = "true";
                }
                else
                {

                    ret = "Registro de tempo aberto no SETUP";

                }
                return ret;
            }
            catch (Exception e)
            {
                return "false";
            }
           
        }
        public string VerifySetupOnline(int docEntry, string resource, int sequence)
        {
            SQLConnection conn = new SQLConnection(_context);

            var result = conn.Connect("SELECT * FROM ATEEI_SRTP_RG_SETUP WHERE DocEntry = " + docEntry + " AND Sequence =" + sequence + " AND Resource = '" + resource + "' AND EndDate is null ");

            if (result.HasRows)
            {
                string ret = "";
                while (result.Read())
                {

                    ret = result["ID"].ToString();


                }
                result.Close();
                return ret;

            }
            else
            {
                return "false";

            }
        }
            public ActionResult ProductionSetup(int docEntry, string resource, int sequence)
            {


            SQLConnection conn = new SQLConnection(_context);

            var result = conn.Connect("select * from ateei_srtp_rg_setup where DocEntry="+docEntry+" and Resource ='"+resource+"' and Sequence="+sequence+"");

            ViewBag.data = result;



            return View();

            }


        public ActionResult ProductionSetupLine(int id)
        {


            SQLConnection conn = new SQLConnection(_context);

            var result = conn.Connect(" select * from  ATEEI_SRTP_RG_SERIE_ON_SETUP t0 " +
                                      " inner join  ATEEI_SRTP_RG_n_SERIE_RECURSO t1 on t0.ID_N_SERIE_RECURSO = t1.id "+
                                      " inner join  ATEEI_SRTP_RG_SETUP t2 on t0.ID_RG_SETUP = t2.id "+
                                      " where t2.id = "+id+" ");

            ViewBag.data = result;



            return View();

        }

        public ActionResult AssemblyWorkOrder(int serialNumberId)
        {


            SQLConnection conn = new SQLConnection(_context);

            var result = conn.Connect("select * from ATEEI_SRTP_ASSEMBLY_WORKORDER T0 LEFT JOIN OITM T1 ON T0.ItemCode = t1.ItemCode  where ID_N_SERIE_RECURSO =" + serialNumberId);

            ViewBag.data = result;




            return View();

        }
        public string AssemblyWorkOrderParameters(int id)
        {

            SQLConnection conn = new SQLConnection(_context);

            var result = conn.Connect("select * from  ATEEI_SRTP_ASSEMBLY_WORKORDER_PARAMETERS T1  where id_assembly_workOrder = "+id+"" );

            string html = "<tr backgroud-color:\"red\" ><td colspan=\"2\"> Cód. Parâmetro</td> <td>Descrição</td> <td>Medição</td> <td>Status</td></tr>";
            string ret = "";

            while (result.Read())
            {
                ret = result["Status"].ToString().Trim();
                html = html + " <tr><td colspan=\"2\" >" + result["ParamCode"] + "</td> <td>" + result["Description"] + "</td><td><input type= 'text'  id=\"measurement" + result["ID"] + "\" value = \" " + result["Measurement"] + " \" onblur=\"SaveAWOMeasurementParameters(" + result["ID"] + ")\" /> </td> ";

                if (result["Status"].ToString().Trim() == "Y") {
                    html = html + "<td><input type=\"checkbox\" id =\"status" + result["ID"] + "\"  onclick=\"SaveAWOStatusParameters(" + result["ID"] + ")\"  checked     ></td></tr>";

                }
                else
                {
                  html = html + "<td><input type=\"checkbox\" id =\"status" + result["ID"] + "\"  onclick=\"SaveAWOStatusParameters(" + result["ID"] + ")\"    ></td></tr>";

                }
            }
            result.Close();
            return html;
        }
        public string AddSerialSetup(string serial, int idSetup)
        {
            string ret = "";
            try
            {
                SQLConnection conn = new SQLConnection(_context);
                System.Data.Common.DbDataReader result;
                System.Data.Common.DbDataReader result2;
                result = conn.Connect("select top 1 id,ordem,PosId from ATEEI_SRTP_rg_n_serie_recurso where id_rg_setup = " + idSetup + " and N_SERIE = '" + serial + "'");

                string idRgSerie ="";
                string posId = "";
                string docEntry = "";
                while (result.Read())
                {
                    idRgSerie = result["id"].ToString();
                    posId = result["PosId"].ToString();
                    docEntry = result["ORDEM"].ToString();
                }
               
                if (result.HasRows)
                {
                    result.Close();
                    result2 = conn.Connect("select * from ATEEI_SRTP_RG_SERIE_ON_SETUP where id_rg_setup =" + idSetup + " and id_n_serie_recurso = " + idRgSerie + " ");

                    if (!result2.HasRows)
                    {
                        result2.Close();
                        conn.SqlNonQuery("insert ATEEI_SRTP_RG_SERIE_ON_SETUP(ID_N_SERIE_RECURSO, ID_RG_SETUP,SampleQty) values(" + idRgSerie + ", " + idSetup + ",0)");
                            
                        CreateAssemblyWorkOrder(idRgSerie, int.Parse(posId), int.Parse(docEntry));

                        ret = "true";

                    }
                    else
                    {

                        ret = "Serial já registrado no SETUP";

                    }
                }
                else
                {

                    ret = "Serial não registrado na rota!";

                }               

            }catch (SqlException e)
            {

                ret = e.Message;
            }

            return ret;

        }
        public string DeleteSerialSetup(int id)
        {
            try
            {
                SQLConnection conn = new SQLConnection(_context);

                 System.Data.Common.DbDataReader slt = conn.Connect("SELECT ID_N_SERIE_RECURSO FROM ATEEI_SRTP_RG_SERIE_ON_SETUP WHERE ID = " + id);
                string idserial = "";
                while (slt.Read())
                {
                    idserial = slt[0].ToString();

                }
                slt.Close();

                conn.SqlNonQuery("delete t1 from ATEEI_SRTP_ASSEMBLY_WORKORDER t0 left join ATEEI_SRTP_ASSEMBLY_WORKORDER_PARAMETERS t1 on t0.ID = t1.ID_ASSEMBLY_WORKORDER where ID_N_SERIE_RECURSO  =" + idserial + " delete from ATEEI_SRTP_ASSEMBLY_WORKORDER where ID_N_SERIE_RECURSO  =" + idserial);
                
                conn.SqlNonQuery("delete from ATEEI_SRTP_RG_SERIE_ON_SETUP where id = " + id + " ");

                return "true";
            }catch(Exception e)
            {

                return e.Message;

            }
        }

        public string CreateAssemblyWorkOrder(string idRgSerie ,int sequence,int docEntry) {

            try
            {
                SQLConnection conn = new SQLConnection(_context);

                // oldcode with separate by sector var result = conn.Connect("select t1.ItemCode,t1.DocEntry,t1.U_Pos_id,t1.BaseQty,U_REF_MONT from OWOR t0 inner join WOR1 t1 on t0.DocEntry = t1.DocEntry where t0.DocNum ="+docEntry+ " and u_assemblyrout = " + sequence+"");
                var result = conn.Connect("select t1.ItemCode,t1.DocEntry,t1.U_Pos_id,t1.BaseQty,U_REF_MONT from OWOR t0 inner join WOR1 t1 on t0.DocEntry = t1.DocEntry where t0.DocNum ="+docEntry+ " and t1.ItemType = 4 ");
                string query = "";
                while (result.Read()) {

                    query = query+("INSERT INTO ATEEI_SRTP_ASSEMBLY_WORKORDER ( ID_N_SERIE_RECURSO , ItemCode, DocEntry ,   PosId   ,BaseQty, AssemblyReference) VALUES("+idRgSerie+",'"+result["ItemCode"]+"',"+result["DocEntry"]+","+result["U_Pos_id"]+","+result["BaseQty"].ToString().Replace(",",".")+",'"+result["U_REF_MONT"]+"') ");
                    
                }
                if (result.HasRows) {
                    result.Close();
                    conn.SqlNonQuery(query);
                }


                result = conn.Connect("select t0.id from  ATEEI_SRTP_ASSEMBLY_WORKORDER t0 left join ATEEI_SRTP_ASSEMBLY_WORKORDER_parameters t1 on t0.id = t1.id_assembly_workOrder where t1.id is null and docentry = " + docEntry + " ");
               
                List<int> IdsAssemblyWO = new List<int>();

                while (result.Read())
                {
                    IdsAssemblyWO.Add(int.Parse(result["id"].ToString()));                 
                }
                result.Close();
                string r = "";
                foreach (int id in IdsAssemblyWO) {

                   r= CreateAssemblyWorkOrderParameters(id);
                }
                                


                return r;

            }
            catch (Exception e)
            {

                return e.Message;

            }        
        }

        public string CreateAssemblyWorkOrderParameters(int idAssemblyWorkOrder)
        {
            try
            {
                string query = " select distinct U_ATRIBUTOS, cast(U_OBS as varchar(150)) as U_OBS from ATEEI_SRTP_ASSEMBLY_WORKORDER t0 "+
                               " inner join ATEEI_SRTP_RG_N_SERIE_RECURSO x1 on t0.id_n_serie_recurso = x1.id  inner join OWOR t1 on t0.docentry = t1.DocEntry   inner join WOR1 t2 on t1.DocEntry = t2.DocEntry and U_Pos_id = x1.PosId and t2.ItemType = 290 " +
                               " inner join ITT1 t3 on t3.Father = t1.ItemCode and t3.U_Pos_id = x1.PosId  and t3.Type = 290 " +
                               " inner join \"@PLANO_INSP_L\" P on  P.Code = t3.U_INSP_PLAN_R " +
                               " where  t0.id = "+idAssemblyWorkOrder+" ";


                SQLConnection conn = new SQLConnection(_context);
                var result = conn.Connect(query);
                string command = "";
                while (result.Read())
                {
                    command = command + " INSERT ATEEI_SRTP_ASSEMBLY_WORKORDER_PARAMETERS(ID_ASSEMBLY_WORKORDER,	ParamCode,	Description,	Status	,Measurement,	Comments) VALUES(" + idAssemblyWorkOrder+",'"+result["U_atributos"]+"','"+ result["U_obs"] + "','N','','') ";
                }
                result.Close();
                conn.SqlNonQuery(command);

                return command;
            }
            catch (Exception e)
            {

                return e.Message;

            }


        }


        public string SaveAWOMeasurementParameters(int id, string measurement)
        {
            try
            {
                SQLConnection conn = new SQLConnection(_context);
                conn.SqlNonQuery("UPDATE ATEEI_SRTP_ASSEMBLY_WORKORDER_PARAMETERS SET Measurement = '"+measurement+"' where ID  ="+id+"");
                return "true";
            }
            catch (Exception e)
            {

                return e.Message;

            }
        }

        public string SaveAWOStatusParameters(int id, string status)
        {
            try
            {
                SQLConnection conn = new SQLConnection(_context);
                conn.SqlNonQuery("UPDATE ATEEI_SRTP_ASSEMBLY_WORKORDER_PARAMETERS SET status = '" + status + "' where ID  =" + id + "");
                return "true";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }




    }
    }

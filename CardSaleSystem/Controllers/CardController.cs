using CardSaleSystem.Bll;
using CardSaleSystem.Models.UserModel;
using CardSaleSystem.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using CardSaleSystem.ServiceReference;
using CardSaleSystem.Enum;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;
using XHB.Card.Bll;
using XHB.Card.BLL.Bll;
using XHB.Card.Entity;
using static CardSaleSystem.Enum.CommonEnum;
using CardSaleSystem.Models;

namespace CardSaleSystem.Controllers
{
    public class CardController : BaseController
    {
        // GET: Card
        public ActionResult Index()
        {
            if (null == base.CurrentUserInfo)
            {
                Redirect("/Home/Index");
                return null;
            }
            CardSecretEntityExt modelExt = new CardSecretEntityExt();
            if (null != Session["key"])
            {
                modelExt = Session["key"] as CardSecretEntityExt;
                ViewBag.Data = modelExt;
                Session.Remove("key");
            }else if(null != Session["special"])
            {
                modelExt = Session["special"] as CardSecretEntityExt;
                ViewBag.Data = modelExt;
                Session.Remove("special");
            }
            else
            {
                var userCode = base.CurrentUserInfo.CurrentUser;
                IList<CardSecretEntity> cardSecretEntity = CardSecretBll.GetInstance().GetGetCardSecretListByUser(userCode);
                IList<ActTypeEntity> actTypeEntity = ActTypeBll.GetInstance().GetActTypeList();

                modelExt.ActTypeEntity = actTypeEntity;
                modelExt.CardSecretEntity = cardSecretEntity;
                ViewBag.Data = modelExt;
            }
            

            return View(modelExt);
        }

        public ActionResult Used(bool use)
        {
            if (null == base.CurrentUserInfo)
            {
                Redirect("/Home/Index");
                return null;
            }
            var userCode = base.CurrentUserInfo.CurrentUser;
            IList<CardSecretEntity> cardSecretEntity = CardSecretBll.GetInstance().GetUsedCard(userCode,use);
            IList<ActTypeEntity> actTypeEntity = ActTypeBll.GetInstance().GetActTypeList();
            CardSecretEntityExt modelExt = new CardSecretEntityExt();
            modelExt.ActTypeEntity = actTypeEntity;
            modelExt.CardSecretEntity = cardSecretEntity;
            //return View(modelExt);
            Session.Add("key", modelExt);
            return Redirect("/Card/Index");
        }

        public ActionResult Upload(HttpPostedFileBase filebase, FormCollection form)
        {
            HttpPostedFileBase file = Request.Files["excel"];//获取上传的文件  
            string FileName;
            string savePath;
            if (file == null || file.ContentLength <= 0 || form.Count == 0)
            {
                ViewBag.error = "文件或节目类型不能为空";
                return Redirect("/Card/Index");
            }
            else
            {
                string filename = Path.GetFileName(file.FileName);
                int filesize = file.ContentLength;//获取上传文件的大小单位为字节byte  
                string fileEx = Path.GetExtension(filename);//获取上传文件的扩展名  
                string NoFileName = Path.GetFileNameWithoutExtension(filename);//获取无扩展名的文件名  
                int Maxsize = 10000 * 1024;//定义上传文件的最大空间大小为10M  
                string FileType = ".xls,.xlsx";//定义上传文件的类型字符串  

                FileName = NoFileName + DateTime.Now.ToString("yyyyMMddhhmmss") + fileEx;
                if (!FileType.Contains(fileEx))
                {
                    ViewBag.error = "文件类型错误，只能导入xls和xlsx格式的文件";
                    return View();
                }
                if (filesize >= Maxsize)
                {
                    ViewBag.error = "上传文件超过10M，不能上传";
                    return View();
                }
                string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads\\Excel\\";
                savePath = Path.Combine(path, FileName);
                file.SaveAs(savePath);
            }

            DataSet myDataSet = new DataSet();
            try
            {
                //连接串  
                string strConn = string.Format(SqlHelper.OledbConnection, savePath);
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                //返回Excel的架构，包括各个sheet表的名称,类型，创建时间和修改时间等　  
                DataTable dtSheetName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
                //包含excel中表名的字符串数组  
                string[] strTableNames = new string[dtSheetName.Rows.Count];
                for (int k = 0; k < dtSheetName.Rows.Count; k++)
                {
                    strTableNames[k] = dtSheetName.Rows[k]["TABLE_NAME"].ToString();
                }
                OleDbDataAdapter myCommand = null;
                DataTable dt = new DataTable();
                //从指定的表明查询数据,可先把所有表明列出来供用户选择  
                string strExcel = "select*from[" + strTableNames[0] + "]";
                myCommand = new OleDbDataAdapter(strExcel, strConn);

                myCommand.Fill(myDataSet, "ExcelInfo");
            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                return Redirect("/Card/Index");
            }

            DataTable table = myDataSet.Tables["ExcelInfo"].DefaultView.ToTable();

            for (int i = 0; i < table.Rows.Count; i++)
            {

                CardSecretEntity data = new CardSecretEntity();

                data.CardId = table.Rows[i][0].ToString();
                data.CardSecret = table.Rows[i][1].ToString();
                data.IsUsed = false;
                data.UsedBy = string.Empty;
                data.SaleStatus = 1;
                data.CreateTime = DateTime.Now;
                data.UpdatTime = DateTime.Now;
                data.IsActive = true;
                data.ActId = long.Parse(form["CardId"]);
                CardSecretBll.GetInstance().Insert(data);
            }

            ViewBag.error = "上传成功";
            System.Threading.Thread.Sleep(500);
            return Redirect("/Card/Index");

        }

        public ActionResult BuyCard(FormCollection form)
        {
            //买家UID
            long userId = base.CurrentUserInfo.Id;
            if (form.Count == 0 || int.Parse(form["count"]) == 0 || userId==0)
            {
                return Redirect("/Card/Index");
            }

            UsersEntity user = UsersBll.GetInstance().GetAdminSingle(userId);
            UsersEntity seller = UsersBll.GetInstance().GetUserByCode(user.CreateBy);
            //卖家UID
            long sellerUserId = seller.Id;
            short status = 2;
            int count = int.Parse(form["count"]);
            long cardId = long.Parse(form["cardId"]);
            string buyerCode = user.UserCode;
            bool ret = CardSecretBll.GetInstance().BuyCard(buyerCode , userId, sellerUserId, cardId, status, count);
            return Redirect("/Card/Index");
        }

        public ActionResult Query(FormCollection form)
        {
            if(form.Count == 0)
            {
                return Redirect("/Card/Desktop");
            }

            //string[] flag = { "cx", "kt", "cs", "xf" };

            //int flag = int.Parse(form["radio"]);

            //switch (flag)
            //{
            //    case 0:
            //        break;
            //    case 1:
            //        break;
            //    case 2:
            //        break;
            //    case 3:
            //        break;
            //    default:
            //        break;
            //}


            APIClient client = new APIClient();
            CardQueryExt queryExt = new CardQueryExt();

            string  ret = client.Query(form["machine"].Trim());
            JObject o = JObject.Parse(ret);
            string json = ((JValue)o.SelectToken("Result")).Value.ToString();


            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<VPack>));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            object ob = serializer.ReadObject(stream);
            List<VPack> pack = (List<VPack>)ob;

            var act = ActTypeBll.GetInstance().GetActTypeList();

            queryExt.VPack = pack;
            queryExt.ActType = act;

            return View("~/Views/Home/Desktop.cshtml",queryExt);
        }


        public ActionResult InputPoint(FormCollection form)
        {
            if (form.Count == 0 || null==Session["_UserId"])
            {
                return Redirect("/Home/Desktop");
            }

            string cid = form["cid"];
            string pd = form["pd"];

            long uid = long.Parse(Session["_UserId"].ToString());
            UsersEntity entity = UsersBll.GetInstance().GetAdminSingle(uid);
            CardSecretBll.GetInstance().InputPoint(form["cid"], form["pd"], entity.UserCode);
            //return Content();
            return Redirect("/Home/Desktop");
        }

        public ActionResult GetSpecialCard(FormCollection form)
        {
            if (form.Count == 0 || form["querycard"].ToString().Length == 0)
            {
                return Redirect("/Card/Index");
            }
            long uid = Session["_UserId"] == null ? 0 : long.Parse(Session["_UserId"].ToString());
            if (uid <= 0)
            {
                return Redirect("/Card/Index");
            }

            var user = UsersBll.GetInstance().GetAdminSingle(uid);
            string cardNo = form["querycard"];
            IList<CardSecretEntity> card = CardSecretBll.GetInstance().GetSpecialCard(user.UserCode, cardNo);
            var act = ActTypeBll.GetInstance().GetActTypeList();
            CardSecretEntityExt queryExt = new CardSecretEntityExt();
            queryExt.CardSecretEntity = card;
            queryExt.ActTypeEntity = act;
            Session.Add("special",queryExt);
            return Redirect("/Card/Index");
        }

        public ActionResult GetUsedCard(bool used)
        {
            long uid = Session["_UserId"] == null ? 0 : long.Parse(Session["_UserId"].ToString());
            if (uid<=0)
            {
                return Redirect("/Card/Index");
            }

            var user = UsersBll.GetInstance().GetAdminSingle(uid);

            CardSaleSystem.ServiceReference.CardClient client = new CardClient();
            client.DoWork();

            IList<CardSecretEntity> card = CardSecretBll.GetInstance().GetUsedCard(user.UserCode, used);
            var act = ActTypeBll.GetInstance().GetActTypeList();
            CardSecretEntityExt queryExt = new CardSecretEntityExt();
            queryExt.CardSecretEntity = card;
            queryExt.ActTypeEntity = act;
            ViewBag.Data = queryExt;
            ModelState.Clear();
            return PartialView("/Views/Card/Partial/_PartialCardView.cshtml");
          
        }
    }
}
using CardSaleSystem.Models.ExtModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XHB.ActPrice.Bll;
using XHB.Card.BLL.Bll;
using XHB.Card.Entity;

namespace CardSaleSystem.Controllers
{
    public class CardTypeController : Controller
    {
        //节目类型和包类型都在一个页面处理
        public ActionResult Index()
        {
            //IList<ActTypeEntity> list = new List<ActTypeEntity>();
            //list = ActTypeBll.GetInstance().GetActTypeListActive();
            //

            long uuid = long.Parse(Session["_UserId"].ToString());
            IList<ActPriceEntityExt> list = new List<ActPriceEntityExt>();
            list = ActPriceBll.GetInstance().GetActPriceExt(uuid);
            return View(list);
        }

        public ActionResult CreateAct(FormCollection form)
        {
            ActTypeEntity entity = new ActTypeEntity
            {
                TypeCode = form["TypeCode"],
                TypeName=form["TypeName"],
                Description=form["Description"],
                IsActive = form["IsActive"].Equals("1")? true :false,
                CreateTime=DateTime.Now,
                UpdateTime=DateTime.Now
            };

            var ret= ActTypeBll.GetInstance().Insert(entity);
            return Redirect("/CardType/Index");
        }

        public ActionResult MakePrice(FormCollection form)
        {
            if(form.Count <= 0)
            {
                return View();
            }

            double price = double.Parse(form["price"]);
            long id = long.Parse(form["cid"]);
            long uid = long.Parse(Session["_UserId"].ToString());

            var ex = XHB.ActPrice.Bll.ActPriceBll.GetInstance().IsExistActPrice(id);

            if (ex>0)
            {
                //var updateEntity =  XHB.ActPrice.Bll.ActPriceBll.GetInstance().GetActPriceByActId(ex);
                var updateEntity = XHB.ActPrice.Bll.ActPriceBll.GetInstance().GetAdminSingle(ex);
                updateEntity.Price = price;
                updateEntity.UpdateTime = DateTime.Now;
                var res = XHB.ActPrice.Bll.ActPriceBll.GetInstance().Update(updateEntity);
            }
            else
            {
                var res = XHB.ActPrice.Bll.ActPriceBll.GetInstance().Insert(new XHB.ActPrice.Entity.ActPriceEntity()
                {
                    ActId = id,
                    CreateTime = DateTime.Now,
                    IsActive = true,
                    Price = price,
                    UpdateTime = DateTime.Now,
                    UserId = uid
                });
            }
            //bool ret =  ActTypeBll.GetInstance().UpdateActPrice(id, price);
            return Redirect("/CardType/Index");
        }

        public ActionResult Delete(FormCollection form)
        {
            if (form.Count <= 0)
            {
                return View();
            }
            long id = long.Parse(form["id"]);
            long ret = ActTypeBll.GetInstance().DeleteLogical(id);
            return Redirect("/CardType/Index");
        }
    }
}
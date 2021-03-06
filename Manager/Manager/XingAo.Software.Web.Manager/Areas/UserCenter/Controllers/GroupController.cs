﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XingAo.Core;
using XingAo.Core.Data;
using XingAo.Software.UserCenter.Impl;
using XingAo.Software.UserCenter.Model;

namespace XingAo.Software.Web.Manager.Areas.UserCenter.Controllers
{
    public class GroupController : Controller
    {
        //
        // GET: /UserCenter/Group/

        GroupRepository repository = new GroupRepository();
        Pagination pagination = new Pagination();

        public ActionResult Index()
        {
            pagination.PageNum = Request["PageNum"].ObjToInt() == -1 ? 1 : Request["PageNum"].ObjToInt();
            var where = QueryBuilder.Create<GroupModel>()
                   .Like(c => c.Name, "");
            IList<GroupModel> model = repository.Search(where, p => p.OrderBy(m => m.Id), pagination);
            ViewBag.Pagination = pagination;
            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }
    }
}

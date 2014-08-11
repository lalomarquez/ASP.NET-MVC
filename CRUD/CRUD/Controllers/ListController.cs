using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.Models;
using System.Data;

namespace CRUD.Controllers
{
    public class ListController : Controller
    {
        //
        // GET: /List/
        public ActionResult Lista()
        {
            SCRUD crud = new SCRUD();
            DataTable dt = crud.ReadRecordsADONet();

            List<PropertiesUser> lista = new List<PropertiesUser>();

            foreach (DataRow dr in dt.Rows)
            {
                PropertiesUser users = new PropertiesUser();
                users.ID_User = Convert.ToInt32(dr["ID_User"].ToString());
                users.Name = dr["Name"].ToString();
                users.LastName = dr["LastName"].ToString();
                users.Email = dr["Email"].ToString();
                users.Company = dr["Company"].ToString();
                users.Date = dr["Date"].ToString();
                users.Status = dr["Status"].ToString();
                lista.Add(users);
            }

            return View(lista);
        }
	}
}
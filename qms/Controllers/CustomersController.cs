using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using qms.Models;
using System.IO;
using System.Data.OleDb;

namespace qms.Controllers
{
    [Authorize(Roles = "Admin, Branch Admin, Service Holder")]
    public class CustomersController : Controller
    {

        private BLL.BLLCustomer dbManager = new BLL.BLLCustomer();
        private BLL.BLLCustomerType dbCustomerType = new BLL.BLLCustomerType();

        // GET: Customers
        public ActionResult Index()
        {
            return View(dbManager.GetAllCustomer());
            //var tblCustomer = db.tblCustomers.Include(c => c.tblCustomerType);
            //return View(await db.tblCustomers.ToListAsync());
        }

        // GET: Customers/Details/5
        //public async Task<ActionResult> Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tblCustomer tblCustomer = await db.tblCustomers.FindAsync(id);
        //    if (tblCustomer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tblCustomer);
        //}

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customer_id,customer_name,contact_no,address,customer_type_id")] tblCustomer tblCustomer)
        {
            if (ModelState.IsValid)
            {
                //db.tblCustomers.Add(tblCustomer);
                //await db.SaveChangesAsync();
                dbManager.Create(tblCustomer);
                return RedirectToAction("Index");
            }

            return View(tblCustomer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCustomer tblCustomer = dbManager.GetById(id.Value);
            if (tblCustomer == null)
            {
                return HttpNotFound();
            }
            ViewBag.type_id = new SelectList(dbCustomerType.GetAll(), "Customer_type_id", "CUSTOMER_TYPE_NAME", tblCustomer.customer_type_id);
            return View(tblCustomer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customer_id,customer_name,contact_no,address,customer_type_id")] tblCustomer tblCustomer)
        {
            if (ModelState.IsValid)
            {
                dbManager.Edit(tblCustomer);
                return RedirectToAction("Index");
            }
            ViewBag.type_id = new SelectList(dbCustomerType.GetAll(), "Customer_type_id", "CUSTOMER_TYPE_NAME", tblCustomer.customer_type_id);
            return View(tblCustomer);
        }

        // GET: Customers/Delete/5
        //public async Task<ActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tblCustomer tblCustomer = await db.tblCustomers.FindAsync(id);
        //    if (tblCustomer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tblCustomer);
        //}

        // POST: Customers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(long id)
        //{
        //    tblCustomer tblCustomer = await db.tblCustomers.FindAsync(id);
        //    db.tblCustomers.Remove(tblCustomer);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
        //public ActionResult ImportExcel()
        //{
        //    int noOfExcelMember = 0;
        //    int noOfSystemPfMember = 0;
        //    int noOfInvalidMember = 0;
        //    int noOfExcelPfMember = 0;
        //    string extension = "";
        //    OleDbConnection _excelConnection;
        //    DataSet dataset = new DataSet();
        //    List<tblCustomer> _lstCustomer;


        //        return RedirectToAction("Import");
        //    }

        //    if (extension.Contains(".xls") || extension.Contains(".xlsx"))
        //    {
        //        if (Request.Files["FileUpload1"].ContentLength > 0)
        //        {

        //            string path1 = string.Format("{0}/{1}", Server.MapPath("~/ImportedExcel/Cutomer"), datetime.Month + "-" + datetime.Year + extension);
        //            if (System.IO.File.Exists(path1))
        //                System.IO.File.Delete(path1);

        //            Request.Files["FileUpload1"].SaveAs(path1);

        //            if (Path.GetExtension(path1) == ".xls")
        //            {
        //                _excelConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path1 + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"");
        //                _excelConnection.Open();
        //            }
        //            else if (Path.GetExtension(path1) == ".xlsx")
        //            {
        //                _excelConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1;';");
        //                _excelConnection.Open();
        //            }

        //            OleDbCommand cmd = new OleDbCommand();
        //            OleDbDataAdapter oleda = new OleDbDataAdapter();

        //            cmd.Connection = _excelConnection;
        //            cmd.CommandType = CommandType.Text;
        //            //cmd.CommandText = "SELECT * FROM [" + txtSheetName.Text + "$" + txtHDRStrtIndex.Text + ":QQ65536]";
        //            try
        //            {
        //                cmd.CommandText = "Select [customer_name],[contact_no], [address] from [Sheet1$]";
        //                oleda = new OleDbDataAdapter(cmd);
        //                oleda.Fill(dataset, "SalaryData");
        //            }
        //            catch (Exception x)
        //            {
        //                
        //                TempData["ErrorMessage"] = "Error Encountered - " + x.Message;
        //                return RedirectToAction("Import");
        //            }
        //            finally
        //            {
        //                OleDbConnection.ReleaseObjectPool();
        //                _excelConnection.Close();
        //                _excelConnection.Dispose();
        //                if (System.IO.File.Exists(path1))
        //                    System.IO.File.Delete(path1);
        //            }
        //            try
        //            {
        //                DataTable dt = dataset.Tables["SalaryData"];
        //                var query = dt.AsEnumerable().Select(s => new
        //                {
        //                    CustomerName = s.Field<string>("customer_name"),
        //                    ContactNo = s.Field<object>("contact_no"),
        //                    Address = s.Field<object>("address"),
        //                   
        //                }).ToList();

        //                noOfExcelMember = dt.Rows.Count;
        //                _lstCustomer = new List<tblCustomer>();

        //                foreach (var item in query)
        //                {
        //                    //if no Customer found we should ignore that record, isn't it?
        //                    if (string.IsNullOrEmpty(item.EmployeeID))
        //                    {
        //                        continue;
        //                    }

        //                   
        //                    _vmCustomer = new VM_Customer();
        //                    _vmCustomer.customer_name = item.CustomerName;
        //                    _vmCustomer.contact_no = item.ContactNo;
        //                    _vmCustomer.address = item.Address;
        //                   
        //                    try
        //                    {
        //                        _vmCustomer.customer_name = item.CustomerName + "";
        //                    }
        //                    catch
        //                    {
        //                        _vmCustomer.Message += "Customer -" + item.CustomerName + "- not in correct format.";
        //                    }
        //                    try
        //                    {
        //                        _vmContribution.contact_no = (item.ContactNo);
        //                    }
        //                    catch
        //                    {
        //                        _vmContribution.Message += "ContactNo -" + item.ContactNo + "- not in correct format, this value required!";
        //                    }
        //                    try
        //                    {
        //                        _vmContribution.address = (item.Address);
        //                    }
        //                    catch
        //                    {
        //                        _vmContribution.Message += "Address -" + item.Address + "- not in correct format, this value required!";
        //                    }
        //                   
        //                    _lstCustomer.Add(_vmContribution); // adding object to list.
        //                }
        //            }
        //            catch (Exception x)
        //            {
        //                ViewBag.Month = "";
        //                ViewBag.ErrorMessage = "Error Encountered - " + x.Message;
        //                return RedirectToAction("Import");
        //            }
        //        }
        //        else
        //        {
        //           
        //            TempData["ErrorMessage"] = "Please upload Contrebution file in excel format...";
        //            return RedirectToAction("Import");
        //        }
        //    }
        //    else
        //    {
        //        
        //        TempData["ErrorMessage"] = "Please upload only valid excel file...";
        //        return RedirectToAction("Import");
        //    }
        //  
        //    return View("ExcelMonthlyContributionNotProcessed", _lstCustomer);

    }
}


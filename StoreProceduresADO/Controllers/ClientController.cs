using Microsoft.AspNetCore.Mvc;
using StoreProceduresADO.DAL;
using StoreProceduresADO.Models;

namespace StoreProceduresADO.Controllers
{
    [Produces("application/json")]
    public class ClientController : Controller
    {
        // GET: ClientController

        private readonly IConfiguration _configuration;
        private readonly DataAccess _dataAccess;
        public ClientController(IConfiguration configuration, DataAccess dataAccess)
        {
            _configuration = configuration;
            _dataAccess = dataAccess;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var clientList = _dataAccess.GetClient();
            if (clientList.Count == 0)
            {
                TempData["InfoMessage"] = "Database Empty";
            }
            return View(clientList);
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            try
            {
                bool IsInserted;
                //if(ModelState.IsValid)
                //{
                IsInserted = _dataAccess.CreateClient(client);

                if (IsInserted)
                {
                    TempData["SuccessMessage"] = "Client Created Successfully!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Insert Data Client Fails";
                }
                //}

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: ClientController/Edit/5

        //[HttpGet("{id}")]
        public ActionResult Edit(int id)
        {
            var clients = _dataAccess.GetClientById(id);

            if (clients == null)
            {
                TempData["InfoMessage"] = "Product not available with Id " + id.ToString();
                return RedirectToAction(nameof(Index));
            }
            return View(clients);
        }

        // POST: ClientController/Edit/5
        [HttpPost,ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Client client)
        {
            try
            {
                bool IsUpdated = _dataAccess.UpdateClient(client);

                if (!IsUpdated)
                {
                    TempData["SuccessMessage"] = "Client saved successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Client unable to update ";
                }

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var client = _dataAccess.GetClientById(id);
                if (client == null)
                {
                    TempData["InfoMessage"] = "Product not available with Id " + id.ToString();
                    return RedirectToAction(nameof(Index));
                }
                return View(client);
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
            
        }

        // POST: ClientController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmation(int id)
        {
            try
            {
                string result = _dataAccess.DeleteClient(id);

                if (result.Contains("Deleted"))
                {
                    TempData["SuccessMessage"] = result;
                }
                else
                {
                    TempData["ErrorMessage"] = result;
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }
    }
}

using HotelApi.Models;
using HotelApi.Models.DTO;
using HotelApi.Service.Invoice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {

        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        //[HttpPost("{idReservation}")]
        //public JsonResult createInvoice(int idReservation, InvoiceModel invoice)
        //{
        //    ResponseDTO response;
        //    try
        //    {
        //        //_invoiceService.createInvoice(idReservation, invoice);
        //        response = new ResponseDTO(true, "Invoice created sucessfull", invoice);
        //        return new JsonResult(response);
        //    }
        //    catch (Exception e)
        //    {
        //        response = new ResponseDTO(false, e.Message, null);
        //        return new JsonResult(response);
        //    }
        //}

        [HttpGet]
        public JsonResult GetAllInvoices()
        {
            ResponseDTO response;
            try
            {
                var invoices = _invoiceService.GetAllInvoices();
                if (invoices.Count() <= 0) throw new Exception("Don't exist invoices");
                response = new ResponseDTO(true, "Invoices obtained successfully", invoices);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                response = new ResponseDTO(false, ex.Message, null);
                return new JsonResult(response);
            }
        }

    }
}

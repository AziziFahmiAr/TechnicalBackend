using Microsoft.AspNetCore.Mvc;
using TechnicalBackend.Models;
using TechnicalBackend.Service;

namespace TechnicalBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TTDeveloperController : Controller
    {
        private readonly ITTDeveloperService TTDeveloperService;

        public TTDeveloperController(ITTDeveloperService _TTDeveloperService)
        {
            TTDeveloperService = _TTDeveloperService;
        }

        [HttpGet]
        [Route("all")]
        public List<TTDeveloperGetAllModel> Get()
        {
            return TTDeveloperService.getAllData();
        }

        [HttpGet]
        [Route("{id}")]
        public TTDeveloperGetDetailModel Get(Guid id)
        {
            return TTDeveloperService.getDataDetails(id);
        }

        [HttpPost]
        [Route("save")]
        public TTDeveloperGetDetailModel Save(TTDeveloperGetDetailModel model)
        {
            return TTDeveloperService.saveData(model);
        }

        [HttpPut]
        [Route("update")]
        public TTDeveloperGetDetailModel Update(TTDeveloperGetDetailModel model)
        {
            return TTDeveloperService.updateData(model);
        }

        [HttpDelete]
        [Route("delete")]
        public string Delete(Guid id)
        {
            return TTDeveloperService.deleteData(id);
        }
    }
}

using Entites;
using InventoryBusiness.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;

namespace InventoryAPI.Controllers
{
    [Produces("application/json")]
    [Microsoft.AspNetCore.Mvc.Route("api/Item")]

    public class ItemController : Controller
    {

        APIResponseModel apiResponse;
        ResultResponseModel resultResponse;
        IItemBusiness _itemBusiness;
        private readonly IOptions<Appsettings> _appSettings;


        public ItemController(IItemBusiness itemBusiness, IOptions<Appsettings> appSettings)
        {
            _appSettings = appSettings;
            _itemBusiness = itemBusiness;
            apiResponse = new APIResponseModel();
            resultResponse = new ResultResponseModel();

        }

        [HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("AddItem")]
        public APIResponseModel AddItem([FromBody] Item item)
        {
            try
            {
                if (item != null)
                {
                    var result = _itemBusiness.AddItem(item);

                    if (result != null)
                    {
                        resultResponse.Data = result;
                        resultResponse.IsError = false;
                    }
                    else
                    {
                        resultResponse.Data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                resultResponse.Data = null;
                resultResponse.Message = ex.Message;
                resultResponse.StackTrace = ex.StackTrace;
                resultResponse.IsError = true;
            }

            apiResponse.Result = resultResponse;
            return apiResponse;
        }


        [HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("UpdateItem")]
        public APIResponseModel UpdateItem([FromBody] Item item)
        {
            try
            {
                if (item != null)
                {
                    var result = _itemBusiness.UpdateItem(item);

                    if (result != null)
                    {
                        resultResponse.Data = result;
                        resultResponse.IsError = false;
                    }
                    else
                    {
                        resultResponse.Data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                resultResponse.Data = null;
                resultResponse.Message = ex.Message;
                resultResponse.StackTrace = ex.StackTrace;
                resultResponse.IsError = true;
            }

            apiResponse.Result = resultResponse;
            return apiResponse;
        }


        [HttpDelete]
        [Microsoft.AspNetCore.Mvc.Route("DeleteItem/{ItemID}")]
        public APIResponseModel DeleteStock(int ItemID)
        {
            try
            {
                if (ItemID > 0)
                {
                    var result = _itemBusiness.DeleteItem(ItemID);

                    if (result != null)
                    {
                        resultResponse.Data = result;
                        resultResponse.IsError = false;
                    }
                    else
                    {
                        resultResponse.Data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                resultResponse.Data = null;
                resultResponse.Message = ex.Message;
                resultResponse.StackTrace = ex.StackTrace;
                resultResponse.IsError = true;
            }

            apiResponse.Result = resultResponse;
            return apiResponse;
        }


        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("GetAllItem/{ItemID?}")]
        public APIResponseModel GetAllItem(int ItemID)
        {
            try
            {
                var result = _itemBusiness.GetAllItem(ItemID);

                if (result != null)
                {
                    resultResponse.Data = result;
                    resultResponse.IsError = false;
                }
                else
                {
                    resultResponse.Data = null;
                }

            }
            catch (Exception ex)
            {
                resultResponse.Data = null;
                resultResponse.Message = ex.Message;
                resultResponse.StackTrace = ex.StackTrace;
                resultResponse.IsError = true;
            }

            apiResponse.Result = resultResponse;
            return apiResponse;
        }
    }
}

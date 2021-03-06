﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Grand.Web.Services;
using System.Linq;

namespace Grand.Web.ViewComponents
{
    public class CurrencySelectorViewComponent : ViewComponent
    {
        private readonly ICommonWebService _commonWebService;

        public CurrencySelectorViewComponent(ICommonWebService commonWebService)
        {
            this._commonWebService = commonWebService;
        }

        public IViewComponentResult Invoke()
        {
            var model = _commonWebService.PrepareCurrencySelector();
            if (model.AvailableCurrencies.Count == 1)
                Content("");

            return View(model);
        }
    }
}
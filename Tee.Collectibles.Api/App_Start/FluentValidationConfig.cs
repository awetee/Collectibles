﻿namespace Tee.Collectibles.Api.App_Start
{
    using System.Web.Http;
    using System.Web.Http.Validation;
    using FluentValidation.WebApi;

    public class FluentValidationConfig
    {
        public static void SetupValidation(HttpConfiguration config)
        {
            var validatorProvider = new FluentValidationModelValidatorProvider(new FluentValidatorFactory());
            config.Services.Replace(typeof(IBodyModelValidator), new FluentValidationBodyModelValidator());
            config.Services.Add(typeof(ModelValidatorProvider), validatorProvider);
            config.Filters.Add(new FluentValidationFilterAttribute());
        }
    }
}
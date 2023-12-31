﻿#region Header

// /*
// Copyright (c) 2021 Rod Johnson. All rights reserved.
// Author: Rod Johnson, Architect, Munch
// */

#endregion

using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MunchBase.Common.Extensions;
using MunchBase.Common.Validation;
using Newtonsoft.Json;

namespace MunchBase.Common.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        private readonly ILoggerFactory _loggerFactory;
        private readonly RequestDelegate _next;


        public ExceptionMiddleware(
            RequestDelegate next,
            ILoggerFactory loggerFactory,
            IOptions<MvcNewtonsoftJsonOptions> jsonOptions)
        {
            _next = next;
            _loggerFactory = loggerFactory;
            _jsonSerializerSettings = jsonOptions.Value.SerializerSettings;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static HttpStatusCode GetErrorCode(Exception e)
        {
            switch (e)
            {
                case UnauthorizedAccessException _:
                    return HttpStatusCode.Unauthorized;
                case ValidationException _:
                    return HttpStatusCode.BadRequest;
                case FormatException _:
                    return HttpStatusCode.BadRequest;
                case AuthenticationException _:
                    return HttpStatusCode.Forbidden;
                case NotImplementedException _:
                    return HttpStatusCode.NotImplemented;
                default:
                    return HttpStatusCode.InternalServerError;
            }
        }

        private void LogAndAddException(ValidationResultModel modelResult, Exception exception)
        {
            var exLogger = _loggerFactory.CreateLogger(exception.TargetSite.DeclaringType.FullName);
            exLogger?.LogError(exception, exception.Message);
            modelResult.Errors.Add(new ValidationError(null, exception.Message));
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var modelResult = new ValidationResultModel();

            if (exception is AggregateException exceptions)
                foreach (var ex in exceptions.InnerExceptions)
                    LogAndAddException(modelResult, ex);
            else
                LogAndAddException(modelResult, exception);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)GetErrorCode(exception);

            return context.Response.WriteAsync(modelResult.ToJson(_jsonSerializerSettings));
        }
    }
}